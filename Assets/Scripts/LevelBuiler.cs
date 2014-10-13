using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class LevelBuiler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	// next line in the file
	string line = "";

	// reads in file from user and generates the level
	private bool load(string filename){

		// create file based on passed in filepath
		try{
		File levelFile = new File(filename);
		}
		// handle file not found
		catch (FileNotFoundException fnf){
			print("File not found");
		}
	}

}
