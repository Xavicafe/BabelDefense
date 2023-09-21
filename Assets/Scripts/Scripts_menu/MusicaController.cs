using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaController : MonoBehaviour
{
    public AudioSource AudioSourceMusica;
    public AudioSource AudioSourceTambores;

    //REPRODUCE Y SINCRONIZA EL SONIDO AL PRINCIPIO DE LA ESCENA
    void Start()
    {
        AudioSourceMusica.Play();
        StartCoroutine(SincronizarTambores());
        AudioSourceMusica.loop = true;
        AudioSourceTambores.loop = true;
    }

    IEnumerator SincronizarTambores()
    {
        //Si el tutorial está activo los tambores no sonarán
        bool tutorial = LevelManager.TutorialActivo;
        if (tutorial == true)
        {
            AudioSourceTambores.volume = 0.0f;
        }

        yield return new WaitForSeconds(0.75f);
        AudioSourceTambores.Play();

    }

    //FADE OUT DEL SONIDO AL FINAL DE LA OLEADA

    public void FinOleada()
    {
        StartCoroutine(FadeOut(AudioSourceTambores, 3));
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }
    }

    //REPRODUCIR SONIDO AL PRINCIPIO DE LA OLEADA O AL FINAL DEL TUTORIAL

    public void InicioOleada()
    {
        AudioSourceTambores.volume = 1.0f;
    }
}
