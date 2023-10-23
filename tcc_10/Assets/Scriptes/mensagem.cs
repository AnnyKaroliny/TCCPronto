using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mensagem : MonoBehaviour
{
    public GameObject painelmensagem;

    public GameObject mensagens;
    public GameObject btnMensagem;
    void Start()
    {
        btnMensagem.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mensagem")
        {
            painelmensagem.SetActive(true);
            btnMensagem.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mensagem")
        {
            painelmensagem.SetActive(false);
            btnMensagem.SetActive(false);
        }
    }

    public void btnMensagemAtivar()
    {
        mensagens.SetActive(true);
    }

    public void fecharPainelMensagem()
    {
        mensagens.SetActive(false);
    }
}
