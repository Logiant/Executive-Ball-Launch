using UnityEngine;
using System.Collections;

public class TitleScript : MonoBehaviour {

	public float sceneTime = 10; //seconds

	Vector3 originalPos;
	Quaternion originalRot;
	float time;
	float reverseTween = 0.1f;

	void Start() {
		time = sceneTime; //set the scene time
		originalPos = transform.position; //store original position
		originalRot = transform.rotation; //store original rotation
		if (gameObject.tag.Equals ("Potato")) { //set potato's velocity to local Z
			rigidbody.velocity = originalRot*(new Vector3(0, 0, 5));
		}
	}
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime; //decrement time
		if (time < 0) { //reset the blocks
			transform.position = (transform.position + (originalPos - transform.position) * reverseTween * Time.deltaTime*5);
			transform.rotation = Quaternion.Slerp (transform.rotation, originalRot, Time.deltaTime*reverseTween*5);
			rigidbody.isKinematic = true;
			if (time < -sceneTime) {
				rigidbody.isKinematic = false;
		//		transform.position = originalPos;
		//		transform.rotation = originalRot;
				rigidbody.velocity = Vector3.zero;
				if (gameObject.tag.Equals ("Potato")) {
					rigidbody.velocity = originalRot*(new Vector3(0, 0, 5));
				}
				rigidbody.isKinematic = false;
				time = sceneTime;
			}
		}
	}
}
