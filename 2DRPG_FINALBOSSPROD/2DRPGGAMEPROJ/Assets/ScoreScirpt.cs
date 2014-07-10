using UnityEngine;
using System.Collections;

public class ScoreScirpt : MonoBehaviour {

	public Sprite[] numbers;
	public Sprite scoreTexture;
	public Sprite multiplyTexture;

	private float score;
	private float multiplyer;
	public Transform player;
	public Vector2 startingPos;
	public float distance;

	// Use this for initialization
	void Start () {

		startingPos = player.transform.position;
	
	}

	void Update () {

		distance = Vector2.Distance(startingPos, player.transform.position);
		print (distance);
	
	}
}
