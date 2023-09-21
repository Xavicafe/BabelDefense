using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoBotones : MonoBehaviour
{
    public AudioSource mySounds;
    public AudioClip hoverSound;
    public AudioClip clickSound;
    public AudioClip hoverSoundAngel;

    

    public void HoverSound()
    {
        mySounds.PlayOneShot(hoverSound);
    }

    public void ClickSound()
    {
        mySounds.PlayOneShot(clickSound);
    }

    public void HoverSoundAngel()
    {
        mySounds.PlayOneShot(hoverSoundAngel);
    }
}
