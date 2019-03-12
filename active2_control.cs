using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class active2_control : MonoBehaviour {
    GameObject Activebase;
    GameObject Active2;
    HingeJoint a1;
    JointMotor motor;
    JointLimits limit;
    IK_Tcordinate kinematics;
    // Use this for initialization
    void Start()
    {
        Activebase = GameObject.Find("active1");
        kinematics = Activebase.GetComponent<IK_Tcordinate>();

        Active2 = GameObject.Find("pivot_active1");
        a1 = Active2.GetComponent<HingeJoint>();
        a1.useMotor = true;
        a1.useLimits = true;
        motor.force = 100;
        motor.targetVelocity = Key_Input.speed;
        limit.max = 90;
        a1.limits = limit;
        a1.motor = motor;
    }

    public void Move_active2()
    {
        kinematics.Tcoordinate();
        kinematics.Inv_Kinematics();
        kinematics.Update_theta1_value();

        limit.max = IK_Tcordinate.theta2;
        a1.limits = limit;
    }
}
