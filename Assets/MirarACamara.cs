using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirarACamara : MonoBehaviour
{
    public GameObject camara;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(camara.transform);
    }
}
