using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject maincamera;
    public GameObject subcamera;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    public void OnClickStart()
    {
        Key_Input.timeflag = true;
        Debug.Log("on click");

    }

    public void ActiveMode()
    {
        Key_Input.activeflag = true;
        Debug.Log("on click");
    }

    public void FreeMode()
    {
        Key_Input.allactiveflag = true;
        Debug.Log("on click");
        maincamera.SetActive(!maincamera.activeSelf);
        subcamera.SetActive(!subcamera.activeSelf);
    }

   
}
