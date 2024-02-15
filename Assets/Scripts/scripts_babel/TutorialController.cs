using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public GameObject canvas; //Bienvenido al modo tutorial
    public GameObject canvas2; //Camara
    public GameObject canvas3; //Zoom
    public GameObject canvas4; //Humanos y angeles
    public GameObject canvas5; //Monedas
    public GameObject canvas6; //No dejes que los humanos construyan la torre

    int estadoTutorial;

    SFXController controladorSFX;

    private float TimeScaleAnt;

    // Start is called before the first frame update
    void Start()
    {
        bool tutorial = LevelManager.TutorialActivo;
        if (tutorial == true)
        {
            ComenzarTutorial();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //COMPROBACIONES PARA IR PASANDO TUTORIAL

        if (Input.anyKeyDown && estadoTutorial == 1)
        {
            //Pasar a la pantalla 2
            if (estadoTutorial == 1)
            {
                canvas.SetActive(false);
                Time.timeScale = TimeScaleAnt;
                StartCoroutine(SegundaPantalla());
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Pasar a la pantalla 3
            if (estadoTutorial == 2)
            {
                canvas2.SetActive(false);
                Time.timeScale = TimeScaleAnt;
                StartCoroutine(TerceraPantalla());
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E) && estadoTutorial == 3)
        {
            //Pasar a la pantalla 4
            if (estadoTutorial == 3)
            {
                canvas3.SetActive(false);
                Time.timeScale = TimeScaleAnt;
                StartCoroutine(CuartaPantalla());
            }
        }

        if (Input.anyKeyDown && estadoTutorial == 4)
        {
            //Pasar a la pantalla 5
            if (estadoTutorial == 4)
            {
                canvas4.SetActive(false);
                Time.timeScale = TimeScaleAnt;
                StartCoroutine(QuintaPantalla());
            }
        }
          

        if (Input.anyKeyDown && estadoTutorial == 5)
        {
            //Pasar a la pantalla 6
            if (estadoTutorial == 5)
            {
                canvas5.SetActive(false);
                Time.timeScale = TimeScaleAnt;
                StartCoroutine(SextaPantalla());
            }
        }

        if (Input.anyKeyDown && estadoTutorial == 6)
        {
            //Fin del tutorial
            if (estadoTutorial == 6)
            {
                if(canvas6.activeSelf){
                    Time.timeScale = TimeScaleAnt;
                }
                canvas6.SetActive(false);
                

                MusicaController scriptMusica = gameObject.GetComponent<MusicaController>();
                scriptMusica.InicioOleada();
            }
        }    
    }

    void ComenzarTutorial()
    {
        controladorSFX = GameObject.FindGameObjectWithTag("audiosfx").GetComponent<SFXController>();
        controladorSFX.PlayTutorial();
        canvas.SetActive(true);
        estadoTutorial = 1;
        TimeScaleAnt=Time.timeScale;
        Time.timeScale = 0f;
    }

    IEnumerator SegundaPantalla()
    {
        estadoTutorial = 0;

        yield return new WaitForSeconds(1);

        canvas2.SetActive(true);
        estadoTutorial = 2;
        TimeScaleAnt=Time.timeScale;
        Time.timeScale = 0f;
    }


    IEnumerator TerceraPantalla()
    {
        estadoTutorial = 0;

        yield return new WaitForSeconds(5);

        canvas3.SetActive(true);
        estadoTutorial = 3;
        TimeScaleAnt=Time.timeScale;
        Time.timeScale = 0f;
    }


    IEnumerator CuartaPantalla()
    {
        estadoTutorial = 0;

        yield return new WaitForSeconds(5);

        canvas4.SetActive(true);
        estadoTutorial = 4;
        TimeScaleAnt=Time.timeScale;
        Time.timeScale = 0f;
    }


    IEnumerator QuintaPantalla()
    {
        estadoTutorial = 0;

        yield return new WaitForSeconds(5);

        canvas5.SetActive(true);
        estadoTutorial = 5;
        TimeScaleAnt=Time.timeScale;
        Time.timeScale = 0f;
    }

    IEnumerator SextaPantalla()
    {
        estadoTutorial = 0;

        yield return new WaitForSeconds(5);

        canvas6.SetActive(true);
        estadoTutorial = 6;
        TimeScaleAnt=Time.timeScale;
        Time.timeScale = 0f;
    }
}
