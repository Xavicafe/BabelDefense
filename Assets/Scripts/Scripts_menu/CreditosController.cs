using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditosController : MonoBehaviour
{
    private bool creditos_activos;
    public GameObject canvas_creditos;

    public AudioSource audiosource;
    public AudioClip botonvolver;
    public static bool CreditosActivos;
    public float dur_credits;

    // Start is called before the first frame update
    void Start()
    {
        creditos_activos = false;
        CreditosActivos = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape) && creditos_activos)
        {
            cerrar_creditos();
        } 
    }

    public void mostrar_creditos()
    {
        canvas_creditos.SetActive(true);
        creditos_activos = true;
        CreditosActivos = true;
    }

    public void cerrar_creditos(){
        canvas_creditos.SetActive(false);
        creditos_activos = false;
        CreditosActivos = false;
        audiosource.PlayOneShot(botonvolver);
    }

}
