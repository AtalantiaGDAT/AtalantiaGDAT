using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pianokey : MonoBehaviour {

	// Use this for initialization
	void Start () {


    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}

