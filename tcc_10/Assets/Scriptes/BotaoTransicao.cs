using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoTransicao : MonoBehaviour
{
    public GameObject[] cenas;
    public int contador;
    public GameObject button;


    void Start()
    {

    }

    public void proximaCena()
    {
        if(contador < 32)
        {
            contador = contador + 1;

            cenas[contador].SetActive(true);

        }else
        {
            button.SetActive(false);
        }
      

    }

    public void voltarCena()
    {
        
        cenas[contador].SetActive(false);
        contador = contador - 1;
       

    }






}
