using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EXP : MonoBehaviour
{
    public TMP_Text exp_mejoras;

    private  PassaEscenas pas;
    // Start is called before the first frame update
    void Start(){
        pas = GameObject.FindGameObjectWithTag("pasaescena").GetComponent<PassaEscenas>();
        
    }

    void Update(){
        exp_mejoras.text=pas.experiencia.ToString();
    }
}
