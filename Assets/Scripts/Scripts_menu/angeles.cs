using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class angeles : MonoBehaviour
{

    

    public TMP_Text text;
    public TMP_Text angel;
    public TMP_Text arcangel;


    private PassaEscenas pas;
    public MejorasController mejcon;
    public List<int> PrecioDesbloqueoAngeles;
    private int ind=0;

    public List<GameObject> total_angeles;
    private Vector3 posini;

    void Start(){
        posini = new Vector3(0,-3.6716e-05f,0);
        PrecioDesbloqueoAngeles = new List<int> {50,50,50,50,50,50,50,50,50};
        pas = GameObject.FindGameObjectWithTag("pasaescena").GetComponent<PassaEscenas>();
        ponerAngel(0);
    }

    public void Reset_angel(){
        for(int i=0;i<total_angeles.Count;i++){
            total_angeles[i].SetActive(false);
        }
        

    }
    public void ponerAngel(int index){
        mejcon.Reset();
        Reset_angel();

        mejcon.comun.SetActive(true);
        mejcon.desbloquear.SetActive(false);

        total_angeles[index].SetActive(true);

        if(index==0){

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

    public void OnMouseDown(int index){
        ind=index;
        if(index==0){
            text.text = "ÁNGEL";            
            angel.gameObject.SetActive(true);
            arcangel.gameObject.SetActive(false);
            text.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,10000000000,0);}

        if(index==1){
            text.text = "ARCÁNGEL";            
            angel.gameObject.SetActive(false);
            arcangel.gameObject.SetActive(true);
            text.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,10000000000,0);}
        
        if(index==2){
            text.text = "PRINCIPADO";
            angel.gameObject.SetActive(false);
            arcangel.gameObject.SetActive(false);
            text.GetComponent<RectTransform>().anchoredPosition = posini;}

        if(index==3){
            text.text = "VIRTUD";
            angel.gameObject.SetActive(false);
            arcangel.gameObject.SetActive(false);
            text.GetComponent<RectTransform>().anchoredPosition = posini;}

        if(index==4){
            text.text = "POTESTAD";
            angel.gameObject.SetActive(false);
            arcangel.gameObject.SetActive(false);
            text.GetComponent<RectTransform>().anchoredPosition = posini;}

        if(index==5){
            text.text = "DOMINIO";
            angel.gameObject.SetActive(false);
            arcangel.gameObject.SetActive(false);
            text.GetComponent<RectTransform>().anchoredPosition = posini;}
        
        if(index==6){
            text.text = "TRONO";
            angel.gameObject.SetActive(false);
            arcangel.gameObject.SetActive(false);
            text.GetComponent<RectTransform>().anchoredPosition = posini;}

        if(index==7){
            text.text = "QUERUBÍN";
            angel.gameObject.SetActive(false);
            arcangel.gameObject.SetActive(false);
            text.GetComponent<RectTransform>().anchoredPosition = posini;}

        if(index==8){
            text.text = "SERAFÍN";
            angel.gameObject.SetActive(false);
            arcangel.gameObject.SetActive(false);
            text.GetComponent<RectTransform>().anchoredPosition = posini;}

            
        if(index!=0){
            if(pas.angeles_bloqueados[index-1]){
                
                Reset_angel();
                total_angeles[index].SetActive(true);
                mejcon.comun.SetActive(false);
                mejcon.desbloquear.SetActive(true);
            }
            else{
                ponerAngel(index);
            }
        }
        else{
            ponerAngel(index);
        }
    }
    public void desbloquearangel(){
        Debug.Log(PrecioDesbloqueoAngeles.Count);
        Debug.Log(ind);
        if(pas.experiencia>=PrecioDesbloqueoAngeles[ind]){
            pas.experiencia = pas.experiencia-PrecioDesbloqueoAngeles[ind];
            mejcon.comun.SetActive(true);
            mejcon.desbloquear.SetActive(false);
            pas.angeles_bloqueados[ind-1]=false;
            ponerAngel(ind);
            mejcon.ActualizarCandados();
        }
        else{Debug.Log("No hay suficiente experiencia");}
    }

    
}
