using UnityEngine;
using System.Collections;

public class RaycastTest : MonoBehaviour {

	public Transform parent;
	public Transform target;

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)) {			
			parent = GetHitObject ();
			GameObject.Find ("Controller").GetComponent<BuildRay> ().setTransform = parent;
		}

		if (Input.GetMouseButtonUp (1)) {			
			target = GetHitObject ();	
			GameObject.Find ("Controller").GetComponent<BuildRay> ().setTransform = target;

			Debug.DrawLine (parent.position, target.position, Color.red, 5);		
		}
	}
	Transform GetHitObject(){
		RaycastHit hitInfo  =new RaycastHit();
		bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition),out hitInfo);
		if (hit)
			return hitInfo.transform;
		
		return null;
	}
}
