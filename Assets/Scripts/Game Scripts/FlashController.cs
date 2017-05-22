using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashController : MonoBehaviour {

	public Image flash;
	private bool isInTransition;
	private float transition;
	private bool isShowing;
	private float duration;

	void fade(bool showing,float duration){
		isShowing = showing;
		isInTransition = true;
		this.duration = duration;
		transition = (isShowing)? 0f:1f;
	}
	void Update(){
		if(!isInTransition){
			return;
		}
		transition += (isShowing) ? Time.deltaTime * (1f/ duration) : -Time.deltaTime * (1f / duration);
		flash.color = Color.Lerp (new Color(1f,1f,1f,0f),Color.white,transition);

		if(transition>1f || transition<0f){
			isInTransition = false;
		}
	}

	public void flashNow(){
		fade (true,0.3f);
		fade (false,0.8f);
	}

}
