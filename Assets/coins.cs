using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coins : MonoBehaviour
{
    public RectTransform objetoDesplazable;
    public Vector3 posicionIni;
    public bool marca;
    // Start is called before the first frame update
    void Start()
    {
        objetoDesplazable=GetComponent<RectTransform>();
        posicionIni = objetoDesplazable.position;
        marca=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(marca){
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            // Obtén el Sprite del componente SpriteRenderer
            Sprite sprite = spriteRenderer.sprite;

            // Verifica si se ha obtenido un Sprite válido
            if (sprite != null)
            {
                Image imagen = GetComponent<Image>();
                imagen.sprite = sprite;
            }
            // Obtén la posición actual del objeto
            Vector3 posicionActual = objetoDesplazable.position;

            // Calcula la nueva posición desplazada hacia abajo
            Vector3 nuevaPosicion = new Vector3(posicionActual.x, posicionActual.y - 2f, posicionActual.z);

            // Asigna la nueva posición al objeto
            objetoDesplazable.position = nuevaPosicion;

            if(objetoDesplazable.position.y<=-400){
                objetoDesplazable.position=posicionIni;
                marca=false;
            }
        }
    
    }
}
