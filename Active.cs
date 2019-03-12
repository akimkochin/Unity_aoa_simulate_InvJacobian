using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active : MonoBehaviour {
    GameObject Activebase1;
    GameObject Activebase2;
    GameObject passive;

    HingeJoint a1;
    HingeJoint a2;

    JointSpring motor1;
    JointSpring motor2;
    
    IK_Tcordinate kinematics;
    Key_Input key;

    




    // Use this for initialization
    void Start () {
        Activebase1 = GameObject.Find("active1");
        Activebase2 = GameObject.Find("pivot_active1");
        passive = GameObject.Find("PassiveBase");
        kinematics = Activebase1.GetComponent<IK_Tcordinate>();
        key = passive.GetComponent<Key_Input>();

        a1 = Activebase1.GetComponent<HingeJoint>();
        a2 = Activebase2.GetComponent<HingeJoint>();
        a1.useSpring = true;
        a2.useSpring = true;

        motor1.spring = 5000;
        motor1.damper = 500;
        motor2.spring = 5000;
        motor2.damper = 500;

        a1.spring = motor1;
        a2.spring = motor2;


    }

    // Update is called once per frame
    public void Move_active() {
        kinematics.Tcoordinate();
        kinematics.Inv_Kinematics();
        kinematics.Update_theta1_value();

        print("x = " + Key_Input.coordinate_x + ", y = " + Key_Input.coordinate_y + ", z = " + Key_Input.coordinate_z + ", theta1 = " + IK_Tcordinate.theta1 + ", theta2 = " + IK_Tcordinate.theta2);

        motor1.targetPosition = IK_Tcordinate.theta1;
        motor2.targetPosition = IK_Tcordinate.theta2;

        a1.spring = motor1;
        a2.spring = motor2;
    }

    public void Moveactive2()
    {
        motor1.targetPosition = (IK_Tcordinate.t3 - Mathf.PI / 2) * Mathf.Rad2Deg;
        motor2.targetPosition = (IK_Tcordinate.t4 + Mathf.PI / 2) * Mathf.Rad2Deg;

        a1.spring = motor1;
        a2.spring = motor2;
    }

    
}
