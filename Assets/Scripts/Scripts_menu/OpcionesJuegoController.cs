using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionesJuegoController : MonoBehaviour
{
    private bool opciones_activas;
    public GameObject canvas_opciones;
    
    // Start is called before the first frame update
    void Start()
    {
        opciones_activas = false;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && opciones_activas)
        {
            ocultar_opciones();
        }
    }

    public void mostrar_opciones()
    {
        canvas_opciones.SetActive(true);
        opciones_activas = true;
    }

    public void ocultar_opciones()
    {
        canvas_opciones.SetActive(false);
        opciones_activas = false;
    }

    public bool EstanOpcionesActivas()
    {
        return opciones_activas;
    }
}
