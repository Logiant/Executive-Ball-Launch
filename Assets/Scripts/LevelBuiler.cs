using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class LevelBuiler : MonoBehaviour {
	public GameObject stoneBlock;
	public GameObject woodBlock;
	public GameObject winBlock;


	// Use this for initialization
	void Start () {
		load ("Assets/level1.txt"); // expecting a FileNotFound Exception here
	}


	// reads in file from user and generates the level
	private bool load(string filepath){

		string line = ""; // next line in the file
		float[] data = new float[5];// {type,xCord,yCord,zCord,rot}
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
		try{
			Quaternion rot = Quaternion.Euler (0,0,0);
			Debug.Log (""+data[4]);
			if(data[4] == 1.0){
				Debug.Log ("one");
				rot = Quaternion.Euler (90,0,0);
			}else if(data[4] == 2.0){
				rot = Quaternion.Euler (0,90,0);
			}
			Instantiate (woodBlock, position, rot); //Quaternion.Euler (data[4], 0, 0)); // instantiate block
		}catch{
			Debug.Log("error building");
				}
		return true;
	}

}