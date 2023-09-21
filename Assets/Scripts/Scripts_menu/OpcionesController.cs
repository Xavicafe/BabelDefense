using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionesController : MonoBehaviour
{
    private bool opciones_activas;
    public GameObject canvas_opciones;

    public AudioSource audiosource;
    public AudioClip botonvolver;
    public static bool OpcionesActivas;



    // Start is called before the first frame update
    void Start()
    {
        opciones_activas = false;
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
        OpcionesActivas = true;
    }

    public void ocultar_opciones()
    {
        canvas_opciones.SetActive(false);
        opciones_activas = false;
        OpcionesActivas = false;
        audiosource.PlayOneShot(botonvolver);
    }

    public bool EstanOpcionesActivas()
    {
        return opciones_activas;
    }
}
