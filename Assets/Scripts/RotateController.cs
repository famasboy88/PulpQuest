using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour {


	public float speed=2f;
	private int random;
	private bool isClockwise;

	void Start(){
		RandomRotation ();
	}
	// Update is called once per frame
	void Update () {
		if(isClockwise){
			this.transform.Rotate (0, 0, speed);
		}else{
			this.transform.Rotate (0, 0, -speed);
		}

	}

	public void RandomRotation(){
		if(Random.value>0.5f){
			isClockwise = true;
		}else{
			isClockwise =false;
		}
	}
}
