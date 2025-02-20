using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FastForward : MonoBehaviour
{
    public Text textoFF;
    public camera camara;
    private float velocidad_camara1;
    private float velocidad_camara2;
    void Start(){
        velocidad_camara1= camara.movementSpeed1;
        velocidad_camara2= camara.movementSpeed2;
    }

    public void FastAndNormal()
    {
        if(Time.timeScale == 1f)
        {
            textoFF.text = "2X";
            Time.timeScale = 2f;
            camara.movementSpeed1 = velocidad_camara1/2;
            camara.movementSpeed2 = velocidad_camara2/2;
        }
        else if (Time.timeScale == 2f)
        {
            textoFF.text = "3X";
            Time.timeScale = 3f;
            camara.movementSpeed1 = velocidad_camara1/4;
            camara.movementSpeed2 = velocidad_camara2/4;
        }
        else if (Time.timeScale == 3f)
        {
            textoFF.text = "5X";
            Time.timeScale = 5f;
            camara.movementSpeed1 = velocidad_camara1;
            camara.movementSpeed2 = velocidad_camara2;
        }
        else if (Time.timeScale == 5f)
        {
            textoFF.text = "1X";
            Time.timeScale = 1f;
            camara.movementSpeed1 = velocidad_camara1;
            camara.movementSpeed2 = velocidad_camara2;
        }


    }
}
