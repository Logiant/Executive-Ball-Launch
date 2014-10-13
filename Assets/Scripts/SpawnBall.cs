using UnityEngine;
using System.Collections;

public class SpawnBall : MonoBehaviour {

	public GameObject ball; //ball prefab to launch
	public float maxSpeed = 25;
	public float minSpeed = 5;
	public GUIText text; //GUI text to display balls remaining

	float speed = 5; //current ball speed
	int ballsLeft = 5; //number of balls remaining

	// Update is called once per frame
	void FixedUpdate () {
		bool release = false; //true when the ball is launched
		if (ballsLeft > 0) {
			if (Input.GetMouseButton (0)) { //if the mouse button is down
				speed = (float)Mathf.Min (maxSpeed, speed + 0.5f); //increment the speed by 0.5 m/s, up to max speed
			}
			if (Input.GetMouseButtonUp (0)) { //if the mouse button is released
				GameObject newBall = (GameObject)Instantiate (ball, transform.position, transform.rotation); //create a new ball
				newBall.rigidbody.velocity = transform.rotation * new Vector3(0, 0, speed); //set the speed to forward and rotate it
				ballsLeft --; //decrement balls remaining
				speed = minSpeed; //reset speed
				release = true; //the mouse was released
			}
			if (release) { //ensure nothing weird freezes our speed
				speed = minSpeed; //reset speed
			}
		}
		text.text = "Balls Left: " + ballsLeft; //update GUI text every update
	}

	public float getSpeed() {
		return speed;
	}
}
