using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {
	
	private float timeElapsed;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () 
	{
		timeElapsed += Time.deltaTime;

	}

	void OnGUI()
	{
		GUI.Label (new Rect (50, 50, 500, 500), "Time: ");
		GUI.Label (new Rect (100, 50, 500, 500), (timeElapsed.ToString ("f0")));
	}
}
