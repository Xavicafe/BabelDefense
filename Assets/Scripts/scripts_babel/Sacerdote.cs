using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class Sacerdote : MonoBehaviour
{

    public float range = 5f;
    private soldadito enemigo;
    public Transform target;
    public int curacion = 5;

    public float fireRate = 2f;
    private float fireCountdown = 0f;

    public GameObject baston;

    public Material targetMaterial;
    public float transitionDuration = 2.0f;
    private float transitionProgress = 0.0f;
    private Material originalMaterial;
    public List<soldadito> aliados_cerca;

    // Start is called before the first frame update
    void Start()
    {
        originalMaterial = baston.GetComponent<Renderer>().material;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        InvokeRepeating("StartTransition", 0f, fireRate);
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (target == null)
        {
            return;
        }
        else{
            if(target!=null){
            transitionProgress += Time.deltaTime / transitionDuration;
            baston.GetComponent<Renderer>().material.Lerp(originalMaterial, targetMaterial, transitionProgress);
            }
            if (fireCountdown <= 0f)
                {
                    Curar();
                    fireCountdown = fireRate;
                }

                fireCountdown -= Time.deltaTime;
        }
    }

    void UpdateTarget() {
        //Targetea al enemigo mas cercano
        aliados_cerca = new List<soldadito>();
        GameObject[] enemiesescl = GameObject.FindGameObjectsWithTag("esclavo");
        GameObject[] enemiessol = GameObject.FindGameObjectsWithTag("soldados");
        GameObject[] enemiesgig = GameObject.FindGameObjectsWithTag("gigante");
        GameObject[] enemies = enemiesescl.Concat(enemiessol).ToArray();
        enemies = enemies.Concat(enemiesgig).ToArray();
        foreach (GameObject enemigo in enemies) {
            if(Mathf.Abs(transform.position.y-enemigo.transform.position.y)<=range/5){
                float distanceToEnemy = Vector3.Distance(transform.position, enemigo.transform.position);
                if (distanceToEnemy <= range)
                {
                    aliados_cerca.Add(enemigo.GetComponent<soldadito>());
                }
            }
        }

        if(aliados_cerca.Count>0){
            for(int i=0; i<aliados_cerca.Count;i++){
                if(aliados_cerca[i].vida!=aliados_cerca[i].vida_max){
                    target = aliados_cerca[i].GetComponent<Transform>();
                    enemigo = aliados_cerca[i];
                    break;
                }
            }
        }
        else
        {
            target = null;
            enemigo = null;
        }
    }

    public void Curar(){

        if(enemigo.vida == enemigo.vida_max){
            return;
        }
        else{
            
            if(enemigo.vida+curacion>enemigo.vida_max){
                Debug.Log("Tiene toda la vida");
                enemigo.vida=enemigo.vida_max;
            }
            else{
                enemigo.vida += curacion;
                Debug.Log("Curacion realizada");
            }
        }
    }
    public void StartTransition()
    {
        if(target!=null && enemigo.vida!=enemigo.vida_max){
            originalMaterial = baston.GetComponent<Renderer>().material;
            transitionProgress = 0.0f;
        }
    }
}
