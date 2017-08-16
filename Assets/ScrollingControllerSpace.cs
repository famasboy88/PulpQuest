using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingControllerSpace : MonoBehaviour {


	private Rigidbody2D rb2d;
	public float speed = -1.5f;

	void Start()
	{
		StartMove();
	}

	public void StartMove()
	{
			StartCoroutine("MoveMenu");
		

	}

	IEnumerator MoveMenu()
	{

		rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = new Vector2(speed,0f);
		yield return new WaitForSeconds (0f);
	}
}
