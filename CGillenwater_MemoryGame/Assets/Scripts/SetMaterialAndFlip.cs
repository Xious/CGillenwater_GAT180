using UnityEngine;
using System.Collections;


public class SetMaterialAndFlip : MonoBehaviour
{
		
	private int materialIndex = -1;
	// Use this for initialization
	public void Start ()
	{
		FaceDown ();
	}
		
	public void SetMaterial (Material m, int index)
	{
		MeshRenderer cardRender = transform.FindChild ("Card_Prefab_Front").GetComponentInChildren<MeshRenderer> ();
		cardRender.material = m;
		materialIndex = index; 
	}
		
	public void FaceUp ()
	{
		transform.rotation = Quaternion.Euler (0.0f, -180.0f, 0.0f);
	}
		
	public void FaceDown ()
	{
		transform.rotation = Quaternion.Euler (0.0f, 360.0f, 180.0f);
	}
		
	public int GetMaterialIndex ()
	{
		return materialIndex;
	}
}
