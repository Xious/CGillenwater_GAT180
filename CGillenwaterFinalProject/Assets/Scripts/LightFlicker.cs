using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

	private Light myLight;
	public float flickerSpeed = 0.07f;
	private float randomizer = 0;

	// Use this for initialization
	void Start () 
	{
		myLight = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (randomizer == 0) 
		{ 
			myLight.enabled = false;
		} 
		else 
		{
			myLight.enabled = true; 
			randomizer = Random.Range (0.1f, 3.5f);
		}

		StartCoroutine (waitForFlicker (flickerSpeed));
	}

	IEnumerator waitForFlicker(float timeToWait)
	{
		yield return new WaitForSeconds(timeToWait);
	}
}
