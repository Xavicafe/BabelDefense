using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boton_angel : MonoBehaviour
{
    
    public GameObject[] vaciado;
    public bool activado=true;
    public GameObject[] altares;
    private PassaEscenas pas;
    public List<GameObject> botones_angeles;
    public GameObject Angelsimple;
    public List<Vector2> posicion_botones;
    // Start is called before the first frame update
    void Start()
    {
        pas = GameObject.FindGameObjectWithTag("pasaescena").GetComponent<PassaEscenas>();

        for(int i = 0; i<botones_angeles.Count;i++){
            posicion_botones.Add( botones_angeles[7-i].GetComponent<RectTransform>().anchoredPosition);
        }
        posicion_botones.Add(Angelsimple.GetComponent<RectTransform>().anchoredPosition);

        
        int j=0;
        for(int i=pas.angeles_bloqueados.Count-1;i>=0;i--){
            if(pas.angeles_bloqueados[i]){
                botones_angeles[i].SetActive(false);
                
            }else{
                botones_angeles[i].GetComponent<RectTransform>().anchoredPosition = posicion_botones[j];
                Debug.Log(posicion_botones[j]);
                j++;
                
            }

        }
        Angelsimple.GetComponent<RectTransform>().anchoredPosition = posicion_botones[j];
        Debug.Log(posicion_botones[j]);

        
        
        


        
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
