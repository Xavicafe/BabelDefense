using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boton_angel : MonoBehaviour
{
    
    public GameObject[] vaciado;
    public bool activado=true;
    public GameObject[] altares;
    // Start is called before the first frame update
    void Start()
    {
        

        
    }
    public void Genera_angel(){
        if(activado){
            altares = GameObject.FindGameObjectsWithTag("Altardisp");
            for(int i=0;i<altares.Length;i++){
                altares[i].SendMessage("Muestra_Altares_disp",this.gameObject);
            }
            for(int j=0;j<altares.Length;j++){
                altares=vaciado;
            }
            activado=false;
        }else{
            altares = GameObject.FindGameObjectsWithTag("Altar");
            for(int i=0;i<altares.Length;i++){
                Destroy(altares[i]);
            }
            activado=true;
        }
        
    }

    void Reactivado(){
        activado=true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
