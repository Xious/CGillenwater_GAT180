using UnityEngine;
using System.Collections;

[AddComponentMenu("Utilities/Flickering Light")]
public class NewLightFlicker : MonoBehaviour 
{
	public float cycleDuration = 2f;
	public int keysCount = 10;
	public float startVal = 1f;
	public float randMin = 1f, randMax = 1f;
	public float flickerIntensity = 1f;
	public Light myLight;

	private AnimationCurve curve;

	private IEnumerator Start()
	{
		ResampleKeys ();
		while (Application.isPlaying) 
		{
			float t = 0f;
			float cycleInv = 1f / cycleDuration;
			while(t < 1f)
			{
				myLight.intensity = startVal + curve.Evaluate(t) * flickerIntensity;

				yield return null;

				t += Time.deltaTime * cycleInv;
			}
		
		}
	}

	public void ResampleKeys()
	{
		keysCount = Mathf.Max (keysCount, 2);

		Keyframe[] keys = new Keyframe[keysCount];
		float inv = 1f / (keysCount - 1);
		for (int i = 0; i < keysCount; i++) 
		{
			keys[i] = new Keyframe(i * inv, Random.Range(randMin, randMax));
		}

		float firstVal = keys [0].value;
		float lastVal = keys [keys.Length - 1].value;
		float middle = (firstVal + lastVal) * .5f;
		keys [0].value = middle;
		keys [keys.Length - 1].value = middle;

		curve = new AnimationCurve (keys);
	}
}
