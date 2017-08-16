using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	private bool direction;
	public float speed;
	private float degreesToAdd =0f;
	private Vector3 birdRotation = new Vector3 (0f, 0f, 0f);

	// Use this for initialization
	void Start () {
		rb2d = GetComponent <Rigidbody2D> ();
		speed *= (Random.value > 0.5f) ? 1 : -1f;
		direction = (speed > 0) ? true : false;
		degreesToAdd = (rb2d.velocity.y > 0)? 15f : -15f;

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown (0)){
			speed *= -1;
			direction = !direction;
			degreesToAdd *= -1f;
		}
		birdRotation = new Vector3 (0,0,Mathf.Clamp (birdRotation.z+degreesToAdd,-35f,35f));
		transform.eulerAngles = birdRotation;
		rb2d.velocity = new Vector2 (0f, speed);
	}
}
