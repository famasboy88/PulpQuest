using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCoinController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D obj){
		if(obj.tag=="Player"){
			GameController.instance.AddCombo ();
			gameObject.SetActive (false);
		}
	}
}
