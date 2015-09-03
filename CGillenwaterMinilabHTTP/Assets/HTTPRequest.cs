using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HTTPRequest : MonoBehaviour {

	// Use this for initialization
	// Outlet: http://www.reactgames.com/tyler/gat180.php
	private WWW www;
	public Text text;
	void Start () 
	{
		string StartingURL = "http://www.reactgames.com/tyler/gat180.php";
		www = new WWW (StartingURL);

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			StartCoroutine(waitForRequest(www));
		}
	}

	IEnumerator waitForRequest(WWW www)
	{
		yield return www;

		if (www.error == null) 
		{
			text.text = www.text;
			Debug.Log ("WWW ok!: " + www.text);
		} 
		else 
		{
			Debug.Log("WWW Error: " + www.error);
		}

	}
}
