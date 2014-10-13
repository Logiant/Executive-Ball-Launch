using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class LevelBuiler : MonoBehaviour {



	// Use this for initialization
	void Start () {
		ArrayList levelPaths =  new ArrayList();
	}


	// reads in file from user and generates the level
	private bool load(string filepath){
		//levelPaths.Add (filepath);
		// next line in the file
		string line = "";
		// create file based on passed in filepath
		try{
			File levelFile = new File(filepath);
			StreamReader reader = new StreamReader(levelFile, Encoding.Default);
			while(line!=null){
				line = reader.ReadLine ();

			}
		}
		// handle file not found
		catch (FileNotFoundException fnf){
			print("File not found");
		}
	}

}
