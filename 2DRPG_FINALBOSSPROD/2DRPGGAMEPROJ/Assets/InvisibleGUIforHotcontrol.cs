using UnityEngine;
using System.Collections;

public class InvisibleGUIforHotcontrol : MonoBehaviour {

	public Texture2D invisibleTexture;
	public float xWidth;
	public GUISkin invisSkin;

	void OnGUI(){
		GUI.skin = invisSkin;
		if(GUI.Button(new Rect(0,0,Screen.width / xWidth, Screen.height), invisibleTexture))
		{
			print("Jump");
			print("Gui ID: " + GUIUtility.hotControl);
		}
	}

}
