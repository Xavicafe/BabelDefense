﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirObjeto : MonoBehaviour
{
    
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Transform target;

    void Update()
    {

        gameObject.transform.position =new Vector3(target.position.x + offset.x, target.position.y + offset.y,target.position.z + offset.z);

    }
}
