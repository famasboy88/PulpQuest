using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController GameControllerInstance;
    public bool gameOver;
    private bool playerIsDead = false;

	void Start () {
        if (GameControllerInstance==null) {
            GameControllerInstance = this;
        } else {
            Destroy(gameObject);
        }

        gameOver = playerIsDead;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
