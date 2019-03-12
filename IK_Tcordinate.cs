using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathNet.Numerics.LinearAlgebra.Double;

public class IK_Tcordinate : MonoBehaviour
{
    float gamma = 0.0f;
    float offsetangle = 0.0f;
    float r1 = 140;
    float r2 = 130.0f;
    float l1 = 455.0f;
    float l2 = 270;

    float L1 = 10;
    float L2 = 10;
    float L3 = 20;
    float L4 = 10;

    public static float theta1 = 0.0f;
    public static float theta2 = 0.0f;

    public static float t1 = 0.0f;
    public static float t2 = Mathf.PI / 2;
    public static float t3 = 0.0f;
    public static float t4 = - Mathf.PI / 2;
    int Counting = 0;
    
    float error = 10.0f;




    float move_x = 0.0f;
    float move_y = 0.0f;
    float move_z = 0.0f;
    float step = 0.1f;

    float beforetheta1 = 0.0f;
    float anglerad = 0.0f;
    float phyrad = 0.0f;

    float b = 10.0f;
    float a = 130.0f;
    float abs_x = 0.0f;
    float abs_y = 0.0f;
    float abs_z = 0.0f;

    float abs_theta1 = 0.0f;
    float abs_theta2 = 0.0f;
    float tempL = 0.0f;
    float tempL2 = 0.0f;
    float tempY_l1 = 0.0f;
    float alpha = 0.0f;
    float alpha2 = 0.0f;
    float epsilon = 0.0f;
    // Use this for initialization
    void Start()
    {
        gamma = Mathf.Atan2(b, a);

    }

    public void Tcoordinate()
    {
        offsetangle = gamma + (Mathf.PI / 2 - anglerad);
        anglerad = Key_Input.active_angle * Mathf.PI / 180;
        phyrad = Key_Input.active_phy * Mathf.PI / 180;
        /*
        coordinate_z = (r1 * Mathf.Cos(anglerad)) + (r2 * Mathf.Sin(offsetangle));
        coordinate_y = (r1 * Mathf.Sin(angle) * Mathf.Sin(phy)) + (r2 * Mathf.Cos(offsetangle) * Mathf.Sin(phy)) + l1;
        coordinate_x = (r1 * Mathf.Sin(angle) * Mathf.Cos(phy)) + (r2 * Mathf.Cos(offsetangle) * Mathf.Cos(phy));
        */
        

        Key_Input.coordinate_z = r1 * Mathf.Cos(anglerad);
        Key_Input.coordinate_y = r1 * Mathf.Sin(anglerad) * Mathf.Sin(phyrad) + l1;
        Key_Input.coordinate_x = r1 * Mathf.Sin(anglerad) * Mathf.Cos(phyrad);

        abs_x = Mathf.Abs(Key_Input.coordinate_x);
        abs_y = Mathf.Abs(Key_Input.coordinate_y);
        abs_z = Mathf.Abs(Key_Input.coordinate_z);

        if (abs_x <= 0.001)
        {
            Key_Input.coordinate_x = 0.0f;
        }
        if (abs_y <= 0.001)
        {
            Key_Input.coordinate_y = 0.0f;
        }
        if (abs_z <= 0.001)
        {
            Key_Input.coordinate_z = 0.0f;
        }
    }

    public void Inv_Kinematics()
    {
        /********************************/
        tempY_l1 = Key_Input.coordinate_y - l1;
        tempL = Mathf.Sqrt(Key_Input.coordinate_x * Key_Input.coordinate_x + Key_Input.coordinate_z * Key_Input.coordinate_z);
        alpha = Mathf.Atan2(tempY_l1, tempL);



        /************calculate**************/
        theta1 = Mathf.Atan2(Key_Input.coordinate_z, Key_Input.coordinate_x);
        theta2 = Mathf.PI / 2 - alpha;

        if (Key_Input.coordinate_x == 0 && Key_Input.coordinate_z == 0)
        {
            theta1 = beforetheta1;
        }
        if (Mathf.Abs(beforetheta1 - theta1) > Mathf.PI / 2)
        {
            print("*************if*******************");
            print(theta1);

            if (theta1 > 0)
            {
                print("---------");
                theta1 = Mathf.Atan2(Key_Input.coordinate_z, Key_Input.coordinate_x) - Mathf.PI;
                theta2 = -1.0f * Mathf.PI / 2 + alpha;
            }
            else
            {
                print("else");
                theta1 = Mathf.Atan2(Key_Input.coordinate_z, Key_Input.coordinate_x) + Mathf.PI;
                theta2 = -1.0f * Mathf.PI / 2 + alpha;
            }

        }
        if (theta1 == 2 * Mathf.PI)
        {
            theta1 = 0.0f;
        }



        if (Mathf.Abs(theta2) > Mathf.PI / 2)
        {
            if (theta2 > 0)
                theta2 = Mathf.PI / 2;
            if (theta2 < 0)
                theta2 = -1.0f * Mathf.PI / 2;
        }

        // theta2 = Mathf.PI / 2 + theta2;



        theta1 = theta1 * 180 / Mathf.PI;
        theta2 = theta2 * 180 / Mathf.PI;

    }
    public void Inv_Kinematics2()
    {
        alpha2 = Mathf.Atan2(Key_Input.coordinate_y, l2);
        tempL2 = Mathf.Sqrt(l2 * l2 + Key_Input.coordinate_y * Key_Input.coordinate_y);
        epsilon = Mathf.Cos(alpha2) * Mathf.Sin(Mathf.Acos((Key_Input.coordinate_y - l1) / tempL2)) + Mathf.Sin(alpha2) * (Key_Input.coordinate_y - l1) / tempL2;


        theta1 = Mathf.Acos(Key_Input.coordinate_z / (epsilon * tempL2));
        theta2 = Mathf.Acos((Key_Input.coordinate_y - l1) / tempL2);


        theta1 = theta1 * 180 / Mathf.PI;
        theta2 = theta2 * 180 / Mathf.PI;
    }

