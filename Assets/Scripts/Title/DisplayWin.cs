using UnityEngine;
using System.Collections;

public class DisplayWin : MonoBehaviour {

	void OnGUI() {
		//start the layout
		GUI.BeginGroup (new Rect (Screen.width / 2 - 150, 50, 300, Screen.height - 75));
		//background box
		GUI.Box (new Rect(0, 0, 300, Screen.height - 75), "Spud Shot");
		//buttons

		GUI.TextArea (new Rect (0, 50, 250, 50), "You win!");
		if (GUI.Button (new Rect(55, 100, 180, 40), "Menu")) {
			//Application.TitleGUI().OnGUI();
		}
		if (GUI.Button (new Rect(55, 300, 180, 41), "Exit")) {
			Application.Quit ();
		}
		
		//end the GUI
		GUI.EndGroup();
	}
}
