using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PassaEscenas : Singleton<PassaEscenas>
{
    public float experiencia=0; 
    public float volume;
    public float efects;

    //angel simple
    public bool block_angelsimple = false;
    public int rango_angelsimple=0;
    public int daño_angelsimple=0;
    public int cadencia_angelsimple=0;

    //Arcangel
    public bool block_arcangel = true;
    public int rango_arcangel=0;
    public int daño_arcangel=0;
    public int cadencia_arcangel=0;

    //Principado
    public bool block_principado = true;
    public int rango_principado=0;
    public int daño_principado=0;
    public int cadencia_principado=0;

    //Virtud
    public bool block_virtud = true;
    public int rango_virtud=0;
    public int daño_virtud=0;
    public int cadencia_virtud=0;

    //Potestad
    public bool block_potestad = true;
    public int rango_potestad=0;
    public int daño_potestad=0;
    public int cadencia_potestad=0;

    //Dominio
    public bool block_dominio = true;
    public int rango_dominio=0;
    public int daño_dominio=0;
    public int cadencia_dominio=0;

    //Trono
    public bool block_trono = true;
    public int rango_trono=0;
    public int daño_trono=0;
    public int cadencia_trono=0;

    //Querubin
    public bool block_querubin = true;
    public int rango_querubin=0;
    public int daño_querubin=0;
    public int cadencia_querubin=0;

    //Serafin
    public bool block_serafin = true;
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
    public List<bool> angeles_bloqueados;

    

    // Start is called before the first frame update
    void Start()
    {
        volume = 75;
        efects = 75;
        angeles_bloqueados = new List<bool> { block_arcangel , block_principado , block_virtud , block_potestad , block_dominio , block_trono , block_querubin , block_serafin};
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
