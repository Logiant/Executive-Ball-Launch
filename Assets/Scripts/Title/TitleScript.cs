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
			GetComponent<Rigidbody>().velocity = originalRot*(new Vector3(0, 0, 5));
		}
	}
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime; //decrement time
		if (time < 0) { //reset the blocks
			transform.position = (transform.position + (originalPos - transform.position) * reverseTween * Time.deltaTime*5);
			transform.rotation = Quaternion.Slerp (transform.rotation, originalRot, Time.deltaTime*reverseTween*5);
			GetComponent<Rigidbody>().isKinematic = true;
			if (time < -sceneTime) {
				GetComponent<Rigidbody>().isKinematic = false;
		//		transform.position = originalPos;
		//		transform.rotation = originalRot;
				GetComponent<Rigidbody>().velocity = Vector3.zero;
				if (gameObject.tag.Equals ("Potato")) {
					GetComponent<Rigidbody>().velocity = originalRot*(new Vector3(0, 0, 5));
				}
				GetComponent<Rigidbody>().isKinematic = false;
				time = sceneTime;
			}
		}
	}
}
