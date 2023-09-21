using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class angeles : MonoBehaviour
{

    

    public TMP_Text text;

    private PassaEscenas pas;
    public MejorasController mejcon;

    public List<GameObject> total_angeles;

    void Start(){
        pas = GameObject.FindGameObjectWithTag("pasaescena").GetComponent<PassaEscenas>();
    }

    public void Reset_angel(){
        for(int i=0;i<total_angeles.Count;i++){
            total_angeles[i].SetActive(false);
        }
        

    }

    public void OnMouseDown(int index){
        mejcon.Reset();
        Reset_angel();

        total_angeles[index].SetActive(true);

        if(index==0){
            text.text = "ANGEL SIMPLE";
            for(int i=0;i<=pas.rango_angelsimple;i++){
                mejcon.estrellas_rango[i].SetActive(true);
            }
            for(int i=0;i<=pas.daño_angelsimple;i++){
                mejcon.estrellas_daño[i].SetActive(true);
            }
            for(int i=0;i<=pas.cadencia_angelsimple;i++){
                mejcon.estrellas_cadencia[i].SetActive(true);
            }
        }
        if(index==1){
            text.text = "ARCANGEL";

            for(int i=0;i<=pas.rango_arcangel;i++){
                mejcon.estrellas_rango[i].SetActive(true);
            }
            for(int i=0;i<=pas.daño_arcangel;i++){
                mejcon.estrellas_daño[i].SetActive(true);
            }
            for(int i=0;i<=pas.cadencia_arcangel;i++){
                mejcon.estrellas_cadencia[i].SetActive(true);
            }
        }
        
        if(index==2){
            text.text = "PRINCIPADO";

            for(int i=0;i<=pas.rango_principado;i++){
                mejcon.estrellas_rango[i].SetActive(true);
            }
            for(int i=0;i<=pas.daño_principado;i++){
                mejcon.estrellas_daño[i].SetActive(true);
            }
            for(int i=0;i<=pas.cadencia_principado;i++){
                mejcon.estrellas_cadencia[i].SetActive(true);
            }
        }
        if(index==3){
            text.text = "VIRTUD";

            for(int i=0;i<=pas.rango_virtud;i++){
                mejcon.estrellas_rango[i].SetActive(true);
            }
            for(int i=0;i<=pas.daño_virtud;i++){
                mejcon.estrellas_daño[i].SetActive(true);
            }
            for(int i=0;i<=pas.cadencia_virtud;i++){
                mejcon.estrellas_cadencia[i].SetActive(true);
            }
        }
        if(index==4){
            text.text = "POTESTAD";

            for(int i=0;i<=pas.rango_potestad;i++){
                mejcon.estrellas_rango[i].SetActive(true);
            }
            for(int i=0;i<=pas.daño_potestad;i++){
                mejcon.estrellas_daño[i].SetActive(true);
            }
            for(int i=0;i<=pas.cadencia_potestad;i++){
                mejcon.estrellas_cadencia[i].SetActive(true);
            }
        }
        if(index==5){
            text.text = "DOMINIO";

            for(int i=0;i<=pas.rango_dominio;i++){
                mejcon.estrellas_rango[i].SetActive(true);
            }
            for(int i=0;i<=pas.daño_dominio;i++){
                mejcon.estrellas_daño[i].SetActive(true);
            }
            for(int i=0;i<=pas.cadencia_dominio;i++){
                mejcon.estrellas_cadencia[i].SetActive(true);
            }
        }
        
        if(index==6){
            text.text = "TRONO";

            for(int i=0;i<=pas.rango_trono;i++){
                mejcon.estrellas_rango[i].SetActive(true);
            }
            for(int i=0;i<=pas.daño_trono;i++){
                mejcon.estrellas_daño[i].SetActive(true);
            }
            for(int i=0;i<=pas.cadencia_trono;i++){
                mejcon.estrellas_cadencia[i].SetActive(true);
            }
        }
        if(index==7){
            text.text = "QUERUBÍN";

            for(int i=0;i<=pas.rango_querubin;i++){
                mejcon.estrellas_rango[i].SetActive(true);
            }
            for(int i=0;i<=pas.daño_querubin;i++){
                mejcon.estrellas_daño[i].SetActive(true);
            }
            for(int i=0;i<=pas.cadencia_querubin;i++){
                mejcon.estrellas_cadencia[i].SetActive(true);
            }
        }
        if(index==8){
            text.text = "SERAFÍN";

            for(int i=0;i<=pas.rango_serafin;i++){
                mejcon.estrellas_rango[i].SetActive(true);
            }
            for(int i=0;i<=pas.daño_serafin;i++){
                mejcon.estrellas_daño[i].SetActive(true);
            }
            for(int i=0;i<=pas.cadencia_serafin;i++){
                mejcon.estrellas_cadencia[i].SetActive(true);
            }
        }
    }

    
}
