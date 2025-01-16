using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionesJuegoController : MonoBehaviour
{
    private bool opciones_activas;
    public GameObject canvas_opciones;
    private PassaEscenas pas;
    
    // Start is called before the first frame update
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

        opciones_activas = false;       
        GameObject.Find("Musica_fondo").GetComponent<AudioSource>().volume = pas.volume;
        GameObject.Find("AudioSFX").GetComponent<AudioSource>().volume = pas.efects;
        GameObject audiotambores = GameObject.Find("AudioTambores");
        if(audiotambores!=null){
            audiotambores.GetComponent<AudioSource>().volume = pas.volume;
        }  

        Debug.Log("habilidades: PassaEscenas inicializado correctamente");
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
