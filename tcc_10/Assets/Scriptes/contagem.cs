using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contagem : MonoBehaviour
{
    public GameObject[] cont;
    private int tempo;

    private tiroBoss boss;
    void Start()
    {
        StartCoroutine(contagemregressiva());
        boss = FindObjectOfType(typeof(tiroBoss)) as tiroBoss;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator contagemregressiva()
    {
       
        cont[0].SetActive(true);
        cont[1].SetActive(false);
        cont[2].SetActive(false);
        yield return new WaitForSeconds(3);
        cont[0].SetActive(false);
        cont[1].SetActive(true);
        cont[2].SetActive(false);
        yield return new WaitForSeconds(3);
        cont[0].SetActive(false);
        cont[1].SetActive(false);
        cont[2].SetActive(true);
        yield return new WaitForSeconds(3);
        cont[2].SetActive(false);
        yield return new WaitForSeconds(2);
        boss.iniciaJogo = true;
        //boss.velocidade = 5;



    }
}
