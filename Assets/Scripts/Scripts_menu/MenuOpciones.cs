using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuOpciones : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    private PassaEscenas pas;

    public void Start(){
        pas = GameObject.FindGameObjectWithTag("pasaescena").GetComponent<PassaEscenas>();
        GameObject.Find("SliderVolumen").GetComponent<Slider>().value = pas.volume;
        GameObject.Find("SliderSFX").GetComponent<Slider>().value = pas.efects;
    }


    public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    public void CambiarVolumen(float volumen)
    {
        pas.volume = volumen;
        GameObject.Find("Musica_fondo").GetComponent<AudioSource>().volume= volumen;
    }

    public void CambiarSFX(float volumen)
    {
        pas.efects = volumen;
        GameObject.Find("AudioSFX").GetComponent<AudioSource>().volume = volumen;
    }
}
