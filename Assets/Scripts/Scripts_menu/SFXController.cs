using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public AudioSource FuenteAudio;

    public AudioClip ConstruirPiso;

    public AudioClip disparoAngel;
    public AudioClip laserAngel;
    public AudioClip sniperAngel;
    public AudioClip invocarAngel;

    public AudioClip humanoAtaque;
    public AudioClip humanoMuerte;

    public AudioClip gameOver;
    public AudioClip gameWin;

    public AudioClip ventanaTutorial;
    public AudioClip tambores;

    public AudioClip hielo;
    public AudioClip dinero;
    public AudioClip helldrums;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayHellDrums()
    {
        FuenteAudio.PlayOneShot(helldrums);
    }

    public void PlayHielo()
    {
        FuenteAudio.PlayOneShot(hielo);
    }

    public void PlayDinero()
    {
        FuenteAudio.PlayOneShot(dinero);
    }

    public void PlayConstruirPiso()
    {
        FuenteAudio.PlayOneShot(ConstruirPiso);
    }

    public void PlayTambores()
    {
        FuenteAudio.PlayOneShot(tambores);
    }


    //Efectos de sonido de disparos

    public void PlayDisparoAngel()
    {
        FuenteAudio.PlayOneShot(disparoAngel);
    }

    public void PlayLaserAngel()
    {
        FuenteAudio.PlayOneShot(laserAngel);
    }

    public void PlaySniperAngel()
    {
        FuenteAudio.PlayOneShot(sniperAngel);
    }

    public void PlayInvocarAngel()
    {
        FuenteAudio.PlayOneShot(invocarAngel);
    }


    //Efectos de sonido de humanos

    public void PlayHumanoAtaque()
    {
        FuenteAudio.PlayOneShot(humanoAtaque);
    }

    public void PlayHumanoMurte()
    {
        FuenteAudio.PlayOneShot(humanoMuerte);
    }

    //Efectos de sonido de flujo de juego

    public void PlayGameOver()
    {
        FuenteAudio.PlayOneShot(gameOver);
    }

    public void PlayGameWin()
    {
        FuenteAudio.PlayOneShot(gameWin);
    }

    public void PlayTutorial()
    {
        FuenteAudio.PlayOneShot(ventanaTutorial);
    }
}
