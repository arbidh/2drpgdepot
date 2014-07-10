using UnityEngine;
using System.Collections;

public class SlashInput : MonoBehaviour {

	private Vector3 lastMousePosition;
	public float minSwipeDistance=5;
	private bool swiping= false;



	// Use this for initialization
	void Start () {
		lastMousePosition = Input.mousePosition;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!swiping) {

			Swipe();
			lastMousePosition=Input.mousePosition;

				}

	
	}

	void Swipe()
	{

		while(Vector3.Distance(Input.mousePosition,lastMousePosition) > minSwipeDistance)
		{


			Debug.Log ("SWIPING");
		}
		swiping=false;



	}


}
