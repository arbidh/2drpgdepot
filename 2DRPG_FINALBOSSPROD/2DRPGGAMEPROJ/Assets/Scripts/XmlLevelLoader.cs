using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System;


public class XmlLevelLoader : MonoBehaviour {







	public static int [,] xmlArray =  new int[25,25];
	GameObject newBlock;
	int a,b, rows;
	float xPos, yPos;
	public GameObject platformPrefab;
	public GameObject playerPrefab;
	public GameObject enemiesPrefab;
	public GameObject wallPrefab;
	private string _FileLocation;
	private string _FileName;

	public GameObject  checkPoint, exitBlock;
	public Transform LevelParent;
	public string levelName;
	public string filePath;
	public TextAsset assets;
	private EndlessRandomGenerator gen;

void Awake()
	{

		gen = new EndlessRandomGenerator ();


		}
	// Use this for initialization
	void Start () {


		_FileLocation = Application.dataPath+"/";
		_FileName = "hello.xml";
		Debug.Log ("START");

	   //load my document

		XmlDocument reader = XmlToolsPro.inputXML (_FileLocation, _FileName);
			

			//XmlDocument reader = XmlToolsPro.inpu
		
	
		  
		
						//Debug.Log (" I AM NOT NULL");
					//	reader.LoadXml (asset.text);

//						var textReader = new XmlTextReader (asset.text);
//						while (textReader.Read()) {
//								if (reader.Name == "level") {
//										Debug.Log (textReader.Name + " Label = " + textReader.GetAttribute ("level"));
//								}
						

						
		var level = reader.FirstChild;
		if (level.Name != "level") {
			Debug.Log("NOTVALID");
				}
		else{
			levelName = level.Attributes[0].Value;
			rows = int.Parse(level.Attributes[1].Value);
			for(int i =0; i<level.ChildNodes.Count; i++)
			{

				var item = level.ChildNodes.Item(i);
				switch(item.Name)
				{
				case "blocks":
					var row = item.InnerText.Split(";"[0]);
					for(int z =0; z < row.Length; z++)
					{
						var blocks = row[z].Split(","[0]);
						for(int q=0; q<blocks.Length; q++)
						{
							xmlArray[z,q]=int.Parse(blocks[q]);
						}

					}
					break;



				}




			}






	

		//filePath = Path.Combine(Application.dataPath, "test.xml");




		}
		ShowLevel ();

	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void ShowLevel (){
		Vector3 pos = Camera.main.ScreenToWorldPoint (LevelParent.transform.position);
		yPos = pos.y;
		xPos = pos.x;
		for(a=(int)xPos; a < 1000; a++){
			for(b =(int) yPos; b < 100; b++){
				switch (xmlArray[a,b]){
				case 999:
					// Exit block
					newBlock = (GameObject) Instantiate(exitBlock,new Vector2(xPos,yPos), Quaternion.identity);
					newBlock.transform.parent = LevelParent;
					break;
				case 4:


					//Platform block
					float test = UnityEngine.Random.Range(playerPrefab.transform.position.x, playerPrefab.transform.position.x + 5);
					Vector3 nexPos = new Vector3(test,playerPrefab.transform.position.y ,0);
					newBlock = (GameObject) Instantiate(platformPrefab,new Vector2(nexPos.x,nexPos.y), Quaternion.identity);
					newBlock.transform.parent = LevelParent;
					break;
				case 3:
					//Player
					newBlock = (GameObject) Instantiate(playerPrefab,new Vector2(xPos,yPos), Quaternion.identity);
					newBlock.transform.parent = LevelParent;
					//FollowPlayer.target = newBlock.transform;
				    
					break;
				case 2:
					//Wall block
					newBlock = (GameObject) Instantiate(wallPrefab,new Vector2(xPos,yPos), Quaternion.identity);
					newBlock.transform.parent = LevelParent;
					break;
				case 1:
					//Check Points
					newBlock = (GameObject) Instantiate(checkPoint,new Vector2(xPos,yPos), Quaternion.identity);
					newBlock.transform.parent = LevelParent;
					break;
				case 0:
					//Air block (empty)
					break;
				default:
					Debug.LogWarning ("Incorrect value: "+xmlArray[a,b]+", for blockArray variable at x="+a+" and y="+b);
					break;
				}
				xPos +=2f; // increase the x co-ordinate for the next object in the row                
			}
			xPos = 0f; // reset the x co-ord for the start of the next row in the grid
			yPos -=2f; // increment the y co-ordinate for the start of the next row in the grid
		}
	}

}
