using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public bool win = false;
	public bool loss = false;
	public LevelBuiler builder;
	public int numLevels;
	public SpawnBall spawner;

	void OnGUI() {
		//Debug.Log ("win: " + win + " loss: " + loss);
		if (win) {
			winGUI();
		} else if (loss) {
			loseGUI ();
		}

	}

	void winGUI() {
		spawner.launchable = false;
		GUI.BeginGroup (new Rect (Screen.width / 2 - 150, 50, 300, Screen.height - 75));
		//background box
		GUI.Box (new Rect(0, 0, 300, Screen.height - 75), "Spud Shot");
		//buttons
		
		GUI.Label (new Rect (0, 50, 250, 50), "You win!");
		string currentLevel = builder.currentLevel;
		string nextLevel = currentLevel.Substring (0, currentLevel.Length - 1);
		int last = int.Parse(currentLevel.Substring (currentLevel.Length - 1));
		if (last < numLevels) {
			if (GUI.Button (new Rect (55, 100, 180, 40), "Next Level")) {
				nextLevel += "" + (last + 1);
				GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
				GameObject[] wins = GameObject.FindGameObjectsWithTag("Win");
				for(int i = 0; i < blocks.Length; i++){
					Destroy(blocks[i]);
				}
				for(int i = 0; i < wins.Length; i++){
					Destroy (wins[i]);
				}

				spawner.ballsLeft = 5;
				spawner.launchable = true;
				builder.hasWin = false;
				Destroy (spawner.win);
				builder.load (nextLevel);
				win = false;

			}
		}
		if (GUI.Button (new Rect (55, 200, 180, 41), "Menu")) {
			win = false;
			Application.LoadLevel ("TitleScene");
		}
		if (GUI.Button (new Rect(55, 300, 180, 41), "Exit")) {
			win = false;
			Application.Quit ();
		}
		
		//end the GUI
		GUI.EndGroup();
	}

	void loseGUI() {
		spawner.launchable = false;
		GUI.BeginGroup (new Rect (Screen.width / 2 - 150, 50, 300, Screen.height - 75));
		//background box
		GUI.Box (new Rect(0, 0, 300, Screen.height - 75), "Spud Shot");
		//buttons
		
		GUI.Label (new Rect (0, 50, 250, 50), "You lose");

		if (GUI.Button (new Rect(55, 100, 180, 40), "Replay")) {
			Destroy (spawner.win);
			GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
			GameObject[] wins = GameObject.FindGameObjectsWithTag("Win");
			for(int i = 0; i < blocks.Length; i++){
				Destroy(blocks[i]);
			}
			for(int i = 0; i < wins.Length; i++){
				Destroy (wins[i]);
				Debug.Log ("destory win");
			}
			
			spawner.ballsLeft = 5;
			spawner.launchable = true;
			builder.hasWin = false;
			builder.load (builder.currentLevel);
			loss = false;

		}
		if (GUI.Button (new Rect(55, 200, 180, 40), "Menu")) {
			loss = false;
			Application.LoadLevel ("TitleScene");
		}
		if (GUI.Button (new Rect(55, 300, 180, 41), "Exit")) {
			loss = false;
			Application.Quit ();
		}
		
		//end the GUI
		GUI.EndGroup();
	}
}
