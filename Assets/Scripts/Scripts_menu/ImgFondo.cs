using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImgFondo : MonoBehaviour
{

    const float ImageWidth = 2000.0f,
                TimeOut = 5.0f; //Segundos antes de saltar al menu principal

    public enum SplashStates
    {
        Moving,   
        Finish
    }  

    public SplashStates State;
    public Vector3 Speed;  //Velocidad a la que se mueve la imagen en pantalla

    float startTime;

    Image image;
    Color32 c;

    // Use this for initialization
    void Start()
    {
        State = SplashStates.Moving;
        startTime = Time.time;
        image = GetComponent<Image>();
        c = image.color;
        Speed.x = 10.0f;
        Speed.y = 10.0f;
        Speed.z = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        switch (State)
        {
            case SplashStates.Moving:   //The splash image is moving on the screen
                transform.Translate(Speed * Time.deltaTime);
                if (c.r < 255)
                    c.r += 1;
                else if (c.g < 255)
                    c.g += 3;
                else if (c.b < 255)
                    c.b += 2;
                image.color = c;
                break;
            case SplashStates.Finish:
                SceneManager.LoadScene("inicio");
                break;
            default:
                break;
        }

        if (Time.time - startTime > TimeOut)    //También se puede acabar la presentación por tiempo
            State = SplashStates.Finish;

        if (Input.GetKey(KeyCode.Escape) || //Si se pulsa la tecla escape
            Input.GetKey(KeyCode.Return) || //Si se pulsa la tecla enter
            Input.GetKey(KeyCode.Space))    //Si se pulsa la tecla espacio

            State = SplashStates.Finish;
    }
}
