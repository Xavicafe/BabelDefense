using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mantener_posicion_altar : MonoBehaviour
{
    public GameObject altarObjetivo;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = altarObjetivo.transform.position + new Vector3(0,10,0);
        
    }
}
