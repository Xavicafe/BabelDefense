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
        

        Toggle checkbox = GameObject.Find("ToggleFullScreen").GetComponent<Toggle>();
        checkbox.isOn=pas.fullscreen;
        Debug.Log(checkbox);
        
    }


    public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
        pas.fullscreen=pantallaCompleta;
    }

    public void CambiarVolumen(float volumen)
    {
        pas.volume = volumen;
        GameObject.Find("Musica_fondo").GetComponent<AudioSource>().volume = volumen;
        GameObject audiotambores = GameObject.Find("AudioTambores");
        if(audiotambores!=null){
            audiotambores.GetComponent<AudioSource>().volume = volumen;
        }
    }

    public void CambiarSFX(float volumen)
    {
        pas.efects = volumen;
        GameObject.Find("AudioSFX").GetComponent<AudioSource>().volume = volumen;
    }
}
