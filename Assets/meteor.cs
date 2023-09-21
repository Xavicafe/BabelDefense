using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour
{
    public bool marca;
    public Transform squareCenter;
    public gen_meteors generador;
    public Vector3 posfin;
    public int velocidad=30;
    // Start is called before the first frame update
    void Start()
    {
        marca=false;
        posfin=generador.GenerateRandomPosition(squareCenter.position,300);
    }

    // Update is called once per frame
    void Update()
    {
        if(marca){
            transform.LookAt(posfin);
            transform.position = Vector3.MoveTowards(transform.position, posfin, velocidad * Time.deltaTime);
        }
    }
}
