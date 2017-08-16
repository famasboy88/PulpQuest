using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Playables;

public class GameController : MonoBehaviour {

    public AudioClip points;
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
	private bool played=false;
	public GameObject player;

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
		if (GameOver == true) {
			cooldownTimer += Time.deltaTime;
			if (Input.GetMouseButtonDown (0) && cooldownTimer >= cooldown) {
				this.gameObject.GetComponent <SceneManagerController> ().GotoPreStart ();
				cooldownTimer = 0f;
			}
		}
		if (GameOver == false) {
			if(PlayerHealth. instance.hitpoint!=200f){
				PlayerHealth.instance.decrease (Time.deltaTime * 10f);
			}else{
				if(played==false){
					//player.GetComponent <PlayableDirector>().Play ();
					player.GetComponent <PlayerController>().enabled=false;
					player.GetComponent <PolygonCollider2D>().enabled=false;
					ScrollingController[] scripts = GameObject.FindObjectsOfType (typeof(ScrollingController)) as ScrollingController[];
					foreach(ScrollingController s in scripts ){
						s.gameObject.GetComponent <Rigidbody2D>().velocity = new Vector2(0,0);
					}
					player.GetComponent <PlayableDirector>().Play ();
					StartCoroutine (IntoSpace ((float)player.GetComponent <PlayableDirector>().duration-0.8f));
					played = true;
				}
			}

		}

	}

	IEnumerator IntoSpace(float sec){
		yield return new WaitForSeconds (sec);
		this.gameObject.GetComponent <SceneManagerController>().GotoPreStart ();
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
		/*glasses.AddComponent<Rigidbody2D>();
        if (accessories!=null) {
            accessories.AddComponent<Rigidbody2D>();
            accessories.AddComponent<PolygonCollider2D>();
        }
        if (PlayerScore > PlayerPrefs.GetInt("Highscore")) {
            PlayerPrefs.SetInt("Highscore",PlayerScore);
        }*/
        highscore.text = "HighScore: " + PlayerPrefs.GetInt("Highscore").ToString();
        GameOverText.SetActive(true);
        GameOver = true;
        this.GetComponent<FlashController>().flashNow();
    }
}
