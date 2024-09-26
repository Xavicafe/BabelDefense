using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eliminar_unidad : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("esclavo") || other.CompareTag("soldados") || other.CompareTag("gigante")) {
            var soldado = other.gameObject.GetComponent<soldadito>();
            if (soldado != null) {
                soldado.Die();
            }
        }
        Debug.Log("Eliminado");
    }
}

