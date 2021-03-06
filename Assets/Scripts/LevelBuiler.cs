﻿using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class LevelBuiler : MonoBehaviour {
	public GameObject stoneBlock;
	public GameObject woodBlock;
	public GameObject winBlock;
	public bool hasWin = false;
	public GameObject spawner;
	private SpawnBall spawn;
	public string currentLevel;


	// Use this for initialization
	void Start () {
		Debug.Log ("start");
		spawn = spawner.GetComponent<SpawnBall> ();
		Debug.Log ("started");
		load (ApplicationModel.level); // expecting a FileNotFound Exception here
	}


	// reads in file from user and generates the level
	public bool load(string filename){
		currentLevel = filename;
		string filepath = "Assets/Levels/"+filename+".txt";
		string line = ""; // next line in the file
		float[] data = new float[7];// {type,xCord,yCord,zCord,rot}
		/*string type = "";
		string xCord = "";
		string yCord = "";
		string zCord = "";
		string rot = "";*/
		int nextComma = 0;

		// create file based on passed in filepath
		try{
			StreamReader reader = new StreamReader(filepath); // read file
			bool isNull = false;
			while(!isNull){
				line = reader.ReadLine (); // get next line, will be null if no more lines exist
				if(line!=null){
					for(int i = 0; i < data.Length; i++){ // pares data out of line
						nextComma = line.IndexOf (',');
						if(nextComma!=-1){ // data is comma seperated
							data[i] = float.Parse(line.Substring(0,nextComma));
							line = line.Substring (nextComma+1);
						}else{
							data[i] = float.Parse(line); // get last value, will have no comma after
							createBlock (data);
						}
					}
				}else{
					isNull = true; // end of data
				}
			}
			if(!hasWin){
				float[] defaultWin = {0,0,1,50,90,90,0};
				createBlock (defaultWin);
			}
		}
		// handle file not found
		catch {
			Debug.Log("File not found");
		}
		return true;
	}

	private bool createBlock(float[] data){
		// data[0] is the type of the block, for now it is wood block
		Vector3 position = new Vector3 (data [1], data [2], data [3]); // create position vector of block
		GameObject obj;
		if (data [0] == 0.0 && !hasWin) { // select type of block
			obj = winBlock;
			hasWin = true;
		} else if (data [0] == 1.0) {
				obj = woodBlock;
		} else if (data [0] == 2.0) {
			obj = stoneBlock;
		} else {
			obj = woodBlock;
		}
		try{
			GameObject g = (GameObject)Instantiate (obj, position, Quaternion.Euler (data[4]+90,data[5]+90,data[6])); // instantiate block
			if(g.tag == "Win"){
				spawn.win = g.GetComponent<WinScript>();
				spawn.win.setInitPos(g);
			}
		}catch{
			Debug.Log("error building");
				}
		return true;
	}

}