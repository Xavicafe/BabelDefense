using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gen_meteors : MonoBehaviour
{
    public Transform squareCenter;
    [HideInInspector]
    public float squareSize;
    public List<GameObject> meteors;

    void Start(){
        squareSize=300;
    }

    public void Start_meteors(){
        StartCoroutine(Delay());
    }

    public Vector3 GenerateRandomPosition(Vector3 center, float size)
    {
        // Calcula la mitad del tamaño del cuadrado
        float halfSize = size / 2f;

        // Genera coordenadas aleatorias dentro del rango del cuadrado
        float randomX = Random.Range(center.x - halfSize, center.x + halfSize);
        float randomZ = Random.Range(center.z - halfSize, center.z + halfSize);

        // Crea un vector con las coordenadas X e Y aleatorias generadas
        Vector3 randomPosition = new Vector3(randomX, center.y,randomZ);
        
        return randomPosition;
    }

    IEnumerator Delay()
    {
        for(int i=0;i<meteors.Count;i++){
            Vector3 randomPosition = GenerateRandomPosition(squareCenter.position, squareSize);
            meteors[i].GetComponent<Transform>().position=randomPosition;
            meteors[i].GetComponent<meteor>().marca=true;
            yield return new WaitForSeconds(0.5f);
        }
        
    }
}
