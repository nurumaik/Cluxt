using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShrinking : MonoBehaviour {

    public float shrinkSpeed = 0.3f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
	}
}
