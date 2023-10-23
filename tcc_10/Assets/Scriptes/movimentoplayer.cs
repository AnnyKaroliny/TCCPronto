using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class movimentoplayer : MonoBehaviour
{
    private inimigoR inimigoR;
    private playermovement _playerMovimento;
    private button _button;

    private Rigidbody2D rb;
    private Animator anim;

    [Header("Conf Movimentação Player")]
    public float speed = 5f;
    public float jumpForce;

    [Header("Conf Lançamento Projetil")]
    public GameObject projetil;
    public GameObject bombaM;
    public Transform posicaoProjetil;
    
    public float forcaTiro;
    public float isAtirar;

    [Header("Conf Pulo Player ")]
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask layerGround;

    [Header("Conf Coletáveis")]
    public int moedas;
    private int maca;
    private int agua;
    public TextMeshProUGUI textoMoedas;
    public TextMeshProUGUI textoBomba;
    public TextMeshProUGUI textoAgua;

    [Header("Paineis Informações")]
    public GameObject historia;

    [Header("Conf Tempo Fase")]
    public float tempoDecrescente;
    public float tempoDecorrido;
    public float tempoInicial;
    public TextMeshProUGUI tempoFase;

    [Header("Conf Tela Game Over")]
    public bool morrer;
    public GameObject painelGameOver;

    private AudioSource playerAudio;
    public AudioClip somPulo;
    public AudioClip somMoeda;
    public AudioClip somTiro;
    public AudioClip somBomba;
    public AudioClip somVitoria, somGameOver;

    public int quantidadeMunicao;
    public float forcaBombaX, forcaBombaY;
    public Button btnMunicao;
    public Button municaoBomba;
    public GameObject MunicaoColetavel;
    public TextMeshProUGUI textoMunicaoBomba;

    public GameObject escudoAgua;

    public GameObject[] partesPersonagem;
    public bool mudarTagInimigo;

    void Start()
    {
        inimigoR = FindObjectOfType(typeof(inimigoR)) as inimigoR;
        _playerMovimento = FindObjectOfType(typeof(playermovement)) as playermovement;
        _button = FindObjectOfType(typeof(button)) as button;

        playerAudio = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        painelGameOver.SetActive(false);
        morrer = false;

        tempoInicial = 300;
        btnMunicao.interactable = false;
        quantidadeMunicao = 0;
        municaoBomba.interactable = false;

       
    }

    void Update()
    {
        tempoFaseJogo();

        if (tempoDecorrido <= 0) {

            painelGameOver.SetActive(true);
            tempoDecorrido = 0;
            _playerMovimento.speed = 0;
        }

        anim.SetBool("Jump", isGrounded);

        textoMunicaoBomba.text = quantidadeMunicao.ToString();
        textoMoedas.text = moedas.ToString();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, layerGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "inimigo" && morrer == false)
        {
            anim.SetBool("Die", true);
            jumpForce = 0;
            _playerMovimento.speed = 0;
            morrer = true;
        }

        if (collision.gameObject.tag == "inimigoR" && morrer == false)
        {
            anim.SetTrigger("Die");
            jumpForce = 0;
            _playerMovimento.speed = 0;
            morrer = true;
        }

        if (collision.gameObject.tag == "inimigo")
        {
            painelGameOver.SetActive(true);
            Debug.Log("Matou inimigo");
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {

        if(col.gameObject.tag == "Rosquinha")
        {
            painelGameOver.SetActive(true);
        }
        
        if (col.gameObject.tag == "Moedas")
        {
            moedas += 1;            
            Destroy(col.gameObject);
            playerAudio.PlayOneShot(somMoeda, 3.0f) ;
        }

        if (col.gameObject.tag == "inimigoR") {

            anim.SetTrigger("Die");
            jumpForce = 0;
            morrer = true;
        }

        if (col.gameObject.tag == "maça")
        {
            maca += 1;
            textoBomba.text = maca.ToString();
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "agua")
        {
             StartCoroutine(escudo());
            Destroy(col.gameObject);
           
          
        }

        if (col.gameObject.tag == "Morte")
        {           
            painelGameOver.SetActive(true);
        }

        if (col.gameObject.tag == "municao")
        {
            btnMunicao.interactable = true;
            Destroy(MunicaoColetavel.gameObject);
        }

        if(col.gameObject.tag == "coletavelMaca")
        {
            quantidadeMunicao++;
            municaoBomba.interactable = true;
            
            Destroy(col.gameObject);
        }

        if(col.gameObject.tag == "BossTiro")
        {
            painelGameOver.SetActive(true);
            playerAudio.Stop();
            playerAudio.PlayOneShot(somGameOver);
        }

        if(col.gameObject.tag == "FinalDaFase")
        {
            SceneManager.LoadScene("Jogo 1");
        }
    }

    #region 
    public void tempoFaseJogo()
    {
        tempoDecrescente += Time.deltaTime;

        tempoDecorrido = tempoInicial - tempoDecrescente;

        tempoFase.text = tempoDecorrido.ToString("0");
    }

    public void tiro()
    {       
        TiroPlayerParado();
        playerAudio.PlayOneShot(somTiro);
    }

    public void bomba() 
    {
        if(quantidadeMunicao <= 0)
        {
            municaoBomba.interactable = false;
        }
        else if(quantidadeMunicao  > 0)
        {
            quantidadeMunicao--;
            GameObject Temporario = Instantiate(bombaM, posicaoProjetil.position, Quaternion.identity);
            Temporario.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forcaBombaX, forcaBombaY));            
            playerAudio.PlayOneShot(somBomba);           
        }       
    }

    public void TiroPlayerParado()
    {
        GameObject temp = Instantiate(projetil);
        temp.transform.position = posicaoProjetil.position;
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(forcaTiro, 0);
    }

    public void pulo()
    {
        if (isGrounded == true) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);           
            playerAudio.PlayOneShot(somPulo, 0.35f);
        }
    }

    public void PainelGameOver()
    {
        painelGameOver.SetActive(true);
    }
    #endregion

    IEnumerator escudo()
    {
        escudoAgua.SetActive(true);

        for (int i = 0; i < 6; i++)
        {
            partesPersonagem[i].layer = LayerMask.NameToLayer("escudo");
        }
        
        yield return new WaitForSeconds(5f);

        escudoAgua.SetActive(false);

        for (int i=0; i<6; i++)
        {
            partesPersonagem[i].layer = LayerMask.NameToLayer("Default");
        }
     
    }
}


