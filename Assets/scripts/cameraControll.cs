using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControll : MonoBehaviour
{
    public GameObject lookattarget, gototarget;
    public float speed = 1;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        transform.LookAt(lookattarget.transform);

        transform.position = Vector3.Lerp(transform.position, gototarget.transform.position, Time.deltaTime* speed);
    }
}
