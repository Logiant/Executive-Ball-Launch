using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour {
	public bool win;
	public Vector3 initPos;
	// Use this for initialization
	void Start () {
		win = false;
		initPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dif = initPos - transform.position;
		if (dif.magnitude > .75) {
			win = true;
			//Debug.Log ("win");
				}
	}
}
