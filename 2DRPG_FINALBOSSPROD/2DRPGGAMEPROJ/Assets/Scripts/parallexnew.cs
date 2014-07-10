using UnityEngine;
using System.Collections;

public class parallexnew : MonoBehaviour {

	public float Xpos;
	public bool followCamera;
	public float offset;
	private MeshRenderer rend;
	// Use this for initialization
	void Start () {

		Xpos = Camera.main.transform.position.x;
		GameObject d = GameObject.FindWithTag("fg");
		if (d != null) {
						rend = d.GetComponent<MeshRenderer> ();
						rend.sortingLayerName = "Foreground";
				}
	}
	
	// Update is called once per frame
	void Update () {

		if(followCamera)
			transform.position= new Vector3((Camera.main.transform.position.x -Xpos)/offset,transform.position.y,transform.position.z);
		else
			transform.position=new Vector3((Xpos - Camera.main.transform.position.x/offset),transform.position.y,transform.position.z);
	
	}
}
