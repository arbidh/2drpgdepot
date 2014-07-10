using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

	private Vector2 Gravity ;
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool jump = false;				// Condition for whether the player should jump.


	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
	public float jumpForce = 1000f;			// Amount of force added when the player jumps.
	public float modifiedVelocityX=3f;
	public float modifiedVelocityY=3f;
	
	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.
	private Animator anim;					// Reference to the player's animator component.
	private float Horizontal_Input;

	void Awake()
	{
		Gravity = new Vector2 (0, -9.81f);
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		anim = GetComponent<Animator>();
		Horizontal_Input = 0;
	}


	void Update()
	{

		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Raycast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")); 
		//Debug.DrawLine (transform.position, new Vector3(groundCheck.position.x, groundCheck.position.y , groundCheck.position.z), Color.white);
		//grounded = Physics2D.OverlapCircle (transform.position, 0.3f, 1 << LayerMask.NameToLayer ("Ground"));
		// If the jump button is pressed and the player is grounded then the player should jump.

#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT
		if(Input.GetButtonDown("Jump") && grounded)
			jump = true;
		Horizontal_Input=Input.GetAxisRaw("Horizontal");
#endif

	}

	IEnumerator wait(float seconds)
	{
		yield return new WaitForSeconds (seconds);

		}

	void FixedUpdate ()
	{
				// Cache the horizontal input.
	



				if (grounded)
		{
		//float test = h + moveForce;

		// The Speed animator parameter is set to the absolute value of the horizontal input.
				if (moveForce > 0)
						anim.SetFloat ("Speed", Mathf.Abs (moveForce));

//		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
				if (moveForce > 0)
			// ... add a force to the player.
			//rigidbody2D.AddForce(Vector2.right * moveForce  );
						rigidbody2D.velocity = new Vector2 (moveForce * Time.deltaTime, rigidbody2D.velocity.y);

				// If the player's horizontal velocity is greater than the maxSpeed...
				if (Mathf.Abs (rigidbody2D.velocity.x * moveForce) > maxSpeed && moveForce > 0 || Horizontal_Input > 0)
			// ... set the player's velocity to the maxSpeed in the x axis.
						rigidbody2D.velocity = new Vector2 (Mathf.Sign (rigidbody2D.velocity.x) * maxSpeed , rigidbody2D.velocity.y);
		}
		// If the input is moving the player right and the player is facing left...
//		if(h > 0 && !facingRight)
//			// ... flip the player.
//			Flip();
//		// Otherwise if the input is moving the player left and the player is facing right...
//		else if(h < 0 && facingRight)
//			// ... flip the player.
//			Flip();

		// If the player should jump...
		if(jump && grounded)
		{
	
			// Set the Jump animator trigger parameter.
			anim.SetTrigger("jump");

			// Play a random jump audio clip.
			int i = Random.Range(0, jumpClips.Length);
			AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);
			//transform.position=new Vector2(transform.position.x, Mathf.Clamp(transform.position.y,-4,4));
			//rigidbody2D.velocity = new Vector2(0,Gravity.y * Time.deltaTime);
			// Add a vertical force to the player.
			rigidbody2D.AddForce(new Vector2(0f, jumpForce ));
			//rigidbody2D.AddRelativeForce(new Vector2(0f,jumpForce));
			//transform.Translate(Vector2.up * jumpForce * Time.deltaTime, Space.World);

			transform.position += new Vector3(modifiedVelocityX,modifiedVelocityY,0);

			wait(5);

			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
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
