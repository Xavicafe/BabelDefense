using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominioGiroLanza : MonoBehaviour
{
    public float velocidadRotacion = 5f;
    public angel angel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        // Rota el objeto gradualmente sobre el eje Y (puedes usar otro eje si deseas)
        transform.Rotate(Vector3.right, velocidadRotacion * Time.deltaTime);
        if(angel.target==null){GetComponent<MeshRenderer>().enabled = true;}
        else{GetComponent<MeshRenderer>().enabled = false;}
    }
}
