using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
   
    [SerializeField] public GameObject painel;

    public void fecharPeinal()
    {
        painel.SetActive(false);
    }
 
    public void iniciarJogo()
    {
        SceneManager.LoadScene("Jogo");
    }

}
