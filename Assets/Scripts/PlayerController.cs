using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float upForce = 200f;

    private bool isDead=false;
    private Rigidbody2D rb2d;
    private Animator anim;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isDead==false) {
            if (Input.GetMouseButtonDown(0)) {
                rb2d.velocity =new Vector2(0f,0f);
                rb2d.AddForce(new Vector2(0f,upForce));
                anim.SetTrigger("Flap");
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        anim.SetTrigger("Die");
    }
}
