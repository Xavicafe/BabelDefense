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
    public bool fullscreen;

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
        n_pisos=1;
        Cargar_DATOS();
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

    public void Cargar_DATOS(){

        experiencia = PlayerPrefs.GetFloat("experiencia");
        volume = PlayerPrefs.GetFloat("volumen");
        efects = PlayerPrefs.GetFloat("efectos");

        block_angelsimple = ConvertToBool(PlayerPrefs.GetInt("block_angelsimple"));
        rango_angelsimple = PlayerPrefs.GetInt("rango_angelsimple");
        daño_angelsimple = PlayerPrefs.GetInt("daño_angelsimple");
        cadencia_angelsimple = PlayerPrefs.GetInt("cadencia_angelsimple");

        block_arcangel = ConvertToBool(PlayerPrefs.GetInt("block_arcangel"));
        rango_arcangel = PlayerPrefs.GetInt("rango_arcangel");
        daño_arcangel = PlayerPrefs.GetInt("daño_arcangel");
        cadencia_arcangel = PlayerPrefs.GetInt("cadencia_arcangel");

        block_principado = ConvertToBool(PlayerPrefs.GetInt("block_principado"));
        rango_principado = PlayerPrefs.GetInt("rango_principado");
        daño_principado = PlayerPrefs.GetInt("daño_principado");
        cadencia_principado = PlayerPrefs.GetInt("cadencia_principado");

        block_virtud = ConvertToBool(PlayerPrefs.GetInt("block_virtud"));
        rango_virtud = PlayerPrefs.GetInt("rango_virtud");
        daño_virtud = PlayerPrefs.GetInt("daño_virtud");
        cadencia_virtud = PlayerPrefs.GetInt("cadencia_virtud");

        block_potestad = ConvertToBool(PlayerPrefs.GetInt("block_potestad"));
        rango_potestad = PlayerPrefs.GetInt("rango_potestad");
        daño_potestad = PlayerPrefs.GetInt("daño_potestad");
        cadencia_potestad = PlayerPrefs.GetInt("cadencia_potestad");

        block_dominio = ConvertToBool(PlayerPrefs.GetInt("block_dominio"));
        rango_dominio = PlayerPrefs.GetInt("rango_dominio");
        daño_dominio = PlayerPrefs.GetInt("daño_dominio");
        cadencia_dominio = PlayerPrefs.GetInt("cadencia_dominio");

        block_trono = ConvertToBool(PlayerPrefs.GetInt("block_trono"));
        rango_trono = PlayerPrefs.GetInt("rango_trono");
        daño_trono = PlayerPrefs.GetInt("daño_trono");
        cadencia_trono = PlayerPrefs.GetInt("cadencia_trono");

        block_querubin = ConvertToBool(PlayerPrefs.GetInt("block_querubin"));
        rango_querubin = PlayerPrefs.GetInt("rango_querubin");
        daño_querubin = PlayerPrefs.GetInt("daño_querubin");
        cadencia_querubin = PlayerPrefs.GetInt("cadencia_querubin");

        block_serafin = ConvertToBool(PlayerPrefs.GetInt("block_serafin"));
        rango_serafin = PlayerPrefs.GetInt("rango_serafin");
        daño_serafin = PlayerPrefs.GetInt("daño_serafin");
        cadencia_serafin = PlayerPrefs.GetInt("cadencia_serafin");

        duracion_EH = PlayerPrefs.GetInt("duracion_EH");
        cooldown_EH = PlayerPrefs.GetInt("cooldown_EH");
        slow_EH = PlayerPrefs.GetInt("slow_EH");

        duracion_A = PlayerPrefs.GetInt("duracion_A");
        cooldown_A = PlayerPrefs.GetInt("cooldown_A");
        damage_A = PlayerPrefs.GetInt("damage_A");

        duracion_GF = PlayerPrefs.GetInt("duracion_GF");
        cooldown_GF = PlayerPrefs.GetInt("cooldown_GF");
        amount_GF = PlayerPrefs.GetInt("amount_GF");

        n_pisos = PlayerPrefs.GetInt("n_pisos");

    }

    public void Pasar_a_variables(){
        block_arcangel=angeles_bloqueados[0];
        block_principado=angeles_bloqueados[1];
        block_virtud=angeles_bloqueados[2];
        block_potestad=angeles_bloqueados[3];
        block_dominio=angeles_bloqueados[4];
        block_trono=angeles_bloqueados[5];
        block_querubin=angeles_bloqueados[6];
        block_serafin=angeles_bloqueados[7];

    }

    public void Guardar_datos(){

        //Pasar_a_variables();

        PlayerPrefs.SetFloat("experiencia",experiencia);
        PlayerPrefs.SetFloat("volumen",volume);
        PlayerPrefs.SetFloat("efectos",efects);

        PlayerPrefs.SetInt("block_angelsimple",ConvertToInt(block_angelsimple));
        PlayerPrefs.SetInt("rango_angelsimple",rango_angelsimple);
        PlayerPrefs.SetInt("daño_angelsimple",daño_angelsimple);
        PlayerPrefs.SetInt("cadencia_angelsimple",cadencia_angelsimple);

        PlayerPrefs.SetInt("block_arcangel",ConvertToInt(block_arcangel));
        PlayerPrefs.SetInt("rango_arcangel",rango_arcangel);
        PlayerPrefs.SetInt("daño_arcangel",daño_arcangel);
        PlayerPrefs.SetInt("cadencia_arcangel",cadencia_arcangel);

        PlayerPrefs.SetInt("block_principado",ConvertToInt(block_principado));
        PlayerPrefs.SetInt("rango_principado",rango_principado);
        PlayerPrefs.SetInt("daño_principado",daño_principado);
        PlayerPrefs.SetInt("cadencia_principado",cadencia_principado);

        PlayerPrefs.SetInt("block_virtud",ConvertToInt(block_virtud));
        PlayerPrefs.SetInt("rango_virtud",rango_virtud);
        PlayerPrefs.SetInt("daño_virtud",daño_virtud);
        PlayerPrefs.SetInt("cadencia_virtud",cadencia_virtud);

        PlayerPrefs.SetInt("block_potestad",ConvertToInt(block_potestad));
        PlayerPrefs.SetInt("rango_potestad",rango_potestad);
        PlayerPrefs.SetInt("daño_potestad",daño_potestad);
        PlayerPrefs.SetInt("cadencia_potestad",cadencia_potestad);

        PlayerPrefs.SetInt("block_dominio",ConvertToInt(block_dominio));
        PlayerPrefs.SetInt("rango_dominio",rango_dominio);
        PlayerPrefs.SetInt("daño_dominio",daño_dominio);
        PlayerPrefs.SetInt("cadencia_dominio",cadencia_dominio);

        PlayerPrefs.SetInt("block_trono",ConvertToInt(block_trono));
        PlayerPrefs.SetInt("rango_trono",rango_trono);
        PlayerPrefs.SetInt("daño_trono",daño_trono);
        PlayerPrefs.SetInt("cadencia_trono",cadencia_trono);

        PlayerPrefs.SetInt("block_querubin",ConvertToInt(block_querubin));
        PlayerPrefs.SetInt("rango_querubin",rango_querubin);
        PlayerPrefs.SetInt("daño_querubin",daño_querubin);
        PlayerPrefs.SetInt("cadencia_querubin",cadencia_querubin);

        PlayerPrefs.SetInt("block_serafin",ConvertToInt(block_serafin));
        PlayerPrefs.SetInt("rango_serafin",rango_serafin);
        PlayerPrefs.SetInt("daño_serafin",daño_serafin);
        PlayerPrefs.SetInt("cadencia_serafin",cadencia_serafin);


        PlayerPrefs.SetInt("duracion_EH",duracion_EH);
        PlayerPrefs.SetInt("slow_EH",slow_EH);
        PlayerPrefs.SetInt("cooldown_EH",cooldown_EH);

        PlayerPrefs.SetInt("duracion_GF",duracion_GF);
        PlayerPrefs.SetInt("amount_GF",amount_GF);
        PlayerPrefs.SetInt("cooldown_GF",cooldown_GF);

        PlayerPrefs.SetInt("duracion_A",duracion_A);
        PlayerPrefs.SetInt("damage_A",damage_A);
        PlayerPrefs.SetInt("cooldown_A",cooldown_A);

        PlayerPrefs.SetInt("n_pisos",n_pisos);


    }
    public int ConvertToInt(bool bol){
        if(bol){
            return 1;
        }else{return 0;}
    }

    public bool ConvertToBool(int i){
        if(i==1){
            return true;
        }else{return false;}
    }

    

    
}
