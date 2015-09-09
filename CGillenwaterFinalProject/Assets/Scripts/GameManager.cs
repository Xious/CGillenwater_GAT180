using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject player;
	public GameObject start;
	public GameObject endPoint;
	private bool paused;
	
	// Use this for initialization
	void Start () 
	{
		Cursor.visible = false;
		paused = false;
		Time.timeScale = 1;
		player.transform.position = start.transform.position;

	}
	
	// Update is called once per frame
	void Update () 
	{
		float dist = Vector3.Distance (player.transform.position, endPoint.transform.position);
		if (dist < 0.7f) 
		{
			OnTriggerEnter();
		}
	}

	void OnTriggerEnter()
	{
		if (!paused) 
		{
			paused = true;
			Time.timeScale = 0;
			Cursor.visible = true;
		}

	}

	void OnGUI()
	{
		if (paused) 
		{
			GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 250, 200), "You Win");
			
			if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 250, 50), "Main Menu"))
			{
				Application.LoadLevel (0);
			}
			
			if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 50, 250, 50), "Quit Game"))
			{
				Application.Quit();
			}
		}
	}
}
