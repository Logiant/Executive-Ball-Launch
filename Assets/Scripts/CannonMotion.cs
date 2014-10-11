using UnityEngine;
using System.Collections;

public class CannonMotion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 angle = new Vector2 ((Input.mousePosition.x/Screen.width - 0.5f) * 90, (1-Input.mousePosition.y/Screen.height) * 45 + 45);
		transform.rotation = Quaternion.Euler (angle.y, angle.x, 0);
	}
}
