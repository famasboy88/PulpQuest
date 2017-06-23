﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingController : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float speed = -1.5f;

	void Start()
	{
		StartMove();
	}

	public void StartMove()
	{
		if(GameController.instance.GameOver==false){
			StartCoroutine("MoveMenu");
		}

	}

	IEnumerator MoveMenu()
	{
		
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = new Vector2(speed,0f);

		yield return new WaitForSeconds (0f);
	}

	void Update(){
		if (GameController.instance.GameOver == true) {
			rb2d.velocity = new Vector2(0f,0f);
		}
	}

	
}

