using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealthController : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D obj){
		if(obj.tag=="Player" && GameController.instance.GameOver!=true){
			PlayerHealth.instance.increase (10f);
			this.gameObject.SetActive (false);
		}
	}
}
