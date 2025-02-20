using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EXP_GANADAPARTIDA : MonoBehaviour
{
    public TMP_Text texto;
    [HideInInspector]
    public generador generador;

    private PassaEscenas pas;

    void Start()
    {
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
        generador = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<generador>();
        texto.text = "Experiencia Ganada: "+ generador.GetExperienciaTotalGanada();
        pas.AddEXP(generador.GetExperienciaTotalGanada());
        
    }
}
