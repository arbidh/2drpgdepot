using UnityEngine;
using System.Collections;

public class CamFollowScript : MonoBehaviour {

	
	public Transform target;
	public float smoothTime = 0.3f;
	public float offset;
	private Vector2 velocity;
	private Transform thisObj;
	private float x;
	private float y;
	public float jumpHeight;
	
	
	
	// Use this for initialization
	void Start () {
		thisObj = transform;
		x = 0;
		y = 0;
	}
	
	
	// Update is called once per frame
	void Update () {
		
		
		x = Mathf.SmoothDamp (thisObj.position.x,
		                      target.position.x + offset,
		                      ref velocity.x,
		                      smoothTime);
		y = Mathf.SmoothDamp (transform.position.y,
		                      target.position.y,
		                      ref velocity.y,
		                      smoothTime);
		
		if(y > jumpHeight)
			y=jumpHeight;
		
		
		thisObj.position = new Vector3(x,y,transform.position.z);
		
	}
}
