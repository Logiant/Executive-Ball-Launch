using UnityEngine;
using System.Collections;

public class CamScript : MonoBehaviour {

	public GameObject target; //potato to follow
	public Transform origin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) { //if there is a potato to follow
			float scale = 0.25f;
			Vector3 followSpot = new Vector3(0, 3 + transform.position.z*scale/2.5f, -6 - transform.position.z * scale);
			transform.position = target.transform.position + followSpot;
			transform.LookAt (target.transform.position);
		} else { //go to the origin position
			transform.position = origin.position;
			transform.rotation = origin.rotation;
		}
	}
}
