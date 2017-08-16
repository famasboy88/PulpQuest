using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	private bool direction;
	public float speed;

	// Use this for initialization
	void Start () {
		speed *= (Random.value > 0.5f) ? 1 : -1f;
		direction = (speed > 0) ? true : false;
		rb2d = GetComponent <Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown (0)){
			speed *= -1;
			direction = !direction;
		}

		rb2d.velocity=new Vector2(0f,speed);
	}
}
