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
    public GameObject Game_wined;
    public GameObject Canvas_interfaz;
    public GameObject Canvas_habilidades;
    public GameObject Canvas_Mapa;
    public PassaEscenas pas;
    


    //C�DIGO PARA GENERAR LA ESCENA DEL JUEGO

    void Start(){
        StartCoroutine(InitializeWithPassaEscenas());
        
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

        Time.timeScale = 1f;

        Debug.Log("habilidades: PassaEscenas inicializado correctamente");
    }

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
    public GameObject GetCanvas_interfaz(){
        return Canvas_interfaz;
    }
    public GameObject GetCanvas_habilidades(){
        return Canvas_habilidades;
    }
    public GameObject GetCanvas_Mapa(){
        return Canvas_Mapa;
    }

    public GameObject GetCanvas_Win(){
        return Game_wined;
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
        pas.Guardar_datos();
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
        pas.Guardar_datos();
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
        pas.Guardar_datos();
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
        pas.Guardar_datos();


#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    

    
}
