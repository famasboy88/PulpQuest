using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour {

    private Rigidbody rgbd;

    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
    }


}
