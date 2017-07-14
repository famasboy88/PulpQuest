using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour {
	public List<GameObject> prefabLevel = new List<GameObject> ();
    
	public float columnMin = -1.5f;
	public float columnMax = 1f;
	private Vector2 objectPoolPosition = new Vector2(-15f,-25f);




	// Special coin properties

	public float SC_XPosMin;
	public float SC_XPosMax;

	public float SC_YPosMin;
	public float SC_YPosMax;

	public GameObject SC;
	private bool SCisLoaded =false;



	//////////////////////////////
	private int currentLevel;
	private bool LevelisLoaded = false;


	// Use this for initialization
	void Start () {
		Object[] ListOfPrefabs = Resources.LoadAll ("NormalLevelPrefabs", typeof(GameObject));

		foreach(GameObject objList in ListOfPrefabs){
			GameObject myObj = Instantiate (objList) as GameObject;
			myObj.transform.position = objectPoolPosition;
			myObj.AddComponent <platformChecker>();
			myObj.SetActive (false);
			prefabLevel.Add (myObj);
		}

		SC = Instantiate(SC, objectPoolPosition,Quaternion.identity);
			
		SpawnObj (0,new Vector3 (9.8f,1.13f,1.74f));

	}

	private void SpawnObj(int num,Vector3 spawnPosition){
		if(LevelisLoaded==true){
		return;
		}else{
			prefabLevel [num].gameObject.transform.position = spawnPosition;
			LevelisLoaded = true;
			currentLevel = num;
			prefabLevel [num].gameObject.SetActive (true);
			prefabLevel [num].GetComponent <ScrollingController> ().StartMove ();
			foreach(Transform child in prefabLevel[num].transform){
				child.gameObject.SetActive (true);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(LevelisLoaded!=true){
			int random = Random.Range (0, prefabLevel.Count);
			if(random==currentLevel || prefabLevel[random].transform.position.x>-12f){
				random = Random.Range (0, prefabLevel.Count);
			}else{
				float range = Random.Range (columnMax, columnMin);
				SpawnObj (random,new Vector3(prefabLevel[currentLevel].transform.position.x+9.8f,range,1.74f));

				if(SCisLoaded!=true){
					spawnChance (random);
				}else{
					SCisLoaded = false;
				}
			}
		}
		if(prefabLevel[currentLevel].transform.position.x<6f){
			LevelisLoaded = false;
		}
		if(SC.transform.position.x<-12f){
			SCisLoaded = false;
		}
	}

	private void spawnChance(int num){
		SC.gameObject.SetActive (true);
		SC.GetComponent <ScrollingController>().StartMove ();
		SC.transform.position = prefabLevel[num].transform.position;
		SC.transform.position = new Vector3(SC.transform.position.x,SC.transform.position.y,1.74f);
		SCisLoaded = true;
	}
}
