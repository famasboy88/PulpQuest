using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public GameObject GameOverText;
    public bool GameOver = false;
    public float speed = -1.5f;
    public Text scoreText;
    public Text highscore;
    public GameObject glasses;
    public GameObject accessories;
    private int PlayerScore = 0;
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
                Restart();
                cooldownTimer = 0f;
            }
        }
        
	}

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayerScored()
    {
        if (GameOver==true) {
            return;
        }

        PlayerScore++;
        scoreText.text = "Score: " + PlayerScore.ToString();
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
}
