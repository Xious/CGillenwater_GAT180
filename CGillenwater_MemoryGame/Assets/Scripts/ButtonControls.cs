using UnityEngine;
using System.Collections;

public class ButtonControls : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void onClickStart()
	{
		Application.LoadLevel ("Game_Scene");
	}

	public void onClickEnd()
	{
		Application.Quit ();
	}
}
