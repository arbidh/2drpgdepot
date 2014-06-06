using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour {

	private Vector3 inputDirection = Vector3.zero;
	private bool isJumButtonDown = false;
	public float maxForwardSpeed;
	public float maxBackwardSpeed;
	private float gravity;
	private Vector3 velocity;
	public float acceleration= 10f;






	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float amount =Input.GetAxisRaw("Horizontal");
		float amount2 = Input.GetAxisRaw ("Vertical");

		transform.Translate(new Vector3( amount * Time.deltaTime * acceleration,  amount2 * Time.deltaTime * acceleration,
		                                transform.position.z));

	
	}
}
public class Jump:PlayerMotor
{


    private bool grounded;






}