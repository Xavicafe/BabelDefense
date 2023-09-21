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
    
    public GameObject altares;

    public int game_over = 3;
    public GameObject canvas_tienda;
    public LevelManager lvlm;
    public GameObject canvas_game_over;

    public string texto;
    public Text textElement;
    public Camera camara;

    SFXController controladorSFX;
    private PassaEscenas pas;
    // Update is called once per frame
    void Update()
    {
        camara = Camera.main;
        texto = numero+" / "+ max;
        textElement.text=texto;
        textElement.transform.LookAt(camara.transform.position);
        textElement.transform.Rotate(0,180,0);
    }
    private void Start()
    {
        lvlm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<LevelManager>();
        pas = GameObject.FindGameObjectWithTag("pasaescena").GetComponent<PassaEscenas>();
        camara=Camera.main;
        game_over=pas.n_pisos;
        canvas_game_over = lvlm.game_over();
        canvas_tienda = GameObject.FindGameObjectWithTag("CANVAS_TIENDA");
        Debug.Log(canvas_game_over);
        Debug.Log(canvas_tienda);

        
    }
    void OnTriggerEnter (Collider other) {
        if (other.CompareTag("esclavo")){
            numero++;
            Debug.Log("Ha llegado un soldado");
            generador.TotalUnidades--;

            if(numero>=max){
                if (numeroPiso == game_over)
                {
                    //Quitar canvas tienda de �ngeles
                    canvas_tienda.SetActive(false);

                    //Parar juego
                    Time.timeScale = 0f;

                    controladorSFX = GameObject.FindGameObjectWithTag("audiosfx").GetComponent<SFXController>();
                    controladorSFX.PlayGameOver();
                    Debug.Log("Game Over");

                    //Mostar canvas game over
                    canvas_game_over.SetActive(true);
                }
                else{
                    Destroy(gameObject);

                    controladorSFX = GameObject.FindGameObjectWithTag("audiosfx").GetComponent<SFXController>();
                    controladorSFX.PlayConstruirPiso();

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
                if (numeroPiso == game_over)
                {
                    //Quitar canvas tienda de �ngeles
                    canvas_tienda.SetActive(false);

                    //Parar juego
                    Time.timeScale = 0f;

                    controladorSFX = GameObject.FindGameObjectWithTag("audiosfx").GetComponent<SFXController>();
                    controladorSFX.PlayGameOver();
                    Debug.Log("Game Over");

                    //Mostar canvas game over
                    canvas_game_over.SetActive(true);
                }
                else{
                    Destroy(gameObject);

                    controladorSFX = GameObject.FindGameObjectWithTag("audiosfx").GetComponent<SFXController>();
                    controladorSFX.PlayConstruirPiso();

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
                if (numeroPiso == game_over)
                {
                    //Quitar canvas tienda de �ngeles
                    canvas_tienda.SetActive(false);

                    //Parar juego
                    Time.timeScale = 0f;

                    controladorSFX = GameObject.FindGameObjectWithTag("audiosfx").GetComponent<SFXController>();
                    controladorSFX.PlayGameOver();
                    Debug.Log("Game Over");

                    //Mostar canvas game over
                    canvas_game_over.SetActive(true);
                }
                else{
                    Destroy(gameObject);

                    controladorSFX = GameObject.FindGameObjectWithTag("audiosfx").GetComponent<SFXController>();
                    controladorSFX.PlayConstruirPiso();

                    GameObject piso = (GameObject)Instantiate(piso1);
                    GameObject checkpoint = (GameObject)Instantiate(check1);
                    if(numeroPiso%2==1){
                        GameObject alt=Instantiate(altares);
                        alt.transform.Rotate(Random.Range(0,360)*Vector3.up);
                    }
                }
            }
        }
    }
}
