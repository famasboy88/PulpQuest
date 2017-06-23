using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModel{
	public GameObject level;
	private bool isActive_flag;


	public LevelModel(GameObject game){
		level = game;
		isActive_flag = false;
	}

	public void setIsActive_flag(bool active){
		isActive_flag = active;
	}

	public bool getIsActive_flag(){
		return isActive_flag;
	}

}
