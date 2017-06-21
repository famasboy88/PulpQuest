using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModel{
	public GameObject level;
	public bool isActive_flag;
	public int CurrentLevelIdentifyer;

	public LevelModel(GameObject game,int currentLevel){
		level = game;
		CurrentLevelIdentifyer = currentLevel;
	}




}
