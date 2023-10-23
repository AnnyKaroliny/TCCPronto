using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBoss : MonoBehaviour
{
    public GameObject[] vida;
    private int vidaAtual = 4;
    public GameObject painelVitoria;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Personagem");


    }

    // Update is called once per frame
    void Update()
    {
        if (vidaAtual < 0)
        {
            painelVitoria.SetActive(true);
            player.GetComponent<AudioSource>().Stop();
            player.GetComponent<AudioSource>().PlayOneShot(player.GetComponent<movimentoplayer>().somVitoria);
            Destroy(gameObject);            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "municao" && vidaAtual >= 0)
        {
            Destroy(collision.gameObject);
            vida[vidaAtual].SetActive(false);
            vidaAtual--;
        }
    }
}
