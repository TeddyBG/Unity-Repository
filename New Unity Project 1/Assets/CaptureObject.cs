
	using UnityEngine;
	using System;

	public class CaptureObject  : MonoBehaviour {

		public Transform usurper;
		public Transform target;

		// Update is called once per frame
		void Update () {
			if (Input.GetMouseButtonDown (0)) {			
				usurper = GetHitObject ();
				GameObject.Find ("Controller").GetComponent<BuildRay> ().usurper = usurper;
			}

			if (Input.GetMouseButtonUp (0)) {			

				try{	
					target = GetHitObject ();	
					if(usurper != null)
					{
						GameObject.Find ("Controller").GetComponent<BuildRay> ().target = target;
						Debug.DrawLine (usurper.position, target.position, Color.red, 5);	
						usurper= null;}
					else
						target = null;


				}catch(Exception e){
					print ("Error of type: " + e.Message);
					GameObject.Find ("Controller").GetComponent<BuildRay> ().SetNull ();

				}
			}
		}
		Transform GetHitObject(){
			RaycastHit hitInfo = new RaycastHit ();
			bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo);
			if (hit) {
				var hitobj = hitInfo.transform.gameObject;
				if (hitobj.tag != "Range")
					// if an area or any another item was choosen but not one with the tag Range
					throw new Exception ("An unpropper item was choosen, name: " + hitobj.name);
				print (hitInfo.transform.gameObject.name);
				return hitInfo.transform.parent;
			}

			return null;
		}
	}
