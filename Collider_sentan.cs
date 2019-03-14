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
        t.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        if(tag_name == t.gameObject.tag)
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


        /*
        print("flag" + Key_Input.collider_flag);
        if (Key_Input.collider_flag == 0)
        {
            mat.color = Color.blue;
            Key_Input.collider_flag += 1;
        } else if(Key_Input.collider_flag == 1)
        {
            Time.timeScale = 0;
            print("collider");
        }
        */

    }
    void Update()
    {

    }
}