    public void Update_theta1_value()
    {
        beforetheta1 = theta1 * Mathf.PI / 180; ;

    }

    public void DH_kinematics()
    {

        Key_Input.coordinate_x = Mathf.Round(L1 + L2 * Mathf.Cos(t1) + L4 * Mathf.Cos(t4) * (Mathf.Sin(t1) * Mathf.Sin(t3) + Mathf.Cos(t1) * Mathf.Cos(t2) * Mathf.Cos(t3)) + L3 * Mathf.Cos(t1) * Mathf.Sin(t2) - L4 * Mathf.Cos(t1) * Mathf.Sin(t2) * Mathf.Sin(t4));
        Key_Input.coordinate_y = Mathf.Round(L2 * Mathf.Sin(t1) - L4 * Mathf.Cos(t4) * (Mathf.Cos(t1) * Mathf.Sin(t3) - Mathf.Cos(t2) * Mathf.Cos(t3) * Mathf.Sin(t1)) + L3 * Mathf.Sin(t1) * Mathf.Sin(t2) - L4 * Mathf.Sin(t1) * Mathf.Sin(t2) * Mathf.Sin(t4));
        Key_Input.coordinate_z = Mathf.Round(L4 * Mathf.Cos(t2) * Mathf.Sin(t4) - L3 * Mathf.Cos(t2) + L4 * Mathf.Cos(t3) * Mathf.Cos(t4) * Mathf.Sin(t2));
        Debug.Log(Key_Input.coordinate_x + ", " + Key_Input.coordinate_y + ", " + Key_Input.coordinate_z);
        Debug.Log(t1 * Mathf.Rad2Deg + ", " + t2 * Mathf.Rad2Deg + ", " + t3 * Mathf.Rad2Deg + ", " + t4 * Mathf.Rad2Deg);
    }
    public void Compute_Vector()
    {
        Counting++;


        DH_kinematics();

        //Debug.Log(Key_Input.purpos_x);
        /*
        if (Mathf.Abs(Key_Input.purpos_x - Key_Input.coordinate_x) == 0.0f)
        {
            move_x = 0.0f;
        }else
        {
            move_x = ((Key_Input.purpos_x - Key_Input.coordinate_x) / (Mathf.Abs(Key_Input.purpos_x - Key_Input.coordinate_x))) * step;
        }

        if (Mathf.Abs(Key_Input.purpos_y - Key_Input.coordinate_y) == 0.0f)
        {
            move_y = 0.0f;
        }
        else
        {
            move_y =((Key_Input.purpos_y - Key_Input.coordinate_y) / (Mathf.Abs(Key_Input.purpos_y - Key_Input.coordinate_y))) * step;
        }


        if (Mathf.Abs(Key_Input.purpos_z - Key_Input.coordinate_z) == 0.0f)
        {
            move_z = 0.0f;
        }
        else
        {
            move_z = ((Key_Input.purpos_z - Key_Input.coordinate_z) / (Mathf.Abs(Key_Input.purpos_z - Key_Input.coordinate_z))) * step;
        }
        */



        /****目標位置まで移動するベクトルを算出****/
        var move_vector = DenseMatrix.OfArray(new double[,] { { Key_Input.purpos_x * step }, { Key_Input.purpos_y * step }, { Key_Input.purpos_z * step } });//DenseMatrix.OfArray(new double[,] { { move_x }, { move_y }, { move_z } });
        //Debug.Log(move_vector);
        /****ヤコビアン****/
        var jacobian = DenseMatrix.OfArray(new double[,] { { Mathf.Round(L4*Mathf.Cos(t4)*(Mathf.Cos(t1)*Mathf.Sin(t3)-Mathf.Cos(t2)*Mathf.Cos(t3)*Mathf.Sin(t1))-L2*Mathf.Sin(t1)-L3*Mathf.Sin(t1)*Mathf.Sin(t2)+L4*Mathf.Sin(t1)*Mathf.Sin(t2)*Mathf.Sin(t4)), Mathf.Round(L3*Mathf.Cos(t1)*Mathf.Cos(t2)-L4*Mathf.Cos(t1)*Mathf.Cos(t2)*Mathf.Sin(t4)-L4*Mathf.Cos(t1)*Mathf.Cos(t3)*Mathf.Cos(t4)*Mathf.Sin(t2)), Mathf.Round(L4*Mathf.Cos(t4)*(Mathf.Cos(t3)*Mathf.Sin(t1)-Mathf.Cos(t1)*Mathf.Cos(t2)*Mathf.Sin(t3))), Mathf.Round(-L4*Mathf.Sin(t4)*(Mathf.Sin(t1)*Mathf.Sin(t3)+Mathf.Cos(t1)*Mathf.Cos(t2)*Mathf.Cos(t3))-L4*Mathf.Cos(t1)*Mathf.Cos(t4)*Mathf.Sin(t2)) },
                                                           {Mathf.Round(L2*Mathf.Cos(t1)+L4*Mathf.Cos(t4)*(Mathf.Sin(t1)*Mathf.Sin(t3)+Mathf.Cos(t1)*Mathf.Cos(t2)*Mathf.Cos(t3))+L3*Mathf.Cos(t1)*Mathf.Sin(t2)-L4*Mathf.Cos(t1)*Mathf.Sin(t2)*Mathf.Sin(t4)), Mathf.Round(L3*Mathf.Cos(t2)*Mathf.Sin(t1)-L4*Mathf.Cos(t2)*Mathf.Sin(t1)*Mathf.Sin(t4)-L4*Mathf.Cos(t3)*Mathf.Cos(t4)*Mathf.Sin(t1)*Mathf.Sin(t2)), Mathf.Round(-L4*Mathf.Cos(t4)*(Mathf.Cos(t1)*Mathf.Cos(t3)+Mathf.Cos(t2)*Mathf.Sin(t1)*Mathf.Sin(t3))), Mathf.Round(L4*Mathf.Sin(t4)*(Mathf.Cos(t1)*Mathf.Sin(t3)-Mathf.Cos(t2)*Mathf.Cos(t3)*Mathf.Sin(t1))-L4*Mathf.Cos(t4)*Mathf.Sin(t1)*Mathf.Sin(t2))}, 
                                                           {                                                                                                                                                                                                0,                                           Mathf.Round(L3*Mathf.Sin(t2)-L4*Mathf.Sin(t2)*Mathf.Sin(t4)+L4*Mathf.Cos(t2)*Mathf.Cos(t3)*Mathf.Cos(t4)),                                             Mathf.Round(-L4*Mathf.Cos(t4)*Mathf.Sin(t2)*Mathf.Sin(t3)),                                                         Mathf.Round(L4*Mathf.Cos(t2)*Mathf.Cos(t4) - L4*Mathf.Cos(t3)*Mathf.Sin(t2)*Mathf.Sin(t4)) } });
        
        
        //Debug.Log(jacobian);


        /****特異値分解****/
        var svd = jacobian.Svd(true);


        /****ベクトルを行列に逆数を取って代入****/
        var S = new DiagonalMatrix(jacobian.RowCount, jacobian.ColumnCount , (1 / svd.S).ToArray());
        /**0除算の例外処理**/
        for (int i = 0; i<S.RowCount; i++)
        {
            for(int j = 0; j < S.ColumnCount; j++)
            {
                if (double.IsInfinity(S[i,j]))
                {
                    S[i, j] = 0.0f;
                }
            }
        }

        /**擬似逆行列**/
        var pseudoInv = svd.VT.Transpose() * S.Transpose() * svd.U.Transpose();
        //var pseudoInv = jacobian.Transpose() * (jacobian * jacobian.Transpose()).Inverse();
        Debug.Log("psudoInv = "+ pseudoInv);
        Debug.Log("move_vector = " + move_vector);


        /********Δθの算出*********/
        var delta_theta = pseudoInv * move_vector;
        Debug.Log("delta_theta = " + delta_theta);


        t1 += (float)delta_theta[0, 0];
        t2 += (float)delta_theta[1, 0];
        t3 += (float)delta_theta[2, 0];
        t4 += (float)delta_theta[3, 0];


        //Debug.Log(t1 +", "+ t2 + ", " + t3 + ", " + t4);
        DH_kinematics();

        /*if(Mathf.Abs(Key_Input.purpos_x - Key_Input.coordinate_x) > error || Mathf.Abs(Key_Input.purpos_y - Key_Input.coordinate_y) > error || Mathf.Abs(Key_Input.purpos_z - Key_Input.coordinate_z) > error)
        {
            if (Counting != 30)
            {
                Compute_Vector();
            }
            else
            {
                Debug.Log("It could not Compute values of theta");
                Counting = 0;
            }
        }*/
    
        

        


    }
}
