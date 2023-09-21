using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botones_mejoras : MonoBehaviour
{
    public GameObject Setu_g;

    public GameObject Setu_a;

    public GameObject Setu_h;


    public void Menu_selected(int index){
        if(index==0){
            
            Setu_g.SetActive(true);
            Setu_a.SetActive(false);
            Setu_h.SetActive(false);
        }
        if(index==1){
            Setu_g.SetActive(false);
            Setu_a.SetActive(true);
            Setu_h.SetActive(false);
        }
        if(index==2){
            Setu_g.SetActive(false);
            Setu_a.SetActive(false);
            Setu_h.SetActive(true);
        }
    }
}
