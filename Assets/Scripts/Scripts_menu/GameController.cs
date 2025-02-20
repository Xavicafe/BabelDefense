using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    [SerializeField] private bool juegoActivo; //Si es true, el juego est� activo. Si no, est� a false
    public bool menuPausaActivo; //Si es true, el menu de pausa est� activo. Si no, est� a false
    public GameObject canvas_interfaz;

    public AudioSource audiosource;
    public AudioClip botonPausa;
    public AudioClip botonVolver;

    public float saveTimeScale;

    

    void Start()
    {
        juegoActivo = true;
        menuPausaActivo = false;
        Time.timeScale = 1f;
        audiosource.PlayOneShot(botonVolver);
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
            
            canvas_interfaz.SetActive(false);
            menuPausaActivo = false;
            Time.timeScale = saveTimeScale;
        }

        if (!juegoActivo)
        {
            saveTimeScale=Time.timeScale;
            //El juego no est� activo
            
            canvas_interfaz.SetActive(true);
            menuPausaActivo=true;
            Time.timeScale = 0f;
        }
    }

    public void MenuPausa()
    {
        juegoActivo = !juegoActivo;

        if (juegoActivo)
        {
            audiosource.PlayOneShot(botonVolver);
            //El juego est� activo
            Time.timeScale = saveTimeScale;
            canvas_interfaz.SetActive(false);
            menuPausaActivo = false;
        }

        if (!juegoActivo)
        {
            saveTimeScale=Time.timeScale;
            audiosource.PlayOneShot(botonPausa);
            //El juego no est� activo
            Time.timeScale = 0f;
            canvas_interfaz.SetActive(true);
            menuPausaActivo = true;
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
