using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Som : MonoBehaviour
{

    public AudioSource audioSourceMusicaDeFundo;
    public AudioClip[] musicasDeFundo;

    public AudioSource SomdoPulo;




    // Start is called before the first frame update
    void Start()
    {
        AudioClip musicaDeFundo = musicasDeFundo[1];
        audioSourceMusicaDeFundo.clip = musicaDeFundo;
        audioSourceMusicaDeFundo.loop = true;
        audioSourceMusicaDeFundo.Play();

        


    }

    // Update is called once per frame
    void Update()
    {
        SomdoPulo.Play ();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Renderer>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            Destroy(gameObject, 3);
        }
    }
}
