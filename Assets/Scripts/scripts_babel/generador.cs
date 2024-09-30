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

    public GameObject canvas_victoria;

    SFXController controladorSFX;

    private PassaEscenas pas;
    TutorialController tutocon;

    void Start()
    {
        pas = GameObject.FindGameObjectWithTag("pasaescena").GetComponent<PassaEscenas>();
        tutocon = GameObject.Find("GameMaster").GetComponent<TutorialController>();
        if(!LevelManager.TutorialActivo){
            StartCoroutine(GenerarOleada());
            tutocon.TutoFinalizado=true;
            
        }else{
            indiceOleada--;
        }
        countdown = TiempoEntreOleadas;
        indiceOleada++;
    }

    void Update()
    {
        h = TotalUnidades;
        Debug.Log("Total Unidades: " + TotalUnidades);
        if (TotalUnidades > 0) { return; }
        if (indiceOleada >= oleadas.Length) {

            canvas_victoria.SetActive(true);
            Time.timeScale = 0f;
            controladorSFX = GameObject.FindGameObjectWithTag("audiosfx").GetComponent<SFXController>();
            controladorSFX.PlayGameWin();

            MusicaController scriptMusica = gameObject.GetComponent<MusicaController>();
            scriptMusica.FinOleada();

            Console.WriteLine("Has ganado la partida");
            this.enabled = false; 
            return; }
        if (countdown <= 0f && TotalUnidades == 0 && tutocon.TutoFinalizado)
        {
            MusicaController scriptMusica = gameObject.GetComponent<MusicaController>();
            scriptMusica.FinOleada();

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
        }
        else if(oleada.Apostoles!=null){
            GeneradorHumanos(oleada.Apostoles);
            Debug.Log("APOSTOLES EN MARCHA");
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
            pas.AddEXP(oleada.exp_round);
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
            
            Console.WriteLine("Ronda spawneada: " + PlayerStats.Ronda);
        }
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
}
