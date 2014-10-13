using UnityEngine;
using System.Collections;

public class CannonMotion : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		//create an angle based on the mouse position. Mouse position goes from -1 to 1 in the x, and 0 to 1 in the Y
		//mouse angle is converted to -45 to 45 degrees in the X, and 45 to 90 degrees in the Y
		Vector2 angle = new Vector2 ((Input.mousePosition.x/Screen.width - 0.5f) * 90, (1-Input.mousePosition.y/Screen.height) * 45 + 45);
		transform.rotation = Quaternion.Euler (angle.y, angle.x, 0); //update the cannons angle to the new angle
	}
}
