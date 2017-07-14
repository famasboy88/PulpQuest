﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public AudioClip points;
	public GameObject Player;
    public static GameController instance;
    public GameObject GameOverText;
    public bool GameOver = false;
    public float speed = -1.5f;
    public Text scoreText;
    public Text highscore;
	public Text comboScoreText;
    public GameObject glasses;
    public GameObject accessories;
    private int PlayerScore = 0;
	private int comboScore;
	public Text comboScoreTxt;
    private float cooldown =1f;
    private float cooldownTimer = 0f;

    private void Awake()
    {
        if (instance==null) {
            instance = this;
        } else if(instance!=this){
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		comboScore = 0; 
        if (Random.value > 0.5f) {
            accessories.SetActive(true);
        } else {
            accessories.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (GameOver==true) {
            cooldownTimer += Time.deltaTime;
            if (Input.GetMouseButtonDown(0) && cooldownTimer >= cooldown) {
				this.gameObject.GetComponent <SceneManagerController>().GotoPreStart ();
                cooldownTimer = 0f;
            }
        }
		if (GameOver==false) {
            //PlayerHealth.instance.decrease(Time.deltaTime*10f);
        }
        
	}

    private void Restart()
    {
		SceneManager.LoadScene (1);
    }

    public void PlayerScored()
    {
        if (GameOver==true) {
            return;
        }
        this.transform.GetComponent<AudioSource>().PlayOneShot(points);
        PlayerScore++;
        scoreText.text = "Score: " + PlayerScore.ToString();
        PlayerHealth.instance.increase(8f);
    }

    public void PlayerDied()
    {
        glasses.AddComponent<Rigidbody2D>();
        if (accessories!=null) {
            accessories.AddComponent<Rigidbody2D>();
            accessories.AddComponent<PolygonCollider2D>();
        }
        if (PlayerScore > PlayerPrefs.GetInt("Highscore")) {
            PlayerPrefs.SetInt("Highscore",PlayerScore);
        }
        highscore.text = "HighScore: " + PlayerPrefs.GetInt("Highscore").ToString();
        GameOverText.SetActive(true);
        GameOver = true;
        this.GetComponent<FlashController>().flashNow();
    }

	public void AddCombo(){
		comboScore++;
		comboScoreTxt.text = comboScore.ToString ();
	}
}
