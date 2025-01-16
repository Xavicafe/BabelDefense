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

        Debug.Log("habilidades: PassaEscenas inicializado correctamente");
    }

    void Update(){
        exp_mejoras.text="EXP: "+pas.experiencia.ToString();
    }
}
