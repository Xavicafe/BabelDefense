using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Seleccion_habilidades : MonoBehaviour
{
    public TMP_Text text;

    private PassaEscenas pas;
    public MejorasController mejcon;

    public List<GameObject> total_habilidades;

    void Start(){
        pas = GameObject.FindGameObjectWithTag("pasaescena").GetComponent<PassaEscenas>();
    }

    public void Reset_hability(){
        for(int i=0;i<total_habilidades.Count;i++){
            total_habilidades[i].SetActive(false);
        }
        

    }

    public void OnMouseDown(int index){
        mejcon.Reset();
        Reset_hability();

        if(index==1){
            mejcon.Mejora3.text="Relentización:";
            Debug.Log("Era de Hielo");
            total_habilidades[index].SetActive(true);
            text.text = "Era de Hielo";
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
            mejcon.Mejora3.text="Ganancia:";
            Debug.Log("Gold Fury");
            total_habilidades[index].SetActive(true);
            text.text = "Furia del Oro";

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
            mejcon.Mejora3.text="Daño:";
            Debug.Log("Apocalipsis");
            total_habilidades[index].SetActive(true);
            text.text = "Apocalipsis";

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
