using UnityEngine;
using System.Collections;

public class TitleGUI : MonoBehaviour {

	void OnGUI() {
		//start the layout
		GUI.BeginGroup (new Rect (Screen.width / 2 - 150, 50, 300, Screen.height - 75));
		//background box
		GUI.Box (new Rect(0, 0, 300, Screen.height - 75), "Spud Shot");
		//buttons
		if (GUI.Button (new Rect(55, 100, 180, 40), "Start")) {
			Application.LoadLevel ("LoadLevel");
		}
		if (GUI.Button (new Rect(55, 300, 180, 41), "Exit")) {
			Application.Quit ();
		}

		//end the GUI
		GUI.EndGroup();
	}
}
