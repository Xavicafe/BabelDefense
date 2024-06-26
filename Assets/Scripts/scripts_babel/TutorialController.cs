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

    public GameObject canvasflecha;

    public GameObject FlechaCanva;
    public GameObject FlechaEspacial;

    public bool HaPulsado=false;
    public bool HaPulsado1=false;
    bool Fase4=false;
    bool Fase5=false;
    public bool TutoFinalizado = false;

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
        canvas.transform.LookAt(Camera.main.transform.position);
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

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || 
        Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))&&estadoTutorial == 2)
        {
            //Pasar a la pantalla 3
            if (estadoTutorial == 2)
            {
                canvas2.SetActive(false);
                Time.timeScale = TimeScaleAnt;
                StartCoroutine(TerceraPantalla());
            }
        }

        if ((Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E) || Input.GetAxis("Mouse ScrollWheel") != 0f) && estadoTutorial == 3)
        {
            //Pasar a la pantalla 4
            if (estadoTutorial == 3)
            {
                canvas3.SetActive(false);
                Time.timeScale = TimeScaleAnt;
                StartCoroutine(CuartaPantalla());
            }
        }
        if (estadoTutorial == 4 && Input.GetKeyDown(KeyCode.Return))
        {
            canvas4.SetActive(false);
            Time.timeScale = TimeScaleAnt;
            estadoTutorial = 0;
            HaPulsado=false;
            Fase4=true;
            
        }
        if(HaPulsado && Fase4){
            FlechaCanva.gameObject.SetActive(false);
            HaPulsado=false;
            Fase4=false;
            
            Fase5=true;
            HaPulsado1=false;
            FlechaEspacial.gameObject.SetActive(true);
        }

        if(HaPulsado1 && Fase5){
            FlechaEspacial.gameObject.SetActive(false);
            HaPulsado1=false;
            Fase5=false;
            StartCoroutine(QuintaPantalla());
            
        }
        
          

        if ( estadoTutorial == 5 && Input.GetKeyDown(KeyCode.Return))
        {
            canvas5.SetActive(false);
            Time.timeScale = TimeScaleAnt;
            StartCoroutine(SextaPantalla());
            
            
        
        }

        

        if (estadoTutorial == 6 && Input.GetKeyDown(KeyCode.Return))
        {
            if(canvas6.activeSelf){
                Time.timeScale = TimeScaleAnt;
            }
            canvas6.SetActive(false);
            

            MusicaController scriptMusica = gameObject.GetComponent<MusicaController>();
            scriptMusica.InicioOleada();
            TutoFinalizado=true;
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
        FlechaCanva.gameObject.SetActive(true);
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
