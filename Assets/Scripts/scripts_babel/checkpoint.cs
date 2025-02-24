using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkpoint : MonoBehaviour
{   public int numero = 0;
    public int max = 5;
    public int numeroPiso = 0;
    public GameObject piso1;
    public GameObject check1;
    public GameObject pisoinicial;
    
    public GameObject altares;

    public int game_over = 3;
    public GameObject canvas_tienda;
    [HideInInspector]
    public LevelManager lvlm;
    [HideInInspector]
    public GameObject canvas_game_over;
    [HideInInspector]
    public GameObject canvas_interfaz;
    [HideInInspector]
    public GameObject canvas_hab;
    [HideInInspector]
    public GameObject canvas_map;
    [HideInInspector]
    public GameObject canvas_win;

    public string texto;
    public Image panel_detras_texto;
    public Text textElement;
    public Camera camara;

    SFXController controladorSFX;
    private PassaEscenas pas;
    
    private ParticleSystem humo;
    private ParticleSystem humo_peque;
    // Update is called once per frame
    void Update()
    {
        camara = Camera.main;
        texto = numero+" / "+ max;
        textElement.text=texto;
        panel_detras_texto.transform.LookAt(camara.transform.position);
        textElement.transform.LookAt(camara.transform.position);
        textElement.transform.Rotate(0,180,0);
        humo = GameObject.FindGameObjectWithTag("HUMO").GetComponent<ParticleSystem>();
        humo_peque = GameObject.Find("humo_peque").GetComponent<ParticleSystem>();
        if (humo == null)
        {
            Debug.LogError("El sistema de partículas no está asignado. Asigna el componente ParticleSystem en el inspector.");
        }
        
    }
    private void Start()
    {
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

        lvlm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<LevelManager>();
        camara=Camera.main;
        game_over=pas.n_pisos;
        canvas_game_over = lvlm.game_over();
        canvas_interfaz = lvlm.GetCanvas_interfaz();
        canvas_hab = lvlm.GetCanvas_habilidades();
        canvas_map = lvlm.GetCanvas_Mapa();
        canvas_win = lvlm.GetCanvas_Win();
        canvas_tienda = GameObject.FindGameObjectWithTag("CANVAS_TIENDA");

        Debug.Log("habilidades: PassaEscenas inicializado correctamente");
    }

    void actualizarConstrucciones(){
        GameObject pisooo = pisoinicial;
        if(numeroPiso!=1){
            pisooo = GameObject.Find("Spiral_piso"+numeroPiso+"(Clone)");
        }
        if(numero==0){
        }else if(numero==1){
            pisooo.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        }else if(numero==2){
            pisooo.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            pisooo.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        }else if(numero==3){
            pisooo.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            pisooo.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            pisooo.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        }else {
            pisooo.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            pisooo.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            pisooo.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
            pisooo.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
        }
        humo_peque.transform.position = pisooo.transform.GetChild(0).position;
        humo_peque.Play();
        
    }

    void OnTriggerEnter (Collider other) {
        
        if (other.CompareTag("esclavo")){
            numero++;
            generador.TotalUnidades--;
            
            if(numero>=max){
                if (numeroPiso-1 == game_over)
                {
                    //Quitar canvas tienda de �ngeles
                    canvas_tienda.SetActive(false);

                    //Parar juego
                    Time.timeScale = 0f;

                    controladorSFX = GameObject.FindGameObjectWithTag("audiosfx").GetComponent<SFXController>();
                    controladorSFX.PlayGameOver();
                    Debug.Log("Game Over");

                    //Mostar canvas game over
                    canvas_interfaz.SetActive(false);
                    canvas_hab.SetActive(false);
                    canvas_map.SetActive(false);
                    canvas_win.SetActive(false);
                    canvas_game_over.SetActive(true);
                }
                else{
                    Destroy(gameObject);

                    controladorSFX = GameObject.FindGameObjectWithTag("audiosfx").GetComponent<SFXController>();
                    controladorSFX.PlayConstruirPiso();

                    humo.transform.position = piso1.transform.position;
                    humo.Play();
                    GameObject piso = (GameObject)Instantiate(piso1);
                    GameObject checkpoint = (GameObject)Instantiate(check1);
                    if(numeroPiso%2==1){
                        GameObject alt=Instantiate(altares);
                        alt.transform.Rotate(Random.Range(0,360)*Vector3.up);
                    }
                
                }
            }
        }else if (other.CompareTag("soldados")){
            numero=numero+2;
            Debug.Log("Ha llegado un soldado");
            generador.TotalUnidades--;

            if(numero>=max){
                if (numeroPiso-1 == game_over)
                {
                    //Quitar canvas tienda de �ngeles
                    canvas_tienda.SetActive(false);

                    //Parar juego
                    Time.timeScale = 0f;

                    controladorSFX = GameObject.FindGameObjectWithTag("audiosfx").GetComponent<SFXController>();
                    controladorSFX.PlayGameOver();
                    Debug.Log("Game Over");

                    //Mostar canvas game over
                    canvas_interfaz.SetActive(false);
                    canvas_hab.SetActive(false);
                    canvas_map.SetActive(false);
                    canvas_win.SetActive(false);
                    canvas_game_over.SetActive(true);
                }
                else{
                    Destroy(gameObject);

                    controladorSFX = GameObject.FindGameObjectWithTag("audiosfx").GetComponent<SFXController>();
                    controladorSFX.PlayConstruirPiso();

                    humo.transform.position = piso1.transform.position;
                    humo.Play();
                    GameObject piso = (GameObject)Instantiate(piso1);
                    GameObject checkpoint = (GameObject)Instantiate(check1);
                    if(numeroPiso%2==1){
                        GameObject alt=Instantiate(altares);
                        alt.transform.Rotate(Random.Range(0,360)*Vector3.up);
                    }
                
                }
            }
        }else if (other.CompareTag("gigante")){
            numero=numero+5;
            Debug.Log("Ha llegado un gigante");
            generador.TotalUnidades--;

            if(numero>=max){
                if (numeroPiso-1 == game_over)
                {
                    //Quitar canvas tienda de �ngeles
                    canvas_tienda.SetActive(false);

                    //Parar juego
                    Time.timeScale = 0f;

                    controladorSFX = GameObject.FindGameObjectWithTag("audiosfx").GetComponent<SFXController>();
                    controladorSFX.PlayGameOver();
                    Debug.Log("Game Over");

                    //Mostar canvas game over
                    canvas_interfaz.SetActive(false);
                    canvas_hab.SetActive(false);
                    canvas_map.SetActive(false);
                    canvas_win.SetActive(false);
                    canvas_game_over.SetActive(true);
                }
                else{
                    Destroy(gameObject);

                    controladorSFX = GameObject.FindGameObjectWithTag("audiosfx").GetComponent<SFXController>();
                    controladorSFX.PlayConstruirPiso();

                    humo.transform.position = piso1.transform.position;
                    humo.Play();                    
                    GameObject piso = (GameObject)Instantiate(piso1);
                    GameObject checkpoint = (GameObject)Instantiate(check1);
                    if(numeroPiso%2==1){
                        GameObject alt=Instantiate(altares);
                        alt.transform.Rotate(Random.Range(0,360)*Vector3.up);
                    }
                }
            }
        }
        actualizarConstrucciones();
    }
}
