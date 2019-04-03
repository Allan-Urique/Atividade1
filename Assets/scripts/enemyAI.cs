using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    
    public ParticleSystem fire;
    public bool enableshoot = false;
    int index = 0;
    float rotation = 0;
    float patrolSpeed = 150;
    public float radius = 10;
    GameObject target;
    public GameObject[] waypoints;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

        fire.Stop();
        float dist = Vector3.Distance(target.transform.position, transform.position);

        if (enableshoot == false){

            if (rotation == 360){
                rotation = 0;
            }

            rotation = rotation + radius * Time.deltaTime;
            gameObject.transform.rotation = Quaternion.Euler(0, rotation, 0);
            gameObject.transform.Translate(0, 0, patrolSpeed * Time.deltaTime);

            print("Moving at patrol speed");
        }

        if (enableshoot)
        {
            fire.Emit(1);
            transform.LookAt(target.transform.position + target.transform.forward * dist * 0.5f);

            if (dist <= 30)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoints[index].transform.position, Time.deltaTime * 20);

                print("Decreasing speed");
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoints[index].transform.position, Time.deltaTime * 80);
                print("Moving at engagement speed");
            }

        }     

    }

    private void OnTriggerEnter(Collider other)
    {        
        enableshoot = true;
    }

    private void OnTriggerExit(Collider other)
    {
        fire.Stop();
        enableshoot = false;
    }

}

