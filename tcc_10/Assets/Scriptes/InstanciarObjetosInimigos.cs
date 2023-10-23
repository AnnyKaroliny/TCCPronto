using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarObjetosInimigos : MonoBehaviour
{

    public GameObject Municao1;
    public GameObject Municao2;
    public GameObject Municao3;

    public Transform posicaoMUnicao1;
    public Transform posicaoMusicao2;
    public Transform posicaoMunicao3;

    public float delay;

   
    void Start()
    {
        //InvokeRepeating("instMunicao1", 1, 1);
        //InvokeRepeating("instMunicao3", 1, 1);
        //InvokeRepeating("instMunicao2", 1, 1);

        StartCoroutine(instMunicao());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   /* public void instMunicao1()
    {       
        if (delay <= Time.time)
        {
            Instantiate(Municao1, posicaoMUnicao1.position, Quaternion.identity);

            Instantiate(Municao3, posicaoMunicao3.position, Quaternion.identity);

            Instantiate(Municao2, posicaoMusicao2.position, Quaternion.identity);

            delay += Time.time;
        }
        

    }*/

    IEnumerator instMunicao(){

        yield return new WaitForSeconds(5f);
        Instantiate(Municao1, posicaoMUnicao1.position, Quaternion.identity);

        Instantiate(Municao3, posicaoMunicao3.position, Quaternion.identity);

        Instantiate(Municao2, posicaoMusicao2.position, Quaternion.identity);

        yield return new WaitForSeconds(2f);

        StartCoroutine(instMunicao());


    }
}
