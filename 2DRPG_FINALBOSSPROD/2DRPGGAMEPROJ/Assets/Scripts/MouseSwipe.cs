using UnityEngine; 
using System.Collections;

public class MouseSwipe : MonoBehaviour {


	public Vector2 pressPosition;
	Vector2 swipePosition;
	Vector3 trailPosition;
	public Vector2 startPosition;
	private TrailRenderer lineRender;
	public ArrayList list= new ArrayList();
	public Material mat;



	// Use this for initialization
	void Start () {
		lineRender = transform.GetComponent<TrailRenderer>();
		lineRender.enabled = false;


	}

	void OnDrag()
	{
		Debug.Log ("dragging");
		
	}
	
	// Update is called once per frame
	void Update () {
//		lineRender.SetVertexCount (list.Count);
//
//		for (int i=0; i<list.Count; i++) 
//		{
//			lineRender.material=mat;
//			lineRender.SetWidth(4,3);
//              
//			lineRender.SetPosition(i,(Vector3)list[i]);
//
//
//				}
		if(GUIUtility.hotControl == 0){
		if (Input.GetMouseButtonDown(0))
		{
			startPosition = Input.mousePosition;
		}
		
		if (Input.GetMouseButton (0)){
			pressPosition = Input.mousePosition;
		
			swipePosition = (Vector2)Input.mousePosition - pressPosition;
			trailPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x - swipePosition.x, Input.mousePosition.y - swipePosition.y, 0));
			//Debug.Log(swipePosition+","+swipePosition.normalized);

			lineRender.enabled=true;
			lineRender.sortingLayerName = "Foreground";
			lineRender.sortingOrder = 2;
			

			lineRender.startWidth=0.3f;
			lineRender.endWidth=0.1f;
			lineRender.time=0.2f;


			lineRender.material=mat;
			lineRender.transform.position= new Vector3(trailPosition.x,trailPosition.y,0);


			if(pressPosition.x > startPosition.x || pressPosition.x < startPosition.x ){
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

				if(hit.collider.tag == "Enemy")
				{
					Destroy(hit.collider.gameObject);
				}

				print ("I hit: " + hit.collider.tag);
			}
			}

		}


		if (Input.GetMouseButtonUp(0))
		{
			lineRender.enabled=false;
		}


	
	}


}

