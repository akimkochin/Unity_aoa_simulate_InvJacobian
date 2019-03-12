using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_sentan : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider t)
    {
        Time.timeScale = 0;
        print("collider");
	}
    void Update()
    {

    }
}
