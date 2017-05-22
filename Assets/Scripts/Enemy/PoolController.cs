using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour {
    public GameObject prefab;
    public int columnPoolSize = 5;
    public float columnMin = -1f;
    public float columnMax = 3.5f;
    public float spawnRate = 4f;

    private float spawnXposition = 10f;
    private GameObject[] column;
    private Vector2 objectPoolPosition = new Vector2(-15f,-25f);
    private int currentColumn = 0;
    private float timeLastSpawned;
	// Use this for initialization
	void Start () {
        column = new GameObject[columnPoolSize];
        for (int i=0;i<columnPoolSize;i++) {
            column[i] = (GameObject)Instantiate(prefab,objectPoolPosition,Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
        timeLastSpawned += Time.deltaTime;
        if (GameController.instance.GameOver == false && timeLastSpawned >= spawnRate) {
            timeLastSpawned = 0;
            float spawnYposition = Random.Range(columnMin,columnMax);
            column[currentColumn].transform.position = new Vector2(spawnXposition,spawnYposition);
            currentColumn++;
            if (currentColumn>=columnPoolSize) {
                currentColumn = 0; 
            }
        }
	}
}
