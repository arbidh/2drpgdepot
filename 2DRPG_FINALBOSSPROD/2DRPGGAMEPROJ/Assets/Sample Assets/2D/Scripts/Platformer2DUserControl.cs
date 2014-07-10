using UnityEngine;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour 
{
	private PlatformerCharacter2D character;
    private bool jump;


	void Awake()
	{
		character = GetComponent<PlatformerCharacter2D>();
	}

    void Update ()
    {


    }

	void FixedUpdate()
	{
	

		// Pass all parameters to the character control script.


        // Reset the jump input once it has been used.
	    jump = false;
	}
}
