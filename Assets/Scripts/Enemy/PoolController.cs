using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour {
	public List<GameObject> prefabLevel = new List<GameObject> ();
    
    public float columnMin = -1f;
    public float columnMax = 2.5f;

    private Vector2 objectPoolPosition = new Vector2(-15f,-25f);



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
				SpawnObj (random,new Vector3(prefabLevel[currentLevel].transform.position.x+9.8f,Random.Range (columnMin,columnMax),1.74f));
			}
		}
		if(prefabLevel[currentLevel].transform.position.x<6f){
			LevelisLoaded = false;
		}
	}
}
