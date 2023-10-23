using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentarInimigo2 : MonoBehaviour
{
    public float forcaX, forcaY;


    void Start()
    {

        Destroy(gameObject, 4.8f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(forcaX, forcaY, 0) * Time.deltaTime);
       
    }

    
}
