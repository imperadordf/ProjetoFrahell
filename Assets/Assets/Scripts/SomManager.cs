using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomManager : MonoBehaviour
{
    public static SomManager instancie;
    public AudioSource audioManager;
    private void Awake()
    {
        if (!instancie)
        {
            instancie = this;

        }
        else
        {
            Destroy(this);
        }
    }


    public void TocarSom(AudioClip som)
    {
        audioManager.PlayOneShot(som);
    }
}
