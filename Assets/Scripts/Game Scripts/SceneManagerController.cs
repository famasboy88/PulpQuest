using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerController : MonoBehaviour {

    public Text highscore;
	// Use this for initialization
	void Start () {
        highscore.text = "HighScore: " + PlayerPrefs.GetInt("Highscore").ToString();
    }
	
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
