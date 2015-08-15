using UnityEngine;
using System.Collections;

public class ClassManager : MonoBehaviour 
{
	public Material[] materialList;
	public GameObject MatchCard;
	
	private SetMaterialAndFlip currentCard = null;
	private bool blockInput = false;
	private SetMaterialAndFlip [] cards;
	private int matchCount;
	public AudioClip[] sounds;
	
	// Use this for initialization
	public void Start () {
		
		cards = new SetMaterialAndFlip[20];
		matchCount = 0;
		
		
		cards[0] = (Instantiate(MatchCard,new Vector3(-3,4,-1),Quaternion.identity) as GameObject).GetComponent<SetMaterialAndFlip>();
		cards[1] = (Instantiate(MatchCard,new Vector3(-1,4,-1),Quaternion.identity) as GameObject).GetComponent<SetMaterialAndFlip>();
		cards[2] = (Instantiate(MatchCard,new Vector3(1,4,-1),Quaternion.identity) as GameObject).GetComponent<SetMaterialAndFlip>();
		cards[3] = (Instantiate(MatchCard,new Vector3(3,4,-1),Quaternion.identity) as GameObject).GetComponent<SetMaterialAndFlip>();
		cards[4] = (Instantiate(MatchCard,new Vector3(-3,2,-1),Quaternion.identity) as GameObject).GetComponent<SetMaterialAndFlip>();
		cards[5] = (Instantiate(MatchCard,new Vector3(-1,2,-1),Quaternion.identity) as GameObject).GetComponent<SetMaterialAndFlip>();
		cards[6] = (Instantiate(MatchCard,new Vector3(1,2,-1),Quaternion.identity) as GameObject).GetComponent<SetMaterialAndFlip>();
		cards[7] = (Instantiate(MatchCard,new Vector3(3,2,-1),Quaternion.identity) as GameObject).GetComponent<SetMaterialAndFlip>();
		cards[8] = (Instantiate(MatchCard,new Vector3(-3,0,-1),Quaternion.identity) as GameObject).GetComponent<SetMaterialAndFlip>();
		cards[9] = (Instantiate(MatchCard,new Vector3(-1,0,-1),Quaternion.identity) as GameObject).GetComponent<SetMaterialAndFlip>();
		cards[10] = (Instantiate(MatchCard,new Vector3(1,0,-1),Quaternion.identity) as GameObject).GetComponent<SetMaterialAndFlip>();
		cards[11] = (Instantiate(MatchCard,new Vector3(3,0,-1),Quaternion.identity) as GameObject).GetComponent<SetMaterialAndFlip>();
		cards[12] = (Instantiate(MatchCard,new Vector3(-3,-2,-1),Quaternion.identity) as GameObject).GetComponent<SetMaterialAndFlip>();
		cards[13] = (Instantiate(MatchCard,new Vector3(-1,-2,-1),Quaternion.identity) as GameObject).GetComponent<SetMaterialAndFlip>();
		cards[14] = (Instantiate(MatchCard,new Vector3(1,-2,-1),Quaternion.identity) as GameObject).GetComponent<SetMaterialAndFlip>();
		cards[15] = (Instantiate(MatchCard,new Vector3(3,-2,-1),Quaternion.identity) as GameObject).GetComponent<SetMaterialAndFlip>();
		cards[16] = (Instantiate(MatchCard,new Vector3(-3,-4,-1),Quaternion.identity) as GameObject).GetComponent<SetMaterialAndFlip>();
		cards[17] = (Instantiate(MatchCard,new Vector3(-1,-4,-1),Quaternion.identity) as GameObject).GetComponent<SetMaterialAndFlip>();
		cards[18] = (Instantiate(MatchCard,new Vector3(1,-4,-1),Quaternion.identity) as GameObject).GetComponent<SetMaterialAndFlip>();
		cards[19] = (Instantiate(MatchCard,new Vector3(3,-4,-1),Quaternion.identity) as GameObject).GetComponent<SetMaterialAndFlip>();
		
		cards[0].SetMaterial(materialList[0],0);
		cards[1].SetMaterial(materialList[1],1);
		cards[2].SetMaterial(materialList[2],2);
		cards[3].SetMaterial(materialList[3],3);
		cards[4].SetMaterial(materialList[4],4);
		cards[5].SetMaterial(materialList[5],5);
		
		cards[6].SetMaterial(materialList[6],6);
		cards[7].SetMaterial(materialList[7],7);
		cards[8].SetMaterial(materialList[8],8);
		cards[9].SetMaterial(materialList[9],9);
		cards[10].SetMaterial(materialList[7],7);
		cards[11].SetMaterial(materialList[4],4);
		
		cards[12].SetMaterial(materialList[2],2);
		cards[13].SetMaterial(materialList[8],8);
		cards[14].SetMaterial(materialList[5],5);
		cards[15].SetMaterial(materialList[1],1);
		cards[16].SetMaterial(materialList[0],0);
		cards[17].SetMaterial(materialList[6],6);
		
		cards[18].SetMaterial(materialList[3],3);
		cards[19].SetMaterial(materialList[9],9);
		
		
		
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0) && !blockInput) 
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			if(Physics.Raycast (ray,out hit, 200))
			{
				GameObject hitObject = hit.collider.gameObject.transform.parent.gameObject;
				SetMaterialAndFlip m = hitObject.GetComponent<SetMaterialAndFlip>();
				if(m)
				{
					m.FaceUp();
					GetComponent<AudioSource> ().clip = sounds [3];
					GetComponent<AudioSource> ().Play ();
					if(currentCard == null)
					{
						currentCard = m;
					}
					
					else if(currentCard != m)
					{
						blockInput = true;
						if(currentCard.GetMaterialIndex() == m.GetMaterialIndex())
						{
							StartCoroutine(MatchFound(currentCard,m));
						}
						
						else
						{
							StartCoroutine(FailedMatch(currentCard,m));
						}
					}
				}
			}
		}

		if (matchCount == 10) 
		{
			GetComponent<AudioSource> ().clip = sounds [0];
			GetComponent<AudioSource> ().Play ();
			StartCoroutine(RestartGame());
		}
	}
	
	private IEnumerator MatchFound(SetMaterialAndFlip m1, SetMaterialAndFlip m2)
	{
		GetComponent<AudioSource> ().clip = sounds [2];
		GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds(2);
		
		Destroy (m1.gameObject);
		Destroy (m2.gameObject);
		matchCount++;
		
		currentCard = null;
		blockInput = false;


	}
	
	private IEnumerator FailedMatch(SetMaterialAndFlip m1, SetMaterialAndFlip m2)
	{
		GetComponent<AudioSource> ().clip = sounds [1];
		GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds(2);
		m1.FaceDown ();
		m2.FaceDown ();
		
		currentCard = null;
		blockInput = false;
	}

	private IEnumerator RestartGame()
	{
		yield return new WaitForSeconds(3);
		Application.LoadLevel ("Game_Scene");
	}
}
