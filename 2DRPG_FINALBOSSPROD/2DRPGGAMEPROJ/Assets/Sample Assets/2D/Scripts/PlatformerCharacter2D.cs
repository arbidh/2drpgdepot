using UnityEngine;

public class PlatformerCharacter2D : MonoBehaviour 
{
	bool facingRight = true;							// For determining which way the player is currently facing.

	[SerializeField] float maxSpeed = 10f;				// The fastest the player can travel in the x axis.
	[SerializeField] float jumpForce = 400f;			// Amount of force added when the player jumps.	

		// Amount of maxSpeed applied to crouching movement. 1 = 100%
	
	// Whether or not a player can steer while jumping;
	[SerializeField] LayerMask whatIsGround;			// A mask determining what is ground to the character
	
	Transform groundCheck;								// A position marking where to check if the player is grounded.
	float groundedRadius = .2f;							// Radius of the overlap circle to determine if grounded
	bool grounded = false;								// Whether or not the player is grounded.
	//Transform ceilingCheck;								// A position marking where to check for ceilings
	//float ceilingRadius = .01f;							// Radius of the overlap circle to determine if the player can stand up
	Animator anim;										// Reference to the player's animator component.
	private bool jump;

    void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("GroundCheck");
		//ceilingCheck = transform.Find("CeilingCheck");
		anim = GetComponent<Animator>();
		grounded = true;
		jump = false;
	}

	void Update()
	{
		// Read the jump input in Update so button presses aren't missed.
		#if CROSS_PLATFORM_INPUT
		if (CrossPlatformInput.GetButtonDown("Jump")){ jump = true; anim.SetBool("jump",jump);}
		#else
		if (Input.GetButtonDown("Jump")) jump = true;
		#endif
		if ( jump && grounded) {
			// Add a vertical force to the player.
			anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			jump=false;
		}



	}
	void FixedUpdate()
	{
		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
		anim.SetBool("Ground", grounded);

		// Read the inputs.
		bool crouch = Input.GetKey(KeyCode.LeftControl);
		#if CROSS_PLATFORM_INPUT
		float h = CrossPlatformInput.GetAxis("Horizontal");
		#else
		float h = Input.GetAxis("Horizontal");
		#endif


		Move( h );
		// Set the vertical animation
		//anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
	}


	public void Move(float move)
	{


	
		if (grounded) {

						//only control the player if grounded or airControl is turned on

						// Reduce the speed if crouching by the crouchSpeed multiplier
						//move = (crouch ? move * crouchSpeed : move);

						// The Speed animator parameter is set to the absolute value of the horizontal input.
						anim.SetFloat("Speed", Mathf.Abs(move));

						// Move the character
						rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
			
						// If the input is moving the player right and the player is facing left...
						if (move > 0 && !facingRight)
				// ... flip the player.
								Flip ();
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && facingRight)
				// ... flip the player.
								Flip ();
				}

        // If the player should jump...
  
	}

	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
