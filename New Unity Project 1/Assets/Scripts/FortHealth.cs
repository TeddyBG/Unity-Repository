using UnityEngine;
using System.Collections;

public class FortHealth : MonoBehaviour {
 
	public Transform target;
	Camera camera;
	Vector3 screenPos;
	void Start() {
		camera = GetComponent<Camera>();
	}
	
	void Update() {
		screenPos = camera.WorldToScreenPoint(target.position);
		Debug.Log("target is " + screenPos.x + " pixels from the left");

	}

	void OnGUI(){
		//WarriorInstantiate wi = GameObject.Find("Contoller").GetComponent<WarriorInstantiate>();


		GUI.Label(new Rect(Screen.width - screenPos.x, 
		                   Screen.height - screenPos.y,
		                   100, 50), 
		          "Blue: " + "\n\rRed: "  );
	}
}
