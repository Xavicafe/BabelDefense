using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SigueCámara : MonoBehaviour
{
    public GameObject torre;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //transform.position=Camera.main.transform.position+new Vector3(0,5,0); 
       transform.LookAt(torre.transform.position);
    }
}
