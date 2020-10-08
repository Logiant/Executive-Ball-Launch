﻿using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		if (transform.position.y < -5 || GetComponent<Rigidbody>().velocity.magnitude < 0.25) { //remove the ball if its Y position is less than -5
			Destroy (transform.gameObject);
		}
	}

}
