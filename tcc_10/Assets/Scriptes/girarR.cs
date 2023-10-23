using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girarR : MonoBehaviour
{

    bool sensorD;
    bool sensorE;
        
     void Start()
    {
        
    }

    void Update()
    {
        if(sensorD == true)
        {

            transform.Rotate(new Vector3(0, 0, -1));
            sensorE = false;
        }

        if(sensorE == true)
        {
            transform.Rotate(new Vector3(0, 0, 1));
            sensorD = false;
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "sensor1")
        {

            sensorD  = true;
        }

        if (collision.gameObject.tag == "sensor2")
        {

            sensorE = true;
        }

    }

}
