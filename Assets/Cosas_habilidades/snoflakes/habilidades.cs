using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class habilidades : MonoBehaviour
{
    public GameObject EraHielo;
    public GameObject particlesEH;
    public GameObject GoldFury;
    public GameObject GoldFury1;
    public GameObject GoldFury2;
    public GameObject Apocalipsis;
    public GameObject Apocalipsis_rojo;
    private AudioSource audioSource;
    public AudioClip hielo;
    public AudioClip dinero;
    public AudioClip helldrums;
    public bool IsGoldFury=false;
    public bool IsEraHielo=false;
    public bool IsApocalipsis=false;

    public int cooldown_Todas_Hab=20;
    public int Duracion_GoldFury=30;
    public int Duracion_Apocalipsis=10;
    public int Duracion_EraHielo=20;

    public int Daño_Base_A;
    public float Slow_Base_EH;

    public gen_meteors gene;


    [HideInInspector]
    public int daño_A;
    [HideInInspector]
    public int duracion_A;
    [HideInInspector]
    public int cooldown_A;

    [HideInInspector]
    public int duracion_EH;
    [HideInInspector]
    public int cooldown_EH;
    [HideInInspector]
    public int slow_EH;

    [HideInInspector]
    public int duracion_GF;
    [HideInInspector]
    public int cooldown_GF;
    [HideInInspector]
    public int amount_GF;

    public PassaEscenas pas;

    // Start is called before the first frame update
    void Start()
    {
        pas = GameObject.FindGameObjectWithTag("pasaescena").GetComponent<PassaEscenas>();

        
        duracion_A = pas.duracion_A;
        duracion_EH = pas.duracion_EH;
        duracion_GF = pas.duracion_GF;

        cooldown_A = pas.cooldown_A;
        cooldown_EH = pas.cooldown_EH;
        cooldown_GF = pas.cooldown_GF;

        slow_EH=pas.slow_EH;
        daño_A = pas.damage_A;
        amount_GF = pas.amount_GF;

        audioSource = GetComponent<AudioSource>();
    }

    public void Activacion_EraHielo(Button but)
    {
        if(!IsApocalipsis && !IsEraHielo && !IsGoldFury){
            IsEraHielo=true;
            StartCoroutine(DelayEraHielo(but));
            // Activa el objeto
            EraHielo.SetActive(true);
            particlesEH.SetActive(true);

            // Obtén el componente Animator del objeto
            Animator animator = EraHielo.GetComponent<Animator>();
            animator.SetBool("Activo", true);
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(hielo);
            
        }
        else{
            Debug.Log("Ya tienes una habilidad usandose");
        }
    }
    public void Desactivacion_EraHielo(Button but){
        Animator animator = EraHielo.GetComponent<Animator>();
        animator.SetBool("Activo", false);
        particlesEH.SetActive(false);
        StartCoroutine(CooldownHab("EH",but));
    }

    public void Activacion_GoldFury(Button but)
    {
        if(!IsApocalipsis && !IsEraHielo && !IsGoldFury){
            IsGoldFury=true;
            StartCoroutine(DelayGoldFury(but));
            // Activa el objeto
            GoldFury.SetActive(true);
            GameObject[] lista = GameObject.FindGameObjectsWithTag("coin");
            List<GameObject> coins = new List<GameObject>();
            coins.AddRange(lista);
            for(int i=0; i<coins.Count;i++){
                lista[i].GetComponent<coins>().marca=true;
            }
            // Obtén el componente Animator del objeto
            Animator animator = GoldFury1.GetComponent<Animator>();
            animator.SetBool("Activo", true);
            Animator animator1 = GoldFury2.GetComponent<Animator>();
            animator1.SetBool("Activo", true);
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(dinero);
        }
        else{
            Debug.Log("Ya tienes una habilidad usandose");
        }
    }
    public void Desactivacion_GoldFury(Button but){
        Animator animator = GoldFury1.GetComponent<Animator>();
        animator.SetBool("Activo", false);
        Animator animator1 = GoldFury2.GetComponent<Animator>();
        animator1.SetBool("Activo", false);
        StartCoroutine(CooldownHab("GF",but));
    }

    public void Activacion_Apocalipsis(Button but)
    {
        if(!IsApocalipsis && !IsEraHielo && !IsGoldFury){
            IsApocalipsis=true;
            StartCoroutine(DelayApocalipsis(but));
            
            // Activa el objeto
            Apocalipsis_rojo.SetActive(true);
            gene.Start_meteors();
            Animator animator = Apocalipsis_rojo.GetComponent<Animator>();
            animator.SetBool("Activo", true);
            Apocalipsis.SetActive(true);
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(helldrums);
        }
        else{
            Debug.Log("Ya tienes una habilidad usandose");
        }
    }
    public void Desactivacion_Apocalipsis(Button but){
        Animator animator = Apocalipsis_rojo.GetComponent<Animator>();
        animator.SetBool("Activo", false);
        StartCoroutine(CooldownHab("A",but));
    }


    IEnumerator DelayApocalipsis(Button but)
    {
        yield return new WaitForSeconds(Duracion_Apocalipsis * (1+((float)duracion_A+1)/10));
        Desactivacion_Apocalipsis(but);
        IsApocalipsis=false;

    }
    IEnumerator DelayGoldFury(Button but)
    {
        yield return new WaitForSeconds(Duracion_GoldFury * (1+((float)duracion_GF+1)/10));
        Desactivacion_GoldFury(but);
        IsGoldFury=false;
    }
    IEnumerator DelayEraHielo(Button but)
    {
        yield return new WaitForSeconds(Duracion_EraHielo * (1+((float)duracion_EH+1)/10));
        Desactivacion_EraHielo(but);
        IsEraHielo=false;
    }

    IEnumerator CooldownHab(string hab, Button but)
    {
        if(hab=="GF"){
            but.interactable=false;
            StartCoroutine(ActualizarTexto(but,cooldown_Todas_Hab / (1+((float)cooldown_GF+1)/10)));
            yield return new WaitForSeconds(cooldown_Todas_Hab / (1+((float)cooldown_GF+1)/10));
            but.interactable=true;
        }
        if(hab=="EH"){
            but.interactable=false;
            StartCoroutine(ActualizarTexto(but,cooldown_Todas_Hab / (1+((float)cooldown_EH+1)/10)));
            yield return new WaitForSeconds(cooldown_Todas_Hab / (1+((float)cooldown_EH+1)/10));
            but.interactable=true;
        }
        if(hab=="A"){
            but.interactable=false;
            StartCoroutine(ActualizarTexto(but,cooldown_Todas_Hab / (1+((float)cooldown_A+1)/10)));
            yield return new WaitForSeconds(cooldown_Todas_Hab / (1+((float)cooldown_A+1)/10));
            but.interactable=true;
        }

    }

    private System.Collections.IEnumerator ActualizarTexto(Button but, float tiempo)
    {
        TMP_Text buttonText = but.GetComponentInChildren<TMP_Text>();
        string Ini = buttonText.text;
        float timeRemaining = tiempo;
        while (timeRemaining > 0f)
        {
            buttonText.text=timeRemaining.ToString("0");
            yield return new WaitForSeconds(1f);
            timeRemaining--;
        }
        buttonText.text=Ini;

    }
}
