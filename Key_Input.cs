using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Key_Input : MonoBehaviour {
    public static float speed = 2.398081f * 180 / Mathf.PI;
    public static float speedrad = 2.398081f;

    public static float angle1 = 0.0f;
    public static float angle2 = 0.0f;
    public static float active_angle = 90.0f;
    public static float active_phy = 90.0f;

    public static float purpos_x = 50.0f;
    public static float purpos_y = 0.0f;
    public static float purpos_z = 0.0f;

    float limit_y = 40.0f;
    float limit_x = 50.0f;
    float limit_z = 30.0f;

    public static float coordinate_x = 0.0f;
    public static float coordinate_y = 0.0f;
    public static float coordinate_z = 0.0f;

    public static bool timeflag = false;
    public static bool activeflag = false;
    public static bool allactiveflag = false;

    float countTime = 0;

    GameObject pivot1;
    GameObject pivot2;
    GameObject active1;
    GameObject active2;
    GameObject allactive;
    GameObject Activebase1;
    passive1_control motor1;
    Passive2_control motor2;
    Active motor3;
    IK_Tcordinate kinematics;

    public Text text;
    float all_active_value1 = 0;
    float all_active_value2 = 0;
    float all_active_value3 = 0;
    float add_value = 0.1f;
    float add_position_value = 1.0f;
    // Use this for initialization
    void Start () {

        Activebase1 = GameObject.Find("active1");
        kinematics = Activebase1.GetComponent<IK_Tcordinate>();

        pivot1 = GameObject.Find("pivot_passive1");
        motor1 = pivot1.GetComponent<passive1_control>();

        pivot2 = GameObject.Find("pivot_passive2");
        motor2 = pivot2.GetComponent<Passive2_control>();

        active1 = GameObject.Find("pivot_active1");
        motor3 = active1.GetComponent<Active>();

        allactive = GameObject.Find("6Dof_Gripper");

        kinematics = Activebase1.GetComponent<IK_Tcordinate>();

    }

    // Update is called once per frame
    void Update () {
        /************ Timer *******************/
        if (timeflag == true)
        {
            countTime += Time.deltaTime;
            text.text = countTime.ToString("F2");

        }

        if (allactiveflag == false)
        {

            if (activeflag == false)
            {
                /**********  PASSIVE  **********/

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    angle1 += 1;
                    motor1.Update_angle();
                    print("angle");
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    angle1 -= 1;
                    motor1.Update_angle();
                }

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    angle2 += 1;
                    motor2.Update_angle();
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    angle2 -= 1;
                    motor2.Update_angle();
                }


                /**********  ACTIVE  **********/
                if (Input.GetKey(KeyCode.A))
                {
                    active_angle += 1;
                    motor3.Move_active();
                }
                if (Input.GetKey(KeyCode.D))
                {
                    active_angle -= 1;
                    motor3.Move_active();
                }
                if (Input.GetKey(KeyCode.W))
                {
                    active_phy += 1;
                    motor3.Move_active();
                }
                if (Input.GetKey(KeyCode.S))
                {
                    active_phy -= 1;
                    motor3.Move_active();
                }
            } else /**********   Passive + Active Control  ***********/
            {

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    purpos_x = 1;
                    purpos_y = 0;
                    purpos_z = 0;

                    kinematics.Compute_Vector();  //Computes a Vector to target position 
                    motor3.Moveactive2();
                    motor2.Update_angle2();
                    motor1.Update_angle2();
                    
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    
                    purpos_x = -1;
                    purpos_y = 0;
                    purpos_z = 0;

                    kinematics.Compute_Vector();  //Computes a Vector to target position 
                    motor3.Moveactive2();
                    motor2.Update_angle2();
                    motor1.Update_angle2();


                }

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    
                    purpos_x = 0;
                    purpos_y = 0;
                    purpos_z = 1;
                    kinematics.Compute_Vector();  //Computes a Vector to target position 
                    motor3.Moveactive2();
                    motor2.Update_angle2();
                    motor1.Update_angle2();
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                   
                    purpos_x = 0;
                    purpos_y = 0;
                    purpos_z = -1;
                    kinematics.Compute_Vector();  //Computes a Vector to target position 
                    motor3.Moveactive2();
                    motor2.Update_angle2();
                    motor1.Update_angle2();
                }

                if (Input.GetKey(KeyCode.W))
                {
                    
                    purpos_x = 0;
                    purpos_y = -1;
                    purpos_z = 0;
                    kinematics.Compute_Vector();  //Computes a Vector to target position 
                    motor3.Moveactive2();
                    motor2.Update_angle2();
                    motor1.Update_angle2();
                }

                if (Input.GetKey(KeyCode.S))
                {
                    purpos_x = 0;
                    purpos_y = 1;
                    purpos_z = 0;
                    kinematics.Compute_Vector();  //Computes a Vector to target position 
                    motor3.Moveactive2();
                    motor2.Update_angle2();
                    motor1.Update_angle2();
                }
            }
        }else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                all_active_value1 += add_value;
                allactive.transform.localPosition = new Vector3(-39.81f+all_active_value3, 20.482f + all_active_value2, -3.0f + all_active_value1);


            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                all_active_value1 -= add_value;
                allactive.transform.localPosition = new Vector3(-39.81f + all_active_value3, 20.482f + all_active_value2, -3.0f + all_active_value1);

            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                all_active_value3 -= add_value;
                allactive.transform.localPosition = new Vector3(-39.81f + all_active_value3, 20.482f + all_active_value2, -3.0f + all_active_value1);

            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                all_active_value3 += add_value;
                allactive.transform.localPosition = new Vector3(-39.81f + all_active_value3, 20.482f + all_active_value2, -3.0f + all_active_value1);

            }
            if (Input.GetKey(KeyCode.W))
            {
                all_active_value2 += add_value;
                allactive.transform.localPosition = new Vector3(-39.81f + all_active_value3, 20.482f + all_active_value2, -3.0f + all_active_value1);

            }
            if (Input.GetKey(KeyCode.S))
            {
                all_active_value2 -= add_value;
                allactive.transform.localPosition = new Vector3(-39.81f + all_active_value3, 20.482f + all_active_value2, -3.0f + all_active_value1);

            }

        }

    }
}
