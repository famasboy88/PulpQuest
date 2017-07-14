using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpliffController : MonoBehaviour {
    public GameObject spliffs;

    private void Update()
    {
        if (spliffs.transform.position.x<=-6.55f) {
            spliffs.SetActive(false);
            spliffs.transform.position = new Vector2(8.89f,2f);
        }
    }
}
