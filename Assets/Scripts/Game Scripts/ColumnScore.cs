using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnScore : MonoBehaviour {
    public float speed = 2f;
    public float columnMin = -1f;
    public float columnMax = 3.5f;
    private int random;
    private bool isClockwise;

    void Start()
    {
        RandomRotation();
    }
    // Update is called once per frame
    void Update()
    {
        if (isClockwise) {
            this.transform.Rotate(0, 0, speed); ;
        } else {
            this.transform.Rotate(0, 0, -speed);
        }

        if (GameController.instance.GameOver == false) {

        }

    }

    public void RandomRotation()
    {
        if (Random.value > 0.5f) {
            isClockwise = true;
        } else {
            isClockwise = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            GameController.instance.PlayerScored();
            this.gameObject.SetActive(false);
        }
    }



}
