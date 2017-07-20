using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerController : MonoBehaviour {

    public Text highscore;

	public Image black;
	public Animator anim;

	// Use this for initialization
	void Start () {
        highscore.text = "HighScore: " + PlayerPrefs.GetInt("Highscore").ToString();
    }
	
    public void PlayGame()
    {
		StartCoroutine (Fading (1));

    }

	public void GotoPreStart(){
		StartCoroutine (Fading (2));

	}

	IEnumerator Fading(int scene){
		anim.SetBool ("Fade",true);
		yield return new WaitUntil (() => black.color.a == 1f);

		if(scene==1){
			SceneManager.LoadScene("MainScene");
			yield return new WaitForSeconds (.1f);
		}else if(scene==2){
			SceneManager.LoadScene ("PreStart");
		}
	}
}
