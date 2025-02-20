using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    public angel angel;
    public Transform targeto;

    public float speed = 70f;

    public float damage = 50;
    
    public float damageIni;

    public float explosionRadius = 0f;
    public GameObject impactEffect;

    public bool IsReady=true;
    private Vector3 PosIni;
    public string Name; 

    public float quemado;
    public float sangrado;

    private bool seeking=false;

    // Start is called before the first frame update
    void Start()
    {
        damageIni=damage;
        PosIni=transform.position;
        
    }
    void OnEnable() {
        seeking=false;
    // Este código se ejecuta cada vez que el objeto se activa
    }
    // Update is called once per frame
    void Update()
    {   
        if(Name=="espada"){
            if(targeto!=null){
                IsReady=false;
                Vector3 dir = targeto.position - transform.position;
                float distanceThisFrame = speed * Time.deltaTime;

                //Si la distancia al target es menor que el frame, es que puede darle al objeto.
                if (dir.magnitude <= distanceThisFrame)
                {
                    HitTarget();
                    return;
                }

                transform.Translate(dir.normalized * distanceThisFrame, Space.World);
                transform.LookAt(targeto);
            }
            else{
                IsReady=true;
                if(seeking){
                    angel.espada(PosIni,this.gameObject);
                }
            }
        }
        else{
            if(targeto==null){
                Destroy(gameObject); return;
            }
            Vector3 dir = targeto.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;

            //Si la distancia al target es menor que el frame, es que puede darle al objeto.
            if (dir.magnitude <= distanceThisFrame)
            {
                HitTarget();
                return;
            }

            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
            transform.LookAt(targeto);
        }
        

    }

    void HitTarget()
    {        
        seeking=false;
        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(targeto);
        }
        if(Name=="espada"){
            angel.espada(PosIni,this.gameObject);
        }
        else{
        Destroy(gameObject);
        }
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "soldados" || collider.tag == "esclavo" || collider.tag == "gigante")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
        soldadito enemigo = enemy.GetComponent<soldadito>();
        if (enemigo != null)
        {   
            enemigo.Impacto(damage);
            if(quemado>0){
                enemigo.quemado_sangrado("quemado", quemado);
            }
            if(sangrado>0){
                enemigo.quemado_sangrado("sangrado", sangrado);
            }
        }
    }
    public void Seek(Transform _target)
    {
        seeking = true;
        targeto = _target;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
