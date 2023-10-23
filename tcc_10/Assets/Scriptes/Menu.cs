using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Slider teste;
    public AudioSource testeMusica;

    private void Start()
    {
        testeMusica = GetComponent<AudioSource>();
        teste.value = 1;
    }
    private void Update()
    {
        //testeMusica.volume = teste.value;
    }

    public void IniciarJogo()
    {
        SceneManager.LoadScene("Introdução");
    }

    public void Retornar()
    {
        SceneManager.LoadScene("Tela Inicial");
    }

    public void TelaInicial()
    {
        SceneManager.LoadScene("Tela Inicial");
    }

    public void ReiniciarJogo()
    {
        SceneManager.LoadScene("Jogo");
    }

    public void InstrucoesJogo()
    {
        SceneManager.LoadScene("Config");
        
    }

    public void sairJogo()
    {
        Application.Quit();
    }
}
