using UnityEngine;
using System.Collections;

public class WarriorMove : MonoBehaviour {

	public Transform target;
    //public GameObject parent;
	public float speed = 3;

    void Start()
    {
		target = GameObject.Find("Controller").GetComponent<BuildRay>().target.transform;
		GameObject.Find ("Controller").GetComponent<BuildRay> ().SetNull ();
		Debug.Log (target.name);
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
            Destroy(transform.gameObject);
        }
		
    }
    
}
