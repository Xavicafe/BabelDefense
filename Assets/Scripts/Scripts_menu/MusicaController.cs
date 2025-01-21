using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaController : MonoBehaviour
{
    public AudioSource AudioSourceMusica;
    public AudioSource AudioSourceTambores;
    private PassaEscenas pas;

    //REPRODUCE Y SINCRONIZA EL SONIDO AL PRINCIPIO DE LA ESCENA
    void Start()
    {
        StartCoroutine(InitializeWithPassaEscenas()); 
        pas = GameObject.FindGameObjectWithTag("pasaescena").GetComponent<PassaEscenas>(); 
        
    }

    private IEnumerator InitializeWithPassaEscenas()
    {
        while (PassaEscenas.Instance == null || !PassaEscenas.Instance.IsInitialized)
        {
            Debug.Log("Esperando a que PassaEscenas esté inicializado...");
            yield return null; // Espera un frame antes de volver a intentar
        }

        // Una vez que se encuentra y está inicializado, asigna y continúa
        pas = PassaEscenas.Instance;

        AudioSourceMusica.Play();
        StartCoroutine(SincronizarTambores());
        AudioSourceMusica.loop = true;
        AudioSourceTambores.loop = true;
    }

    IEnumerator SincronizarTambores()
    {
        //Si el tutorial est� activo los tambores no sonar�n
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
        StartCoroutine(FadeOut(AudioSourceTambores, 5));
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.unscaledDeltaTime / FadeTime;

            yield return null;
        }
    }

    //REPRODUCIR SONIDO AL PRINCIPIO DE LA OLEADA O AL FINAL DEL TUTORIAL

    public void InicioOleada()
    {
        AudioSourceTambores.volume = pas.volume;
    }
}
