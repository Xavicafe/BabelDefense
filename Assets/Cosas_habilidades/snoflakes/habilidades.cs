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
    public GameObject GoldFury2;
    public GameObject Apocalipsis;
    public GameObject Apocalipsis_rojo;
    private AudioSource audioSource;
    public AudioClip hielo;
    public AudioClip dinero;
    public AudioClip helldrums;

    public Image Cooldown_Image_EH;
    public Image Cooldown_Image_GF;
    public Image Cooldown_Image_A;

    public Slider Slider_Image_EH;
    public Slider Slider_Image_GF;
    public Slider Slider_Image_A;

    public bool IsGoldFury=false;
    public bool IsEraHielo=false;
    public bool IsApocalipsis=false;

    public int cooldown_Todas_Hab=20;
    public int Duracion_GoldFury=30;
    public int Duracion_Apocalipsis=10;
    public int Duracion_EraHielo=20;

    public TMP_Text CosteEDHText;
    public TMP_Text CosteAText;
    public TMP_Text CosteGFText;
    public int Precio_GoldFury=50;
    public int Precio_Apocalipsis=200;
    public int Precio_EraHielo=100;

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

    public GameObject monedas;

    // Start is called before the first frame update
    void Start()
    {
        CosteEDHText.text = Precio_EraHielo.ToString();
        CosteAText.text = Precio_Apocalipsis.ToString();
        CosteGFText.text = Precio_GoldFury.ToString();
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

        monedas.GetComponent<ParticleSystem>().Stop();

            
            duracion_A = pas.duracion_A;
            duracion_EH = pas.duracion_EH;
            duracion_GF = pas.duracion_GF;

            cooldown_A = pas.cooldown_A;
            cooldown_EH = pas.cooldown_EH;
            cooldown_GF = pas.cooldown_GF;

            slow_EH=pas.slow_EH;
            daño_A = pas.damage_A;
            amount_GF = pas.amount_GF;

            Cooldown_Image_EH.fillAmount = 0.0f;
            Cooldown_Image_GF.fillAmount = 0.0f;
            Cooldown_Image_A.fillAmount = 0.0f;

            audioSource = GetComponent<AudioSource>();

        Debug.Log("habilidades: PassaEscenas inicializado correctamente");
    }

    public void Activacion_EraHielo(Button but)
    {
        if(!IsApocalipsis && !IsEraHielo && !IsGoldFury){
            if(PlayerStats.Money < Precio_EraHielo){
                Debug.Log("No tienes suficiente dinero");
            }
            else{
                Slider_Image_EH.gameObject.SetActive(true);
                Slider_Image_EH.value=0.0f;

                PlayerStats.Money -= Precio_EraHielo;
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
            if(PlayerStats.Money < Precio_GoldFury){
                Debug.Log("No tienes suficiente dinero");
            }
            else{
                Slider_Image_GF.gameObject.SetActive(true);
                PlayerStats.Money -= Precio_GoldFury;
                IsGoldFury=true;
                StartCoroutine(DelayGoldFury(but));
                // Activa el objeto
                GoldFury.SetActive(true);
                monedas.GetComponent<ParticleSystem>().Play();
                // Obtén el componente Animator del objeto
                Animator animator1 = GoldFury2.GetComponent<Animator>();
                animator1.SetBool("Activo", true);
                audioSource = GetComponent<AudioSource>();
                audioSource.PlayOneShot(dinero);
            }
        }
        else{
            Debug.Log("Ya tienes una habilidad usandose");
        }
    }
    public void Desactivacion_GoldFury(Button but){
        monedas.GetComponent<ParticleSystem>().Stop();
        Animator animator1 = GoldFury2.GetComponent<Animator>();
        animator1.SetBool("Activo", false);
        StartCoroutine(CooldownHab("GF",but));
    }

    public void Activacion_Apocalipsis(Button but)
    {
        if(!IsApocalipsis && !IsEraHielo && !IsGoldFury){
            if(PlayerStats.Money < Precio_Apocalipsis){
                Debug.Log("No tienes suficiente dinero");
            }
            else{
                Slider_Image_A.gameObject.SetActive(true);
                PlayerStats.Money -= Precio_Apocalipsis;
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
        StartCoroutine(Actualizar_Slider(Slider_Image_A, Duracion_Apocalipsis * (1+((float)duracion_A+1)/10)));
        yield return new WaitForSeconds(Duracion_Apocalipsis * (1+((float)duracion_A+1)/10));
        Desactivacion_Apocalipsis(but);
        Slider_Image_A.gameObject.SetActive(false);
        IsApocalipsis=false;

    }
    IEnumerator DelayGoldFury(Button but)
    {
        StartCoroutine(Actualizar_Slider(Slider_Image_GF, Duracion_GoldFury * (1+((float)duracion_GF+1)/10)));
        yield return new WaitForSeconds(Duracion_GoldFury * (1+((float)duracion_GF+1)/10));
        Desactivacion_GoldFury(but);
        Slider_Image_GF.gameObject.SetActive(false);
        IsGoldFury=false;
    }
    IEnumerator DelayEraHielo(Button but)
    {
        StartCoroutine(Actualizar_Slider(Slider_Image_EH, Duracion_EraHielo * (1+((float)duracion_EH+1)/10)));
        yield return new WaitForSeconds(Duracion_EraHielo * (1+((float)duracion_EH+1)/10));
        Desactivacion_EraHielo(but);
        Slider_Image_EH.gameObject.SetActive(false);
        IsEraHielo=false;
    }

    IEnumerator CooldownHab(string hab, Button but)
    {
        if(hab=="GF"){
            but.interactable=false;
            StartCoroutine(ActualizarTexto(but,cooldown_Todas_Hab / (1+((float)cooldown_GF+1)/10),Cooldown_Image_GF));
            yield return new WaitForSeconds(cooldown_Todas_Hab / (1+((float)cooldown_GF+1)/10));
            
        }
        if(hab=="EH"){
            but.interactable=false;
            StartCoroutine(ActualizarTexto(but,cooldown_Todas_Hab / (1+((float)cooldown_EH+1)/10),Cooldown_Image_EH));
            yield return new WaitForSeconds(cooldown_Todas_Hab / (1+((float)cooldown_EH+1)/10));
            
        }
        if(hab=="A"){
            but.interactable=false;
            StartCoroutine(ActualizarTexto(but,cooldown_Todas_Hab / (1+((float)cooldown_A+1)/10),Cooldown_Image_A));
            yield return new WaitForSeconds(cooldown_Todas_Hab / (1+((float)cooldown_A+1)/10));
            
        }

    }

    private System.Collections.IEnumerator ActualizarTexto(Button but, float tiempo, Image im)
    {
        
        im.fillAmount = 1.0f;
        StartCoroutine(Actualizar_Imagen_Cooldown(but, im, tiempo));
        TMP_Text buttonText = but.GetComponentInChildren<TMP_Text>();
        string Ini = buttonText.text;
        float timeRemaining = tiempo;
        while (timeRemaining >= 0f)
        {
            //buttonText.text=timeRemaining.ToString("0");
            yield return new WaitForSeconds(1f);
            timeRemaining--;
        }
        buttonText.text=Ini;

    }
    private System.Collections.IEnumerator Actualizar_Imagen_Cooldown(Button but, Image im, float tiempo){
        float tiempo_rest = tiempo;
        while(tiempo_rest >= 0){
            
            tiempo_rest -= 0.25f;
            im.fillAmount = tiempo_rest / tiempo;
            yield return new WaitForSeconds(0.25f);
        }
        but.interactable=true;
    }

    private System.Collections.IEnumerator Actualizar_Slider(Slider slider, float tiempo){
        float tiempo_rest = 0;
        while(tiempo_rest <= tiempo){
            tiempo_rest += 0.25f;
            slider.value = tiempo_rest / tiempo;
            yield return new WaitForSeconds(0.25f);
        }
    }

}
