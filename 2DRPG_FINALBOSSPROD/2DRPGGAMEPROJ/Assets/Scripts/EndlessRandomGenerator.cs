using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EndlessRandomGenerator : MonoBehaviour {

	
	public Transform[] prefabs;
	public int numberOfObjects;
	private Vector3 nextPosition;
	public Transform Player;
	private Vector2 playersPrevPos;

	public float minOffsetX;
	public float maxOffsetX;
	public float minOffsetY;
	public float maxOffsetY;

	
	private float numberObjects = 0;


	public void  CreateRandomLocation( )
	{

		for(int i=0; i< numberOfObjects; i++)
		{

			Vector3 nexPos = new Vector3(Random.Range(Player.position.x, playersPrevPos.x+5),Player.position.y ,0);
	
			nextPosition += new Vector3(
								Random.Range(prefabs[i].localScale.x+minOffsetX,prefabs[i].localScale.x + maxOffsetX), 
								Random.Range(prefabs[i].localScale.y+ minOffsetY,prefabs[i].localScale.y+ maxOffsetY),0);
		GameObject clone	=(GameObject)(Instantiate(prefabs[i],nextPosition,prefabs[i].rotation)) as GameObject;
			GameObject.Destroy(clone,1.0f);


		}



	}
	

	
	void Update () {
				playersPrevPos = Player.position;
				CreateRandomLocation();

	
		}

}
