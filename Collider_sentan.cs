using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_sentan : MonoBehaviour {
    Material mat;
    Key_Input Key;
    GameObject passive;
    GameObject sentan;

	// Use this for initialization
	void Start () {
        passive = GameObject.Find("PassiveBase");
        Key = passive.GetComponent<Key_Input>();
        mat = this.gameObject.GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider t)
    {
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

        
	}
    void Update()
    {

    }
}
