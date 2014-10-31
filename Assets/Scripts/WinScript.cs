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
		if (transform.position == initPos) {
			win = true;
				}
	}
}
