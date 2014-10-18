using UnityEngine;
using System.Collections;

public class SpawnBall : MonoBehaviour {

	public GameObject ball; //ball prefab to launch
	public float maxSpeed = 25;
	public float minSpeed = 5;
	public GUIText text; //GUI text to display balls remaining

	CamScript camScript;
	float speed = 5; //current ball speed
	int ballsLeft = 5; //number of balls remaining
	bool charging = false;

	GameObject potato; //the current potato

	void Start() {
		camScript = Camera.main.GetComponent<CamScript> ();
	}

	// Update is called once per frame
	void Update () {
		if (ballsLeft > 0 && potato == null) { //if there is a ball left to launch, and not a current ball moving
			if (Input.GetMouseButton (0)) { //if the mouse button is down
				speed = (float)Mathf.Min (maxSpeed, speed + 0.5f); //increment the speed by 0.5 m/s, up to max speed
				charging = true;
			}
			else if (charging) { //if the mouse button is released
				potato = (GameObject)Instantiate (ball, transform.position, transform.rotation); //create a new ball
				potato.rigidbody.velocity = transform.rotation * new Vector3(0, 0, speed); //set the speed to forward and rotate it
				potato.rigidbody.angularVelocity = new Vector3(Random.Range (-8, 8), Random.Range (-8, 8), Random.Range (-8, 8));
				ballsLeft --; //decrement balls remaining
				speed = minSpeed; //reset speed
				charging = false;
				camScript.target = potato;
			}

		}
		text.text = "Spuds Remaining: " + ballsLeft; //update GUI text every update
		if (Input.GetMouseButton (0)) { 
			camScript.target = null;
		}
	}

	public float getSpeed() {
		return speed;
	}
}
