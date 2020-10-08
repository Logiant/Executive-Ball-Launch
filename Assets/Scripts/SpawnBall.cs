﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnBall : MonoBehaviour {

	public GameObject ball; //ball prefab to launch
	public float maxSpeed = 25;
	public float minSpeed = 5;
	public Text text; //GUI text to display balls remaining
	public WinScript win;
	public GameOver over;
	public bool launchable;

	CamScript camScript;
	float speed = 5; //current ball speed
	public int ballsLeft = 5; //number of balls remaining
	bool charging = false;
	public ParticleSystem smoke;
	GameObject potato; //the current potato

	void Start() {
		launchable = true;
		camScript = Camera.main.GetComponent<CamScript> ();
	}

	// Update is called once per frame
	void Update () {
		if (launchable) {
						if (ballsLeft > 0 && potato == null) { //if there is a ball left to launch, and not a current ball moving
								if (win.win) {
										Debug.Log ("win");
										over.win = true;
								}
								if (Input.GetMouseButton (0)) { //if the mouse button is down
										speed = (float)Mathf.Min (maxSpeed, speed + 0.5f); //increment the speed by 0.5 m/s, up to max speed
										charging = true;
								} else if (charging) { //if the mouse button is released
										GetComponent<AudioSource>().Play ();
										smoke.Play ();
										potato = (GameObject)Instantiate (ball, transform.position, transform.rotation); //create a new ball
										potato.GetComponent<Rigidbody>().velocity = transform.rotation * new Vector3 (0, 0, speed); //set the speed to forward and rotate it
										potato.GetComponent<Rigidbody>().angularVelocity = new Vector3 (Random.Range (-8, 8), Random.Range (-8, 8), Random.Range (-8, 8));
										ballsLeft --; //decrement balls remaining
										speed = minSpeed; //reset speed
										charging = false;
										camScript.target = potato;
								}

						} else if (ballsLeft == 0 && potato == null) {
							Debug.Log ("out of balls");
								if (win.win) {
									Debug.Log ("win");
										//win
										over.win = true;
								} else {
										over.loss = true;
										// lose
								}
						}
						text.text = "Spuds Remaining: " + ballsLeft; //update GUI text every update
						if (Input.GetMouseButton (0)) { 
								camScript.target = null;
						}
				}
	}

	public float getSpeed() {
		return speed;
	}
}
