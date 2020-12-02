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
       
    }


    public void TocarSom(AudioClip som)
    {
        audioManager.PlayOneShot(som);
        audioManager.volume = Random.Range(0.30f, 0.65f);
    }
}
