using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformChecker : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if(this.gameObject.transform.position.x<-12f){
			this.gameObject.SetActive (false);
		}
	}
}
