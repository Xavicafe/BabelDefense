using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TExtoOleada : MonoBehaviour
{
    
    public Text OleadaTExto;
    void Update()
    {
        OleadaTExto.text = "Oleada:\n"+PlayerStats.Ronda.ToString()+"/20";
    }

}
