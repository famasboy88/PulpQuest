using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingController : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float speed = -1.5f;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(speed,0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (GameController.instance.GameOver==true && gameObject.tag!="Clouds") {
            rb2d.velocity = new Vector2(0f,0f);
        }
	}
}
