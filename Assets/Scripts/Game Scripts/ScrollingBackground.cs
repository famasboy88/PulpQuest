﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {
	private Rigidbody2D rb2d;
	public float speed = -1.5f;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = new Vector2(speed,0f);
	}
}
