using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {
	
	void OnGUI() {
		//start the layout
		GUI.BeginGroup (new Rect (Screen.width / 2 - 150, 50, 300, Screen.height - 75));
		//background box
		GUI.Box (new Rect(0, 0, 300, Screen.height - 75), "Spud Shot");
		//buttons
		if (GUI.Button (new Rect(55, 100, 180, 40), "Level 1")) {
			ApplicationModel.level = "level1";
			Application.LoadLevel ("LoadLevel");
		}
		if (GUI.Button (new Rect(55, 200, 180, 40), "Level 2")) {
			ApplicationModel.level = "level2";
			Application.LoadLevel ("LoadLevel");
		}
		if (GUI.Button (new Rect(55, 300, 180, 40), "Level 3")) {
			ApplicationModel.level = "level3";
			Application.LoadLevel ("LoadLevel");
		}
		if (GUI.Button (new Rect(55, 400, 180, 40), "Level 4")) {
			ApplicationModel.level = "level4";
			Application.LoadLevel ("LoadLevel");
		}
		if (GUI.Button (new Rect(55, 500, 180, 40), "Level 5")) {
			ApplicationModel.level = "level5";
			Application.LoadLevel ("LoadLevel");
		}
		if (GUI.Button (new Rect(55, 600, 180, 41), "Back")) {
			Application.LoadLevel ("TitleScene");
		}
		if (GUI.Button (new Rect(55, 700, 180, 41), "Exit")) {
			Application.Quit ();
		}
		
		//end the GUI
		GUI.EndGroup();
	}
}
