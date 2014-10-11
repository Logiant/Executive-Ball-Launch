using UnityEngine;
using System.Collections;

public class SpawnBall : MonoBehaviour {

	public GameObject ball;
	public float maxSpeed = 25;
	public float minSpeed = 5;
	public GUIText text;

	float speed = 5;
	int ballsLeft = 5;

	// Update is called once per frame
	void FixedUpdate () {
		bool release = false;
		if (ballsLeft > 0) {
			if (Input.GetMouseButton (0)) { //if the mouse button is down
				speed = (float)Mathf.Min (maxSpeed, speed + 0.5f);
			}
			if (Input.GetMouseButtonUp (0)) { //if the mouse button is released
				GameObject newBall = (GameObject)Instantiate (ball, transform.position, transform.rotation);
				newBall.rigidbody.velocity = transform.rotation * new Vector3(0, 0, speed);
				ballsLeft --;
				speed = minSpeed;
				release = true;
			}
			if (release) { //ensure nothing weird freezes our speed
				speed = minSpeed;
			}
		}
		text.text = "Balls Left: " + ballsLeft;
	}

	public float getSpeed() {
		return speed;
	}
}
