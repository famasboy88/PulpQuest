using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolControllerV2 : MonoBehaviour {
	public List<LevelModel> prefabLevel = new List<LevelModel> ();

	public float columnMin = -1f;
	public float columnMax = 3.5f;
	public float spawnRate = 4f;

	private float spawnXposition = 10f;
	private GameObject[] column;
	private Vector2 objectPoolPosition = new Vector2(-15f,-25f);
	private int currentColumn = 0;
	private float timeLastSpawned;

	//////////////////////////////
	private int randomLvl = 0;
	private int currentLevel;
	private int oldLevel;
	private bool LevelisLoaded = false;


	// Use this for initialization
	void Start () {
		Object[] ListOfPrefabs = Resources.LoadAll ("NormalLevelPrefabs", typeof(GameObject));

		foreach(GameObject objList in ListOfPrefabs){
			GameObject myObj = Instantiate (objList) as GameObject;
			myObj.transform.position = objectPoolPosition;
			prefabLevel.Add (new LevelModel(myObj));
		}


		SpawnObj (0,new Vector3 (9.8f,1.13f,1.74f));

	}

	private void SpawnObj(int num,Vector3 spawnPosition){
		if(LevelisLoaded==true){
			return;
		}else{
			prefabLevel [num].level.transform.position = spawnPosition;
			LevelisLoaded = true;
			currentLevel = num;
			prefabLevel [num].setIsActive_flag (true);
			foreach(Transform child in prefabLevel[num].level.transform){
				child.gameObject.SetActive (true);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if(LevelisLoaded!=true){
			int random = Random.Range (0, prefabLevel.Count);
			if(random==currentLevel || prefabLevel [random].getIsActive_flag ()==true){
				random = Random.Range (0, prefabLevel.Count);
			}else{
				SpawnObj (random,new Vector3(prefabLevel[currentLevel].level.transform.position.x+15f,1.13f,1.74f));
			}
		}

		if(prefabLevel[currentLevel].level.transform.position.x<6f){
			LevelisLoaded = false;
		}
		print ("current level:"+currentLevel+" levelisLoaded:"+LevelisLoaded+" positionX:"+prefabLevel[currentLevel].level.transform.position.x+" old Position"+prefabLevel[oldLevel].level.transform.position.x+" Old level:"+oldLevel+" OldlevelIsStillAlive"+prefabLevel[oldLevel].getIsActive_flag ());

	}
}
