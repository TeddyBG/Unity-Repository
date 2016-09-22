using UnityEngine;
using System.Collections;

public class WarriorMove : MonoBehaviour {

	public Transform target = null;
    //public GameObject parent;
	public float speed = 3;

    /*void Start()
    {
		target = GameObject.Find("Controller").GetComponent<BuildRay>().target.transform;
		GameObject.Find ("Controller").GetComponent<BuildRay> ().SetNull ();
		Debug.Log (target.name);
    }*/
	void OnEnable(){
		target = this.gameObject.GetComponent<change> ().target;
	}

    void Update()
    {        
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        //Debug.Log(target.name);
    }
    void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.name == target.name)
        {
            collide.gameObject.GetComponent<change>().health++;
			PrefabsPool.instance.PutBackInPool(transform.gameObject);
        }
		
    }

    
}
