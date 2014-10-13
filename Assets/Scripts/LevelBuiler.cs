using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class LevelBuiler : MonoBehaviour {
	ArrayList levelPaths = new ArrayList();


	// Use this for initialization
	void Start () {

	}


	// reads in file from user and generates the level
	private bool load(string filepath){
		//levelPaths.Add (filepath);
		// next line in the file
		string line = "";
		// create file based on passed in filepath
		try{
			StreamReader reader = new StreamReader(filepath);
			while(line!=null){
				line = reader.ReadLine ();

			}
		}
		// handle file not found
		catch (FileNotFoundException fnf){
			print("File not found");
		}
		return true;
	}

}
