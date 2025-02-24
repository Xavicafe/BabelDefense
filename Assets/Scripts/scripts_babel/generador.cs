using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;

public class generador : MonoBehaviour
{
    public float TiempoEntreOleadas = 15f;
    public float countdown = 2f;

    
    public static int TotalUnidades = 0;
    public Oleada[] oleadas;
    public int indiceOleada = 0;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public int h = 0;

    public LevelManager lvlm;

    public GameObject canvas_victoria;

    SFXController controladorSFX;

    private PassaEscenas pas;
    TutorialController tutocon;

    [HideInInspector]
    public GameObject canvas_interfaz;
    [HideInInspector]
    public GameObject canvas_hab;
    [HideInInspector]
    public GameObject canvas_map;
    [HideInInspector]
    public GameObject canvas_lose;

    void Start()
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
        canvas_interfaz = lvlm.GetCanvas_interfaz();
        canvas_hab = lvlm.GetCanvas_habilidades();
        canvas_map = lvlm.GetCanvas_Mapa();
        canvas_lose = lvlm.game_over();
        TotalUnidades = 0;
        tutocon = GameObject.Find("GameMaster").GetComponent<TutorialController>();
        if(!LevelManager.TutorialActivo){
            StartCoroutine(GenerarOleada());
            tutocon.TutoFinalizado=true;
            
        }else{
            indiceOleada--;
        }
        countdown = TiempoEntreOleadas;
        indiceOleada++;

        Debug.Log("habilidades: PassaEscenas inicializado correctamente");
    }

    void Update()
    {
        h = TotalUnidades;
        if (TotalUnidades > 0) { return; }
        
        if (indiceOleada >= oleadas.Length) {
            if(canvas_lose.activeSelf){
                return;
            }
            canvas_victoria.SetActive(true);
            
            canvas_interfaz.SetActive(false);
            canvas_hab.SetActive(false);
            canvas_map.SetActive(false);
            Time.timeScale = 0f;
            controladorSFX = GameObject.FindGameObjectWithTag("audiosfx").GetComponent<SFXController>();
            controladorSFX.PlayGameWin();
            pas.AddEXP(GetExperienciaTotalGanada());

            MusicaController scriptMusica = gameObject.GetComponent<MusicaController>();
            scriptMusica.FinOleada();

            Console.WriteLine("Has ganado la partida");
            this.enabled = false; 
            return; }

        if (countdown <= 0f && TotalUnidades <= 0 && tutocon.TutoFinalizado)
        {
            MusicaController scriptMusica = gameObject.GetComponent<MusicaController>();
            

            StartCoroutine(GenerarOleada());
            countdown = TiempoEntreOleadas;
            indiceOleada++;
            return;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        
        
    }

    IEnumerator GenerarOleada()
    {
        
        MusicaController scriptMusica = gameObject.GetComponent<MusicaController>();
        scriptMusica.InicioOleada();
        

        Oleada oleada = oleadas[indiceOleada];
        if(oleada.Jesucristo!=null){
            GeneradorHumanos(oleada.Jesucristo);
            Debug.Log("JESUCRISTO EN MARCHA");
            TotalUnidades = 1;
            PlayerStats.Ronda++;
        }
        else if(oleada.Apostoles!=null){
            GeneradorHumanos(oleada.Apostoles);
            Debug.Log("APOSTOLES EN MARCHA");
            TotalUnidades = 12;
            PlayerStats.Ronda++;
        }
        else{
            int EsclavosVivos = oleada.n_esclavo;
            int SoldadosVivos = oleada.n_soldado;
            int GigantesVivos = oleada.n_gigante;
            int ArquerosVivos = oleada.n_arquero;
            int MagosVivos = oleada.n_mago;
            TotalUnidades = EsclavosVivos + SoldadosVivos + GigantesVivos + ArquerosVivos + MagosVivos;
            int TU=TotalUnidades;
            PlayerStats.Ronda++;
            
            if(SoldadosVivos == 1){
                int e=(int)Random.Range(1,4);
                if(e==1){GeneradorHumanos(oleada.soldado1);}
                else if(e==2){GeneradorHumanos(oleada.soldado2);}
                else{GeneradorHumanos(oleada.soldado3);} 
                SoldadosVivos--;
            }
            if(ArquerosVivos==1){
                ArquerosVivos--;
                GeneradorHumanos(oleada.arquero);
            }
            if(MagosVivos==1){
                MagosVivos--;
                GeneradorHumanos(oleada.mago);
            }
            for (int i = 1; i <= TU; i++)
            {
                if(SoldadosVivos>0){
                    int e=(int)Random.Range(1,4);
                    if(e==1){GeneradorHumanos(oleada.soldado1);}
                    else if(e==2){GeneradorHumanos(oleada.soldado2);}
                    else{GeneradorHumanos(oleada.soldado3);} 
                    SoldadosVivos--;
                    yield return new WaitForSeconds(1f / oleada.rate);
                }else if(GigantesVivos>0){
                    GeneradorHumanos(oleada.gigante);
                    GigantesVivos--;
                    
                    yield return new WaitForSeconds(1f / oleada.rate);
                
                }else if(ArquerosVivos>0){
                    ArquerosVivos--;
                    GeneradorHumanos(oleada.arquero);
                    yield return new WaitForSeconds(1f / oleada.rate);
                
                }else if(MagosVivos>0){
                    MagosVivos--;
                    GeneradorHumanos(oleada.mago);
                    yield return new WaitForSeconds(1f / oleada.rate);
                }else if(EsclavosVivos>0){
                    EsclavosVivos--;
                    int e=(int)Random.Range(1,4);
                    if(e==1){GeneradorHumanos(oleada.esclavo1);}
                    else if(e==2){GeneradorHumanos(oleada.esclavo2);}
                    else{GeneradorHumanos(oleada.esclavo3);}                
                    yield return new WaitForSeconds(1f / oleada.rate);
                }
            }
            
            Debug.Log("Ronda spawneada: " + PlayerStats.Ronda);
        }
        scriptMusica.FinOleada();
    }

    void GeneradorHumanos(GameObject humano)
    {
        int i=(int)Random.Range(0,2);
        if (i==0){
            Instantiate(humano, spawnPoint1.position, spawnPoint1.rotation);
        }
        else if(i==1){
            Instantiate(humano, spawnPoint2.position, spawnPoint2.rotation);
        }

    }

    public int GetExperienciaTotalGanada(){
        int expTotal = 0;
        int expround = 0;
        for (int i = 0; i <= indiceOleada-1; i++){
            expround = oleadas[i].exp_round;
            expTotal += expround;
        }
        expTotal -= expround;
        return expTotal;
            
    }
}
