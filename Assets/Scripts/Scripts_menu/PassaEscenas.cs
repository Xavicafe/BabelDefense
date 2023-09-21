using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PassaEscenas : Singleton<PassaEscenas>
{
    public float experiencia=0; 

    //angel simple
    public int rango_angelsimple=0;
    public int daño_angelsimple=0;
    public int cadencia_angelsimple=0;

    //Arcangel
    public int rango_arcangel=0;
    public int daño_arcangel=0;
    public int cadencia_arcangel=0;

    //Principado
    public int rango_principado=0;
    public int daño_principado=0;
    public int cadencia_principado=0;

    //Virtud
    public int rango_virtud=0;
    public int daño_virtud=0;
    public int cadencia_virtud=0;

    //Potestad
    public int rango_potestad=0;
    public int daño_potestad=0;
    public int cadencia_potestad=0;

    //Dominio
    public int rango_dominio=0;
    public int daño_dominio=0;
    public int cadencia_dominio=0;

    //Trono
    public int rango_trono=0;
    public int daño_trono=0;
    public int cadencia_trono=0;

    //Querubin
    public int rango_querubin=0;
    public int daño_querubin=0;
    public int cadencia_querubin=0;

    //Serafin
    public int rango_serafin=0;
    public int daño_serafin=0;
    public int cadencia_serafin=0;



    //habilidades
    public int duracion_EH=0;
    public int slow_EH=0;
    public int cooldown_EH=0;

    public int duracion_GF=0;
    public int amount_GF=0;
    public int cooldown_GF=0;

    public int duracion_A=0;
    public int damage_A=0;
    public int cooldown_A=0;

    //torre
    public int n_pisos=1;

    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddEXP(int exp)
    {
        experiencia += exp;
    }

    public void RemoveEXP(int exp){
        experiencia -= exp;
    }

    

    
}
