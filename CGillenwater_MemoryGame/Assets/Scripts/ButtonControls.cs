using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonControls : MonoBehaviour {

	public void onClickStart()
	{	
		Application.LoadLevel ("Game_Scene");
	}

	public void onClickEnd()
	{
		Application.Quit ();
	}
}
