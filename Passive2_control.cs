using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passive2_control : MonoBehaviour {
    GameObject passive2;
    HingeJoint p2;
    JointSpring motor;
    // Use this for initialization
    void Start () {
        passive2 = GameObject.Find("pivot_passive1");
        p2 = passive2.GetComponent<HingeJoint>();
        p2.useSpring = true;

        motor.spring = 200000;
        motor.damper = 100;
        //limit.min = -90;
        //motor.targetPosition = 90;

        p2.spring = motor;
    }

    // Update is called once per frame
    public void Update_angle()
    {

        motor.targetPosition = Key_Input.angle2;
        p2.spring = motor;
    }

    public void Update_angle2()
    {

        motor.targetPosition =  (IK_Tcordinate.t2 - Mathf.PI / 2) * Mathf.Rad2Deg;
        p2.spring = motor;
    }
}
