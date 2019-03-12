using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passive1_control : MonoBehaviour {
    GameObject passive1;
    HingeJoint p1;
    JointSpring motor;
    // Use this for initialization
    void Start () {
        passive1 = GameObject.Find("PassiveBase");
        p1 = passive1.GetComponent<HingeJoint>();
        p1.useSpring = true;
        
        motor.spring = 200000;
        motor.damper = 100;
        //limit.min = -90;
        //motor.targetPosition = 90;
        
        p1.spring = motor;
        
    }
	
	// Update is called once per frame
	public void Update_angle()
    {
         
         motor.targetPosition = Key_Input.angle1;
         p1.spring = motor;
    }

    public void Update_angle2()
    {

        motor.targetPosition = IK_Tcordinate.t1 * Mathf.Rad2Deg;
        p1.spring = motor;
    }
}
