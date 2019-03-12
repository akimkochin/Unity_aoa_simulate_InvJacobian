using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class active1_control : MonoBehaviour {
    GameObject Activebase;
    HingeJoint a1;
    JointMotor motor;
    JointLimits limit;
    IK_Tcordinate kinematics;
    // Use this for initialization
    void Start() {
        Activebase = GameObject.Find("active1");
        kinematics = Activebase.GetComponent<IK_Tcordinate>();

        a1 = Activebase.GetComponent<HingeJoint>();
        a1.useMotor = true;
        a1.useLimits = true;
        motor.force = 100;
        motor.targetVelocity = Key_Input.speed;
        limit.max = 90;
        a1.limits = limit;
        a1.motor = motor;
    }

    public void Move_active1()
    {
        kinematics.Tcoordinate();
        kinematics.Inv_Kinematics();
        kinematics.Update_theta1_value();

        limit.max = IK_Tcordinate.theta1;
        a1.limits = limit;
    }
    
}
