using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuMejoras : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip botonvolver;

    void Start(){
        audiosource.PlayOneShot(botonvolver);
    }
    public void Cambiar_A_Mejoras(){

        audiosource.PlayOneShot(botonvolver);
        SceneManager.LoadScene("Mejoras");
        

    }

    
    
   


    
}
