using UnityEngine;
using System.Collections;

public class MobilePlayerController : MonoBehaviour {

	public float speed=500f,jumpHeight =500f;
	Transform myTrans;
	Rigidbody2D myRigidBody;
	Vector2 movement;
	bool isGrounded = false;

	// Use this for initialization
	void Start () {

		myTrans = this.transform;
		myRigidBody = this.myRigidBody;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void Move(float horizontal_input)
	{
		movement = myRigidBody.velocity;

		//if (isGrounded)
//		myTrans.rigidbody2D.velocity =  horizontal_input * speed * Time.deltaTime;

	

	}

}
