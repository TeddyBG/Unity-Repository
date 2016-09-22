using UnityEngine;
using System.Collections.Generic;

public class PrefabsPool : MonoBehaviour
{	
	public List<GameObject> prefabsPool;
	public GameObject prefab;
	public int capacity = 20;
	public static PrefabsPool instance;
	public bool willGrow = true;// if it's allowed to allocate more memory



	void Awake(){
		instance = this;
	}

	void Start(){
		prefabsPool = new List<GameObject> ();

		for (int i = 0; i < capacity; i++) {
			GameObject obj = (GameObject)Instantiate (prefab, Vector3.zero, Quaternion.identity);
			obj.SetActive (false);
			prefabsPool.Add (obj);
		}
	}

	public GameObject PopPrefab(Vector3 position, Vector3 target, bool isActive){
		for (int i = 0; i < capacity; i++) {
			if (!prefabsPool [i].activeInHierarchy) {
				prefabsPool [i].transform.position = position;

				//SetTarget (prefabsPool [i], target);
				prefabsPool [i].SetActive (isActive);

				return prefabsPool [i];

			}
		}

		// no available prefab in the pool scenario:
		if(willGrow){
			capacity++;
			GameObject obj = (GameObject)Instantiate (prefab, position, Quaternion.identity);

			obj.SetActive (isActive);
			prefabsPool.Add (obj);
			return obj;
		}
		return null;
	}

	public void PutBackInPool(GameObject obj){
		obj.SetActive (false);
	}


}


