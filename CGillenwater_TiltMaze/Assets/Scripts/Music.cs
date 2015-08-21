using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	public AudioClip music;
	// Use this for initialization
	void Start () {
		StartCoroutine (playMusic());
	}

	private IEnumerator playMusic()
	{
		yield return new WaitForSeconds (0);
		GetComponent<AudioSource>().PlayOneShot (music);
		StartCoroutine (playMusic());
	}

}
