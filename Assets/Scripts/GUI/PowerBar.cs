using UnityEngine;
using System.Collections;

public class PowerBar : MonoBehaviour {

	public Texture background;
	public Texture barColor;
	public GameObject cannon;

	public Vector2 pos = new Vector2(20,40);
	public Vector2 size = new Vector2(120,40);

	SpawnBall ballScript;
	// Use this for initialization
	void Start () {
		ballScript = cannon.GetComponent<SpawnBall> ();
	}
	
	// Update is called once per frame
	void OnGUI () {

		float percent = (ballScript.getSpeed() - ballScript.minSpeed)/(ballScript.maxSpeed - ballScript.minSpeed);

		//draw the background:
		GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), background);
		
		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, size.x * percent, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), barColor);
		GUI.EndGroup();
		GUI.EndGroup();
	}
}
