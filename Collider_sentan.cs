using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_sentan : MonoBehaviour {
    Key_Input Key;
    GameObject passive;
    GameObject sentan;
    string tag_name = " ";

	// Use this for initialization
	void Start () {
        passive = GameObject.Find("PassiveBase");
        Key = passive.GetComponent<Key_Input>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider t)
    {
        if(tag_name == t.gameObject.tag || t.gameObject.tag == "table" )
        {
            print("do nothing");

        }
        else if(tag_name == " ")
        {
            print("write tagname");
            tag_name = t.gameObject.tag;
        }else
        {
            Time.timeScale = 0;
            print("collider");

        }

        
        if(t.gameObject.tag == "table")
        {

        }else
        {
            t.gameObject.GetComponent<Renderer>().material.color = Color.blue;

        }

    }
    void Update()
    {

    }
}
