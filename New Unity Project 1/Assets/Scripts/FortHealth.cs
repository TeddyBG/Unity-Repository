using UnityEngine;
using System.Collections;

public class FortHealth : MonoBehaviour {
 
	public GameObject[] targets;
	Camera camera;
	Vector3[] positions;
	void Start() {
		


		targets = GameObject.FindGameObjectsWithTag ("Range");
		positions = new Vector3[targets.Length];
		//targets.AddRange (GameObject.FindGameObjectsWithTag ("Blues"));
		//targets.AddRange (GameObject.FindGameObjectsWithTag ("Greens"));

		camera = GetComponent<Camera>();
	}
	
	void Update() {
		for(int i = 0; i < positions.Length; i++)
			positions[i] =  camera.WorldToScreenPoint (targets[i].transform.position);
		//Debug.Log("target is " + screenPos.x + " pixels from the left");

	}

	void OnGUI(){
		//WarriorInstantiate wi = GameObject.Find("Contoller").GetComponent<WarriorInstantiate>();
		GUIStyle style = new GUIStyle();
		style.normal.textColor = Color.black;
		for (int i = 0; i < positions.Length; i++) {
			GUI.Label (new Rect (Screen.width - positions[i].x+20, 
				Screen.height - positions[i].y+20,
				100, 50), 

				"Health: " + targets[i].transform.parent.GetComponent<change>().health.ToString(), 
				style);
		}
	}
}
