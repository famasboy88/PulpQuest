using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class PlayerHealth : MonoBehaviour {
    public static PlayerHealth instance;
    public Image currentHealthBar;
    public Text ratioText;

	public float every;   //The public variable "every" refers to "Lerp the color every X"
	float colorstep;
	public Color[] colors;
	public Color[] color2;
	public Color[] color3;//Insert how many colors you want to lerp between here, hard coded to 4
	int i;
	Color lerpedColor;

	public GameObject bg1;
	public GameObject bg2;

    public float hitpoint = 100f;
    private float maxHitpoint = 200f;
	private float speedStrobe;




    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }else if (instance != this) {
            Destroy(this);
        }
    }

    // Use this for initialization
    void Start () {
        UpdateHealthbar();

	}
	
    private void UpdateHealthbar()
    {
        float ratio = hitpoint / maxHitpoint;
        currentHealthBar.rectTransform.localScale = new Vector3(ratio,1.19f,1f);
        ratioText.text = (ratio * 100).ToString("0") + '%';
		/*print (colorMode);*/
    }

	public void ColorLerping(Color[] cl, GameObject go, GameObject go1){
		lerpedColor = cl [0];
		if (colorstep < every) { //As long as the step is less than "every"
			lerpedColor = Color.Lerp (cl[i], cl[i+1], colorstep);
			go1.GetComponent <SpriteRenderer>().color = go.GetComponent <SpriteRenderer>().color = lerpedColor;
			colorstep +=speedStrobe;  //The lower this is, the smoother the transition, set it yourself
		} else { //Once the step equals the time we want to wait for the color, increment to lerp to the next color
			colorstep = 0;
			if (i < (cl.Length - 2)){ //Keep incrementing until i + 1 equals the Lengh
				i++;
			}
			else { //and then reset to zero
				i=0;
			}
		}
	}

	private void Update(){
		if(GameController.instance.GameOver==false){
			if(hitpoint>=110 && hitpoint<130){
				every = 2f;
				speedStrobe = 0.3f;
				ColorLerping (colors, bg1, bg2);
			}else if(hitpoint>=130 && hitpoint<160){
				every = 1.5f;
				speedStrobe = 0.5f;
				ColorLerping (color2, bg1, bg2);
			}else if(hitpoint>=160 && hitpoint<200){
				every = 1f;
				speedStrobe = 0.8f;
				ColorLerping (color3, bg1, bg2);
			}

		}


	}


    public void decrease(float num)
    {
        hitpoint -= num;
		if (hitpoint<0) {
            hitpoint = 0;
        }

        UpdateHealthbar();
    }

    public void increase(float num)
    {
        hitpoint += num;
        if (hitpoint > maxHitpoint) {
            hitpoint = maxHitpoint;
        }
        UpdateHealthbar();
    }
}
