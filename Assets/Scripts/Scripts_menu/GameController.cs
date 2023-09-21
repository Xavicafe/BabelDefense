using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    [SerializeField] private bool juegoActivo; //Si es true, el juego est� activo. Si no, est� a false
    private bool menuPausaActivo; //Si es true, el menu de pausa est� activo. Si no, est� a false
    public GameObject canvas_interfaz;

    public AudioSource audiosource;
    public AudioClip botonPausa;
    public AudioClip botonVolver;

    

    void Start()
    {
        juegoActivo = true;
        menuPausaActivo = false;
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && juegoActivo)
        {
            MenuPausa(); 
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !juegoActivo)
        {
            //LoadButtonInicio();
        }

    }

    public void cambiarEstado()
    {
        juegoActivo = !juegoActivo;

        if (juegoActivo)
        {
            audiosource.PlayOneShot(botonVolver);
            //El juego est� activo
            Time.timeScale = 1f;
            canvas_interfaz.SetActive(false);
        }

        if (!juegoActivo)
        {
            //El juego no est� activo
            Time.timeScale = 0f;
            canvas_interfaz.SetActive(true);
        }
    }

    public void MenuPausa()
    {
        juegoActivo = !juegoActivo;

        if (juegoActivo)
        {
            audiosource.PlayOneShot(botonVolver);
            //El juego est� activo
            Time.timeScale = 1f;
            canvas_interfaz.SetActive(false);
        }

        if (!juegoActivo)
        {
            audiosource.PlayOneShot(botonPausa);
            //El juego no est� activo
            Time.timeScale = 0f;
            canvas_interfaz.SetActive(true);
        }
    }

    public bool IsJuegoActivo()
    {
        return juegoActivo;
    }
    public void GanarPartida()
    {
        Console.WriteLine("Has ganado la partida");
    }

    //C�DIGO PARA GENERAR LA ESCENA DEL MEN� PPAL

    public void LoadButtonInicio()
    {
        StartCoroutine(LoadSceneInicial());
    }

    IEnumerator LoadSceneInicial()
    {
        yield return null;

        AsyncOperation scene = SceneManager.LoadSceneAsync("inicio");
        scene.allowSceneActivation = false;

        while (!scene.isDone)
        {
            Debug.Log("Pro:" + scene.progress);
            if (scene.progress >= 0.9f)
            {
                scene.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
