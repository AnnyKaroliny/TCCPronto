using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float speed;
    private bool movingRight;
    private bool movingLeft;
    private Animator playerAC;
    private SpriteRenderer sprite;
    private Rigidbody2D rbPlayer;
    public int fatorMovimento;
    private camera _camera;
    public bool verificarDirecaoTiro;
    private movimentoplayer _movimentoPlayer;

   


    void Start()
    {

        sprite = GetComponent<SpriteRenderer>();
        playerAC = GetComponent<Animator>();
        rbPlayer = GetComponent<Rigidbody2D>();
        _camera = FindObjectOfType(typeof(camera)) as camera;
        _movimentoPlayer = FindObjectOfType(typeof(movimentoplayer)) as movimentoplayer; 
        _camera.posicaoPlayer = this.gameObject.transform;


    }

    void Update()
    {

        if(movingLeft || movingRight) {
            playerAC.SetBool("Runing", true);
        }else {
            playerAC.SetBool("Runing", false);
        }

        speed = 0;

        if (movingRight && fatorMovimento ==1)
        {
          
            speed = 5;
            if(verificarDirecaoTiro == true ) {
                flip();
            }
            
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            movingLeft = false;

        }else if(movingRight == false) {

            fatorMovimento = 0;
            speed = 0;

        }

        if (movingLeft)
        {

            if(verificarDirecaoTiro == false) {

                flip();

            }
            
            speed = 5;
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            movingRight = false;
        }
        else if(movingLeft == false) {
            speed = 0;
        }
      
    }

    public void flip() {

        verificarDirecaoTiro = !verificarDirecaoTiro;

        float x = transform.localScale.x * -1;

        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);

        _movimentoPlayer.forcaTiro *= -1;
 
    }

    public void MovementRight(bool active)
    {

        movingRight = active;
        fatorMovimento = 1;

    }

    public void MovementLeft(bool active)
    {
        movingLeft = active;

    }
}

