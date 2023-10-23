using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girarInimigo : MonoBehaviour
{

    public float  velocidade;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1)* velocidade);
    }
}
