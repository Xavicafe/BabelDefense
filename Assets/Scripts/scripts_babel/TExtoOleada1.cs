using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TExtoOleada1 : MonoBehaviour
{
    public Text TextoOl;
    void Update()
    {
        TextoOl.text = PlayerStats.Ronda.ToString()+"/15";
    }
}
