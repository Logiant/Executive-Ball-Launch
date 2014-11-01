using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour {
	public bool win;
	public Vector3 initPos;
	// Use this for initialization
	void Start () {
		Debug.Log ("new win");
		win = false;
		initPos = transform.position;
		Debug.Log ("INIT: "+initPos);
	}

	public void setInitPos(GameObject obj){
		initPos = obj.transform.position;
		win = false;
		}
	

	// Update is called once per frame
	void Update () {
		//Debug.Log (transform.position);
		Vector3 dif = initPos - transform.position;
		if (dif.magnitude > .75) {
			win = true;
			//Debug.Log ("win");
				}
	}
}
