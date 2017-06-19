using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public static PlayerHealth instance;

    public Image currentHealthBar;
    public Text ratioText;


    public float hitpoint = 150f;
    private float maxHitpoint = 150f;

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
