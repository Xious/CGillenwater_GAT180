using UnityEngine;
using System.Collections;


public class TiltManager : MonoBehaviour {

	public GameObject ball; 
	public GameObject end;
	public GameObject start;
	public AudioClip music;
	public Rect playAgin = new Rect(Screen.width/2,Screen.height/2,0,0);
	public Camera mainCamera;
	// Use this for initialization
	void Start () {
		//WaitForSeconds(2);
		ball.transform.position = start.transform.position;
		mainCamera.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
						float dist = Vector3.Distance (ball.transform.position, end.transform.position);


						if (dist <.7f) 
						{
							win ();
						}

						if (ball.transform.position.y <= -10 || ball.transform.position.y >= 5) {
								reset ();
						}
				

	}

	void win()
	{
		//yield return new WaitForSeconds(2);

		//ball.transform.RotateAround(ball.transform.position,new Vector3(0,1,0), 15.0f);
		//ball.rigidbody.AddForce (0, 1000, 0);
		playMusic ();
		ball.transform.position = end.transform.position;
		if (Input.GetMouseButtonDown(0)) 
		{
			Application.LoadLevel (0);
		}
		//.ball.transform.Translate (new Vector3(0,0,1));

	}

	void reset()
	{
		if(Input.GetMouseButtonDown(0))
		{
			ball.transform.position = start.transform.position;
		}
	}

	private void playMusic()
	{
//		yield return WaitForSeconds (0);
		GetComponent<AudioSource>().PlayOneShot (music);
	}	
}
