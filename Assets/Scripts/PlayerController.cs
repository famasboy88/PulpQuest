using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float upForce = 300f;
    public AudioClip flapSound;
    public AudioClip die;

	public bool isDead=false;
    private Rigidbody2D rb2d;
    private Animator anim;
	Vector3 birdRotation = Vector3.zero;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        //transform.GetComponent<AudioSource>().clip = flapSound;
	}
	
	// Update is called once per frame
	void Update () {
        if (isDead==false) {
            if (Input.GetMouseButtonDown(0) && PlayerHealth.instance.hitpoint>0f) {
                rb2d.velocity =new Vector2(0f,0f);
                rb2d.AddForce(new Vector2(0f,upForce));
                transform.GetComponent<AudioSource>().PlayOneShot(flapSound);
                anim.SetTrigger("Flap");
            }
			bool goingUp;
			goingUp = (rb2d.velocity.y > 0) ? true : false;


			float degreesToAdd = 0;
			switch(goingUp){
			case true:
				degreesToAdd = 5 * 1.5f;
				break;
			case false:
				degreesToAdd = -3 * 0.4f;
				break;
			default:
				break;
			}

			birdRotation = new Vector3 (0,0,Mathf.Clamp (birdRotation.z+degreesToAdd,-95f,15f));
			transform.eulerAngles = birdRotation;
        }
        if (transform.position.y>=3.8f) {
            KillPlayer();
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.KillPlayer();
    }

    private void KillPlayer()
    {
        if (isDead==false) {
            rb2d.velocity = new Vector2(0f, 0f);
            isDead = true;
            anim.SetTrigger("Die");
            GameController.instance.PlayerDied();
            transform.GetComponent<AudioSource>().PlayOneShot(die);
            
        }
        
       
    }
}
