using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{   
    public Vector3 pivote;
    public float movementSpeed1 =1;
    public float movementSpeed2 = 20 ;
    public float limiteInferiorY = 4;
    public float limiteSuperiorY = 30;
    public Vector3 recta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        recta = transform.position-pivote;
        if( Input.GetKey( KeyCode.RightArrow ) || Input.GetKey( KeyCode.D )){
            transform.RotateAround(pivote, new Vector3(0,-1,0), movementSpeed1*Time.deltaTime);
            }
            
        if( Input.GetKey( KeyCode.LeftArrow ) || Input.GetKey( KeyCode.A )){
            transform.RotateAround(pivote, new Vector3(0,1,0), movementSpeed1*Time.deltaTime);
            }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey( KeyCode.W ))
        {
            transform.position += Vector3.up * movementSpeed2 * Time.deltaTime;
            //transform.Translate(new Vector3(0, 20 * Time.deltaTime, 0));
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey( KeyCode.S ))
        {
            transform.position += -Vector3.up * movementSpeed2 * Time.deltaTime;
            //ransform.Translate(new Vector3(0,-20 * Time.deltaTime, 0));
        }

        
        //C�digo para ponerle l�mites a la c�mara

        if(transform.position.y < limiteInferiorY)
        {
            transform.position = new Vector3(transform.position.x, limiteInferiorY, transform.position.z);
        }


        if (transform.position.y > limiteSuperiorY)
        {
            transform.position = new Vector3(transform.position.x, limiteSuperiorY, transform.position.z);
        }


        /*
         * C�DIGO PARA HACER ZOOM CON LAS TECLAS 'Q' Y 'E'
         */
        
        if (Input.GetKey(KeyCode.Q) && Vector3.Distance(pivote, transform.position) < 120)
        {
            transform.position += 0.005f * recta;
            /*
            if(Camera.main.fieldOfView < 80)
            {
                Camera.main.fieldOfView += (float)0.1;
            }
            */
        }

        if (Input.GetKey(KeyCode.E) && Vector3.Distance(pivote, transform.position) > 70)
        {
            transform.position -= 0.005f * recta;
            /*
            if (Camera.main.fieldOfView > 40)
            {
                Camera.main.fieldOfView -= (float)0.1;
            }
            */
        }
        

        /*
         * C�DIGO PARA HACER ZOOM CON LAS RUEDA DEL RAT�N'
         */

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && Vector3.Distance(pivote,transform.position)<120)
        {
            transform.position += 0.03f*recta;
            /*
         * C�DIGO PARA HACER ZOOM CON LAS RUEDA DEL RAT�N'
         
            if (Camera.main.fieldOfView < 80)
            {
                Camera.main.fieldOfView += (float) 2;
            }
             */
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && Vector3.Distance(pivote,transform.position)>70)
        {
            transform.position -= 0.03f*recta;
            /*
            if (Camera.main.fieldOfView > 20)
            {
                Camera.main.fieldOfView -= (float) 2;
            }
            */
        }
    }
    
}
