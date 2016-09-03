using UnityEngine;
using System.Collections;

public class BuildRay : MonoBehaviour {

	public Transform setTransform {		
		set {
			if (parent == null)
				parent = value;
			else {
				target = value;
				if (target.Equals (parent))// если один и тот же объект то варриорс никуда не идут
					target = parent = null;
				else
				trigger = true;
			}
		}
	}
	public bool trigger = false;
	public Transform parent { get; private set; }
	public Transform target{ get; private set; }
	void Start () {
		SetNull ();
	}
	
	// Update is called once per frame
	void Update () {
		if (trigger) {
			if (GameObject.Find("Controller").GetComponent<WarriorInstantiate>().
				InstantiateWarrior(parent.gameObject,target.gameObject))
			{
				/*StartCoroutine(Wait(0.2f, this.GetComponent<Renderer>().material.color));
				parent.gameObject.GetComponent<Renderer>().material.color = Color.yellow;*/

			}

			Debug.DrawLine (parent.position, target.position, 
				new Color(Random.value, Random.value, Random.value, 1.0f), 1);

		}
	}

	IEnumerator Wait(float sec, Color defaultColor)
	{
		yield return new WaitForSeconds(sec);
		parent.gameObject.GetComponent<Renderer>().material.color = defaultColor;
	}
	public void SetNull(){
		
		trigger = false;
	}
}
