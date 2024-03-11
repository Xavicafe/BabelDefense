using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionesJuegoController : MonoBehaviour
{
    private bool opciones_activas;
    public GameObject canvas_opciones;
    private PassaEscenas pas;
    
    // Start is called before the first frame update
    void Start()
    {
        opciones_activas = false;      
        pas = GameObject.FindGameObjectWithTag("pasaescena").GetComponent<PassaEscenas>();  
        GameObject.Find("Musica_fondo").GetComponent<AudioSource>().volume = pas.volume;
        GameObject.Find("AudioSFX").GetComponent<AudioSource>().volume = pas.efects;
        GameObject audiotambores = GameObject.Find("AudioTambores");
        if(audiotambores!=null){
            audiotambores.GetComponent<AudioSource>().volume = pas.volume;
        }  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && opciones_activas)
        {
            ocultar_opciones();
        }
    }

    public void mostrar_opciones()
    {
        canvas_opciones.SetActive(true);
        opciones_activas = true;
    }

    public void ocultar_opciones()
    {
        canvas_opciones.SetActive(false);
        opciones_activas = false;
    }

    public bool EstanOpcionesActivas()
    {
        return opciones_activas;
    }
}
