using UnityEngine;
using System.Collections;

public class WarriorInstantiate : MonoBehaviour
{
    public Transform warrior;
 
	public bool InstantiateWarrior(GameObject parent, GameObject target)
    {      
		if (parent.GetComponent<change> ().health > 0) {    
			if (parent.tag != target.tag)
				parent.GetComponent<change> ().health--;
			else
				parent.GetComponent<change> ().health++;


			var obj = PrefabsPool.instance.PopPrefab (parent.transform.position,
				target.transform.position, false);
			obj.GetComponent<change> ().target = target.transform;
			obj.SetActive (true);

			/*Instantiate (warrior.gameObject, parent.transform.position,
				Quaternion.identity);*/
			return true;
		} 
        return false;
    }

   
}
	