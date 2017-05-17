using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollerController : MonoBehaviour {

    private Rigidbody rgbd;
    public float speed=2f;
	
	// Update is called once per frame
	void Update () {
        if (GameController.GameControllerInstance.gameOver == false) {
            transform.position += new Vector3(-Time.deltaTime * speed, 0f, 0f);
        } else {
            transform.position += new Vector3(-Time.deltaTime * 0, 0f, 0f);
        }
	}
}
