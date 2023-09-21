using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class angel : MonoBehaviour
{
    private PassaEscenas pas;
    [HideInInspector]
    public int cadencia;
    [HideInInspector]
    public int daño;
    [HideInInspector]
    public int rango;

    public string Name;
    [HideInInspector]
    public float rangoIni = 1;
    public float range = 5f;

    public float fireRate = 1f;
    [HideInInspector]
    public float fireRateIni;
    private float fireCountdown = 0f;
    public GameObject bala;
    public Transform firePoint;
    
    private soldadito enemigo;
    public Transform target;
    public string tagEnemigo = "soldados";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public Animation anim;

    [Header("Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;

    public float damageOverTime = 20;
    [HideInInspector]
    public float damageOverTimeIni;
    public float slowAmount = 1f;

    SFXController controladorSFX;

    public List<GameObject> enemigos_a_rango;

    private float timeOfLastSpawn;
    private float creationRate = 0.5f;
    public List<GameObject> espadas;
    private bool marca=true;

    [HideInInspector]
    public bool[] mejora_cadencia={false,false,false,false,false};
    [HideInInspector]
    public bool[] mejora_daño={false,false,false,false,false};
    public bool[] mejora_rango={false,false,false,false,false};

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.red;
    }

    private void Start()
    {
        pas = GameObject.FindGameObjectWithTag("pasaescena").GetComponent<PassaEscenas>();
        Ajustar_max_mejoras();
        rangoIni=range;
        fireRateIni=fireRate;
        damageOverTimeIni=damageOverTime;
        if(Name=="Principado"){
            InvokeRepeating("Principado_attack", 0f, 0.3f);
        }
        else{
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }
    }
    void UpdateTarget() {
        //Targetea al enemigo mas cercano
        GameObject[] enemiesescl = GameObject.FindGameObjectsWithTag("esclavo");
        GameObject[] enemiessol = GameObject.FindGameObjectsWithTag(tagEnemigo);
        GameObject[] enemiesgig = GameObject.FindGameObjectsWithTag("gigante");
        GameObject[] enemies = enemiesescl.Concat(enemiessol).ToArray();
        enemies = enemies.Concat(enemiesgig).ToArray();
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemigo in enemies) {
            if(Mathf.Abs(transform.position.y-enemigo.transform.position.y)<=range/4){
                float distanceToEnemy = Vector3.Distance(transform.position, enemigo.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemigo;
                }
            }
        }

        //Si encontramos enemigo y esta en rango, disparamos
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            enemigo = nearestEnemy.GetComponent<soldadito>();
        }
        else
        {
            target = null;
        }
    }

    void Awake()
    {
        anim = GetComponent<Animation>();
    }

    private void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }
            }
            if(Name=="Principado"){
                foreach (GameObject enemigo in enemigos_a_rango) {
                    if(enemigo!=null){
                    enemigo.GetComponent<soldadito>().Slow(slowAmount);
                    enemigo.GetComponent<soldadito>().Impacto(damageOverTime * Time.deltaTime);
                    
                    }
                }
            }
            return;
            
        }

        if(Name!="Virtud"){
            LockOnTarget();
        }

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if(Name=="Virtud"){

                if(marca){
                    Disparar();   
                }
            }
            else{
                if (fireCountdown <= 0f)
                {
                    controladorSFX = GameObject.FindGameObjectWithTag("audiosfx").GetComponent<SFXController>();
                    controladorSFX.PlayDisparoAngel();
                    Disparar();
                    fireCountdown = fireRate;
                }

                fireCountdown -= Time.deltaTime;
            }
            
        }
    }
    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void Disparar() {
        if(Name=="Virtud"){
            StartCoroutine(Lanzamiento_espadas());
            return;
        }
        else{
            GameObject bulletGO = (GameObject)Instantiate(bala, firePoint.position, firePoint.rotation);
            disparo disparo = bulletGO.GetComponent<disparo>();
        

        if (disparo != null) {
            disparo.Seek(target);
        }
        }
    }
    void Laser()
    {
        enemigo.Impacto(damageOverTime * Time.deltaTime);
        enemigo.Slow(slowAmount);

        if (!lineRenderer.enabled)
        {
            controladorSFX = GameObject.FindGameObjectWithTag("audiosfx").GetComponent<SFXController>();
            controladorSFX.PlayLaserAngel();
            lineRenderer.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

    }

    void Principado_attack(){
        GameObject[] enemiesescl = GameObject.FindGameObjectsWithTag("esclavo");
        GameObject[] enemiessol = GameObject.FindGameObjectsWithTag(tagEnemigo);
        GameObject[] enemiesgig = GameObject.FindGameObjectsWithTag("gigante");
        GameObject[] enemies = enemiesescl.Concat(enemiessol).ToArray();
        enemies = enemies.Concat(enemiesgig).ToArray();
        enemigos_a_rango.Clear();
        foreach (GameObject enemigo in enemies) {
            if(Mathf.Abs(transform.position.y-enemigo.transform.position.y)<=range/4){
                float distanceToEnemy = Vector3.Distance(transform.position, enemigo.transform.position);
                if (distanceToEnemy <= range)
                {
                    Debug.Log("ANGEL:"+range);
                    enemigos_a_rango.Add(enemigo);
                }
            }
        }

    }

    IEnumerator Lanzamiento_espadas()
    {
        marca=false;
        for(int i=0; i<espadas.Count;i++){
            if(espadas[i].GetComponent<disparo>().IsReady && target!=null){
                espadas[i].GetComponent<disparo>().Seek(target);
                Debug.Log(Vector3.Distance(target.transform.position, transform.position));
                yield return new WaitForSeconds(creationRate);
            }
        }
        marca=true;
    }

    public void espada(Vector3 PosIni, GameObject espada){
        StartCoroutine(espadon(PosIni,espada));
    }

     IEnumerator espadon(Vector3 PosIni, GameObject espada)
    {

        espada.transform.position=PosIni;
        espada.gameObject.SetActive(false);  
        espada.GetComponent<disparo>().targeto=null;
        yield return new WaitForSeconds(3f);
        espada.gameObject.SetActive(true);
        espada.GetComponent<disparo>().IsReady=true;
    }


    public void Ajustar_max_mejoras(){
        if(Name=="Angel Simple"){
            cadencia=pas.cadencia_angelsimple;
            rango=pas.rango_angelsimple;
            daño=pas.daño_angelsimple;
        }
        if(Name=="Arcangel"){
            cadencia=pas.cadencia_arcangel;
            rango=pas.rango_arcangel;
            daño=pas.daño_arcangel;
        }
        if(Name=="Principado"){
            cadencia=pas.cadencia_principado;
            rango=pas.rango_principado;
            daño=pas.daño_principado;
        }
        if(Name=="Virtud"){
            cadencia=pas.cadencia_virtud;
            rango=pas.rango_virtud;
            daño=pas.daño_virtud;
        }
        if(Name=="Potestad"){
            cadencia=pas.cadencia_potestad;
            rango=pas.rango_potestad;
            daño=pas.daño_potestad;
        }
        if(Name=="Dominio"){
            cadencia=pas.cadencia_dominio;
            rango=pas.rango_dominio;
            daño=pas.daño_dominio;
        }
        if(Name=="Trono"){
            cadencia=pas.cadencia_trono;
            rango=pas.rango_trono;
            daño=pas.daño_trono;
        }
        if(Name=="Querubin"){
            cadencia=pas.cadencia_querubin;
            rango=pas.rango_querubin;
            daño=pas.daño_querubin;
        }
        if(Name=="Serafin"){
            cadencia=pas.cadencia_serafin;
            rango=pas.rango_serafin;
            daño=pas.daño_serafin;
        }
    }

    public void mejorar_Cadencia(int i){
        fireRate = fireRateIni / (1+(((float)i+1)/10));
        mejora_cadencia[i]=true;
    }
    public void mejorar_Rango(int i){
        range = rangoIni * (1+((float)i+1)/10);
        mejora_rango[i]=true;

    }
    public void mejorar_Daño(int i){
        if(Name=="Trono" || Name=="Principado"){
            damageOverTime = damageOverTimeIni * (1+((float)i+1)/10);
            mejora_daño[i]=true;
        }
        else if(Name=="Virtud"){
            for(int j =0 ; j<espadas.Count;j++){
                espadas[j].GetComponent<disparo>().damage = espadas[j].GetComponent<disparo>().damageIni * (1+((float)j+1)/10);
            } 
            mejora_daño[i]=true;
        }
        else{
            bala.GetComponent<disparo>().damage = bala.GetComponent<disparo>().damageIni * (1+((float)i+1)/10);
            mejora_daño[i]=true;
        }
    }
}
