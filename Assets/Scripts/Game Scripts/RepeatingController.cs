using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingController : MonoBehaviour {

    private float backgroundLength=20.48f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < -backgroundLength) {
            RepositionBackground();
        }
	}

    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(backgroundLength * 2f, 0f);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
