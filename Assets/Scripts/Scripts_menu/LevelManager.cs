using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public static bool TutorialActivo;
    public GameObject Game_over;
    


    //C�DIGO PARA GENERAR LA ESCENA DEL JUEGO

    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (SceneManager.GetActiveScene().name == "inicio")
            {
                StartCoroutine(LoadScene());
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(SceneManager.GetActiveScene().name == "inicio")
            {
                bool opciones = OpcionesController.OpcionesActivas;
                bool creditos = CreditosController.CreditosActivos;

                if (!opciones && !creditos)
                {
                    cerrar_juego();
                }
                
            }
        }
        

    }

    public GameObject game_over(){
        return Game_over;
    }


    public void LoadButton()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;

        TutorialActivo = false;
        AsyncOperation scene = SceneManager.LoadSceneAsync("avance1");
        scene.allowSceneActivation = false;

        while (!scene.isDone)
        {
            //m_Text.text = "Tropas celestiales al" + (scene.progress * 100) + "%";
            if (scene.progress >= 0.9f)
            {
                scene.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    //C�DIGO PARA GENERAR LA ESCENA DEL JUEGO CON EL TUTORIAL

    public void TutorialButton()
    {
        StartCoroutine(LoadTutorial());
    }

    IEnumerator LoadTutorial()
    {
        yield return null;

        TutorialActivo = true;
        AsyncOperation scene = SceneManager.LoadSceneAsync("avance1");
        scene.allowSceneActivation = false;

        while (!scene.isDone)
        {
            //m_Text.text = "Tropas celestiales al" + (scene.progress * 100) + "%";
            if (scene.progress >= 0.9f)
            {
                scene.allowSceneActivation = true;
            }

            yield return null;
        }
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
            if (scene.progress >= 0.9f)
            {
                scene.allowSceneActivation = true;
            }

            yield return null;
        }
    }


    public void cerrar_juego()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
