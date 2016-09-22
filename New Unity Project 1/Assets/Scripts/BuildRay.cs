using UnityEngine;
using System.Collections;

public class BuildRay : MonoBehaviour {


	public bool trigger = false;
	public Transform usurper;
	public Transform target;
	void Start () {
		SetNull ();
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null ) {
			if (usurper == null)
				target = usurper = null;
			else
				trigger = true;
		}
		if (usurper == null)
			GameObject.Find ("Spotlight").GetComponent<Light> ().enabled = false;
		else {
			GameObject.Find ("Spotlight").GetComponent<Light> ().enabled = true;
			GameObject.Find ("Spotlight").transform.position = new Vector3 (usurper.transform.position.x,
				6f, usurper.transform.position.z);
		}
		if (trigger) {
			GameObject.Find ("Controller").GetComponent<WarriorInstantiate> ().
								InstantiateWarrior (usurper.gameObject, target.gameObject);


			Debug.DrawLine (usurper.position, target.position, 
				new Color (Random.value, Random.value, Random.value, 1.0f), 1);

			
			trigger = false;


		}
	}


	public void SetNull(){
		usurper = target = null;
		trigger = false;
	}
}
