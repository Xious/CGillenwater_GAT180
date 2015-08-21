using UnityEngine;
using System.Collections;

public class LookAtMe : MonoBehaviour {

	public GameObject obj;

	void start()
	{
		transform.position = new Vector3(obj.transform.position.x,2,obj.transform.position.z);
	}
	//Transform stalker = GameObject.GetComponent<Transform>();
	// Update is called once per frame
	void Update () {
		Transform current = gameObject.transform;
		//transform.LookAt (obj.transform.position);
		//transform.RotateAround(obj.transform.position,new Vector3(0,1,0),obj.transform.rotation.z);
		transform.position = new Vector3 (obj.transform.position.x, 4.5f,obj.transform.position.z);
	}
}
