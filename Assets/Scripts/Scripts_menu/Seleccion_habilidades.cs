using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Seleccion_habilidades : MonoBehaviour
{
    public TMP_Text text;
    public TMP_Text text1;
    public TMP_Text text2;


    private PassaEscenas pas;
    public MejorasController mejcon;

    public List<GameObject> total_habilidades;
    private Vector3 posini;

    void Start(){
        posini = new Vector3(0,-3.6716e-05f,0);
        pas = GameObject.FindGameObjectWithTag("pasaescena").GetComponent<PassaEscenas>();
    }

    public void Reset_hability(){
        for(int i=0;i<total_habilidades.Count;i++){
            total_habilidades[i].SetActive(false);
        }
        

    }

    public void OnMouseDown(int index){
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        text.GetComponent<RectTransform>().anchoredPosition = posini;
        mejcon.Reset();
        Reset_hability();

        if(index==1){
            mejcon.Mejora3.gameObject.SetActive(false);
            mejcon.Mejora3_Ganancia.gameObject.SetActive(false);
            mejcon.Mejora3_Relen.gameObject.SetActive(true);
            mejcon.Mejora3_Daño.gameObject.SetActive(false);
            Debug.Log("Era de Hielo");
            total_habilidades[index].SetActive(true);
            text.text = "ERA DE HIELO";
            for(int i=0;i<=pas.duracion_EH;i++){
                mejcon.estrellas_rango[i].SetActive(true);
            }
            for(int i=0;i<=pas.cooldown_EH;i++){
                mejcon.estrellas_daño[i].SetActive(true);
            }
            for(int i=0;i<=pas.slow_EH;i++){
                mejcon.estrellas_cadencia[i].SetActive(true);
            }
        }
        if(index==0){
            mejcon.Mejora3.gameObject.SetActive(false);
            mejcon.Mejora3_Ganancia.gameObject.SetActive(true);
            mejcon.Mejora3_Relen.gameObject.SetActive(false);
            mejcon.Mejora3_Daño.gameObject.SetActive(false);
            Debug.Log("Gold Fury");
            total_habilidades[index].SetActive(true);
            text.text = "FURIA DEL ORO";

            for(int i=0;i<=pas.duracion_GF;i++){
                mejcon.estrellas_rango[i].SetActive(true);
            }
            for(int i=0;i<=pas.cooldown_GF;i++){
                mejcon.estrellas_daño[i].SetActive(true);
            }
            for(int i=0;i<=pas.amount_GF;i++){
                mejcon.estrellas_cadencia[i].SetActive(true);
            }
        }
        if(index==2){
            mejcon.Mejora3.gameObject.SetActive(false);
            mejcon.Mejora3_Ganancia.gameObject.SetActive(false);
            mejcon.Mejora3_Relen.gameObject.SetActive(false);
            mejcon.Mejora3_Daño.gameObject.SetActive(true);
            Debug.Log("Apocalipsis");
            total_habilidades[index].SetActive(true);
            text.text = "APOCALIPSIS";

            for(int i=0;i<=pas.duracion_A;i++){
                mejcon.estrellas_rango[i].SetActive(true);
            }
            for(int i=0;i<=pas.cooldown_A;i++){
                mejcon.estrellas_daño[i].SetActive(true);
            }
            for(int i=0;i<=pas.damage_A;i++){
                mejcon.estrellas_cadencia[i].SetActive(true);
            }
        }
    }

    
}
