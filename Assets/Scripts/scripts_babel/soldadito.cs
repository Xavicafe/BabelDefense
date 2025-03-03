using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soldadito : MonoBehaviour
{
    public float vel = 0.4f;
    public float vida = 100f;
    public float vida_max;
    private bool marca=false;
    private bool final=false;
    private bool pos_in=false;
    public int dinero = 50;
    [HideInInspector]
    public int dineroIni;
    public Vector3 target;
    public Vector3 target2;
    public Vector3 escaleras;
    public Vector3 torre;
    public float vel_rotacion =2;
    public float vel_recta =50;
    public float vel_final =50;
    private float velocidadInicial_rot;
    private float velocidadInicial_rect;
    public int piso;
    public Slider slider;
    public Camera camara;
    public Collider collider;
    public habilidades habilidades;

    SFXController controladorSFX;

    public bool habili=false;

    public GameObject quemado;
    public GameObject sangrado;
    public float aumentoVida = 0.00f;

    private void Start()
    {
        generador lvlm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<generador>();
        if(lvlm.indiceOleada>10){
            aumentoVida = lvlm.indiceOleada/100f;
            vida = vida * (1+ (aumentoVida*2));
        }
        collider = GetComponent<Collider>();
        habilidades=GameObject.FindGameObjectWithTag("habilidades").GetComponent<habilidades>();
        velocidadInicial_rot = vel_rotacion;
        velocidadInicial_rect=vel_recta;
        camara=Camera.main;
        dineroIni=dinero;
        vida_max=vida;
        slider.maxValue=vida_max;
    }
    void Update()
    {   
        if(habilidades.IsEraHielo && !habili){
            habili=true;
            Slow((float)(habilidades.Slow_Base_EH * (1+((float)habilidades.slow_EH+1)/10)));
            habili=false;
        }
        if(habilidades.IsGoldFury && !habili){
            habili=true;
            StartCoroutine(EfectoGoldFury());
        }
        if(habilidades.IsApocalipsis && !habili){
            habili=true;
            StartCoroutine(EfectoApocalipsis());
        }
        slider.transform.LookAt(camara.transform.position);
        slider.value=vida;
        if(pos_in==true){
            if(marca && final==false){
            transform.RotateAround(target2, new Vector3(0,1,0), vel_rotacion*Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, target2,vel*Time.deltaTime);
            }
            else if(marca==false){
            transform.position = Vector3.MoveTowards(transform.position, target,vel_recta*Time.deltaTime);
            }
            else{
            transform.position = Vector3.MoveTowards(transform.position, escaleras,vel_final*Time.deltaTime);
            }

            if(transform.position.magnitude-target.magnitude<0.1){
            marca=true;
            }
        }else{ 
            transform.position = Vector3.MoveTowards(transform.position, torre,vel_recta*Time.deltaTime);
            
        }
        DeSlow();
        
    }
    private void movimientoPiso1()
    {

    }
    private void movimientoPiso2()
    {

    }
    void OnTriggerEnter (Collider other) {
        if (other.CompareTag("checkpoint")){
            controladorSFX = GameObject.FindGameObjectWithTag("audiosfx").GetComponent<SFXController>();
            controladorSFX.PlayHumanoAtaque();

            Destroy (gameObject);
        }
        if (other.CompareTag("final")){
            final=true;
        }
        if (other.CompareTag("inicio")){
            pos_in=true;
        }
    }
    public void Impacto(float damage){
        vida=vida-damage;
        if (vida<=0)
        {
            StopAllCoroutines();
            Die();
        }
    }
    public void quemado_sangrado(string t, float damage){
        if(t=="quemado"){
            GameObject hijo = Instantiate(quemado, transform.position, Quaternion.identity);
            hijo.transform.parent = transform;
            StartCoroutine(DamageSangrado_DamageQuemado(damage,hijo));

        }
        if(t=="sangrado"){
            GameObject hijo = Instantiate(sangrado, transform.position, Quaternion.identity);
            hijo.transform.parent = transform;
            hijo.transform.rotation *= Quaternion.Euler(-120f,0f,0);
            StartCoroutine(DamageSangrado_DamageQuemado(damage,hijo));
        }
    }
    public void Die()
    {
        StopAllCoroutines();
        controladorSFX = GameObject.FindGameObjectWithTag("audiosfx").GetComponent<SFXController>();
        controladorSFX.PlayHumanoMurte();
        PlayerStats.Money += dinero;
        generador.TotalUnidades--;
        Destroy(gameObject);
        
    }
    public void Slow(float pct)
    {
        vel_rotacion = velocidadInicial_rot * (1f - pct);
        vel_recta = velocidadInicial_rect * (1f - pct);
    }
    public void DeSlow()
    {
        vel_rotacion = velocidadInicial_rot;
        vel_recta = velocidadInicial_rect;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "soldados" || collision.gameObject.tag == "gigante" || collision.gameObject.tag == "esclavo")
        {
            Physics.IgnoreCollision(collision.collider, collider);
        }
    }

    IEnumerator EfectoApocalipsis()
    {
        
        float damageIni = habilidades.Daño_Base_A * (1+((float)habilidades.daño_A+1)/10);
        
        float damage=damageIni;
        while(damage>=0){
            Impacto(damageIni/10);
            yield return new WaitForSeconds((habilidades.Duracion_Apocalipsis * (1+((float)habilidades.duracion_A+1)/10))/10);
            damage-=damageIni/10;
        }
        habili=false;

    }
    IEnumerator EfectoGoldFury()
    {
        dinero = (int)(dineroIni * (float)(1+((float)habilidades.amount_GF+1)/10));
        yield return new WaitForSeconds(3);
        dinero = dineroIni;
        habili=false;
    }

    IEnumerator DamageSangrado_DamageQuemado(float damage, GameObject efecto)
    {
        float damageIni=damage;
        while(damage>=0 && vida > 0){
            Impacto(damageIni/10);
            yield return new WaitForSeconds(0.8f);
            damage-=damageIni/10;
        }
        Destroy(efecto);

        

    }
}
