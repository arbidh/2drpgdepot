using UnityEngine;
using System.Collections;

public class mobileSwipe : MonoBehaviour {

	
	

		Vector2 initTouchPos;

		
		
		// Use this for initialization
		void Start ()
		{

		}
		
		// Update is called once per frame
		void Update ()
		{
				int fingerCount = 0;
		Touch touch = Input.touches [0];
		initTouchPos = touch.position;
			
	
				
						if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
								fingerCount++;
					
								if (fingerCount == 1 && touch.phase == TouchPhase.Began) {
										Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
										RaycastHit hit;
						
										if (Physics.Raycast (ray, out hit)) {
												if (hit.transform.tag == "enemy") {
														Debug.Log ("HIT");
												}
										}
								}
					
								if (fingerCount == 1 && touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended) {
										Vector2 touchFacing = (initTouchPos - touch.position).normalized;
						
										if (Vector2.Dot (touchFacing, Vector2.up) > 0.8 && Vector2.Distance (initTouchPos, touch.position) > 20) {
												Ability ("SwipeDown");
										}
										if (Vector2.Dot (touchFacing, -Vector2.up) > 0.8 && Vector2.Distance (initTouchPos, touch.position) > 20) {
												Ability ("SwipeUp");
										}
										if (Vector2.Dot (touchFacing, Vector2.right) > 0.8 && Vector2.Distance (initTouchPos, touch.position) > 20) {
												Ability ("SwipeLeft");
										}
										if (Vector2.Dot (touchFacing, -Vector2.right) > 0.8 && Vector2.Distance (initTouchPos, touch.position) > 20) {
												Ability ("SwipeRight");
										}
								}
						}
				}
		
		
		void Ability(string swipeType)
		{
			switch(swipeType)
			{
				
			case "SwipeUp":
			

			Debug.Log("SWIPEUP");
				break;
			
			case "SwipeDown":
			
			Debug.Log("SWIPEDOWN");
				break;
			
			case "SwipeLeft":
			
			Debug.Log("SWIPELEFT");
				
				break;
			
			case "SwipeRight":
			
			Debug.Log("SWIPERIGHT");
				
				break;
			
			default:
			
				Debug.Log("Ability string not found");
				break;
			
				
			}
		}
	
	}



