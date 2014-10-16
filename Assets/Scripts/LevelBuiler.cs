using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class LevelBuiler : MonoBehaviour {
	ArrayList levelPaths = new ArrayList();


	// Use this for initialization
	void Start () {
		load ("Assets/level1.txt"); // expecting a FileNotFound Exception here
	}


	// reads in file from user and generates the level
	private bool load(string filepath){
		levelPaths.Add (filepath);

		string line = ""; // next line in the file
		string[] data = new string[5];// {type,xCord,yCord,zCord,rot}
		/*string type = "";
		string xCord = "";
		string yCord = "";
		string zCord = "";
		string rot = "";*/
		int nextComma = 0;

		// create file based on passed in filepath
		try{
			//var reader = File.OpenText(filepath);
			//string[] fileLines = reader.ReadToEnd().Split("\n"[0]);
			StreamReader reader = new StreamReader(filepath);
			bool isNull = false;
			while(!isNull){
				line = reader.ReadLine ();
				if(line!=null){
					Debug.Log(line);
					for(int i = 0; i < data.Length; i++){
						nextComma = line.IndexOf (',');
						if(nextComma!=-1){
							data[i] = line.Substring(0,nextComma);
							line = line.Substring (nextComma+1);
						}else{
							data[i] = line;
						}
						Debug.Log(""+data[i]);
					}
				}else{
					isNull = true;
				}
			}
		}
		// handle file not found
		catch {
			Debug.Log("File not found");
		}
		return true;
	}

}
