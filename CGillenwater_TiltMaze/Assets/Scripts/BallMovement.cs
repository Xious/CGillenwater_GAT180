using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {
	public int maxSpeed = 30;
	public float gyroThreshhold = .0000001f;


	// Update is called once per frame
	void Update () 
	{

	//	#if UNITY_EDITOR
	//	rigidbody.AddForce (new Vector3(1,0,0) * Input.GetAxis ("Horizontal") * maxSpeed);
	//	rigidbody.AddForce (new Vector3(0,0,1) * Input.GetAxis ("Vertical") * maxSpeed);

	//	#else

	
		if(Input.acceleration.x < -gyroThreshhold || Input.acceleration.x > gyroThreshhold)
		{
			GetComponent<Rigidbody>().AddForce (new Vector3(1,0,0) * Input.acceleration.x * maxSpeed);

		}
		if(Input.acceleration.y < -gyroThreshhold || Input.acceleration.y > gyroThreshhold)
		{
			GetComponent<Rigidbody>().AddForce (new Vector3(0,0,1) * Input.acceleration.y * maxSpeed);
		}
//#endif
	}

}
