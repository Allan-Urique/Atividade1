using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody rdb;
    Vector3 inputaxis;
    public TrailRenderer tr,tl;

    void FixedUpdate()
    {
        inputaxis = new Vector3(Input.GetAxis("Vertical") * 10000, 0, -Input.GetAxis("Horizontal") * 40000);

        float trail= Vector3.Angle(transform.forward, rdb.velocity.normalized)*0.01f;
        tr.time = trail;
        tl.time = trail;

        //adiciona o torque relativo para movimento avionico
        rdb.AddRelativeTorque(inputaxis);
        //calcula o roll da aeronave pelo angulo dos eixos
        float roll = Vector3.Angle(transform.right, Vector3.up)-90;
        //adiciona torque global para curva 
        rdb.AddTorque(new Vector3(0, roll*50, 0));
        rdb.AddRelativeForce(new Vector3(0, 0, 100000));
    }
}
