using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaScript : MonoBehaviour
{
    public Animator anime;
    
    public bool locked;
    public AudioClip somPortaTrancada;
    public AudioClip somPortaAbrir;
    public AudioClip somPortaFechar;
    public AudioSource audioPorta;
    public string stringPortaAberta = "PortaAbre";

    
    public void OpenTheDoorOurClose()
    {
        if (!locked)
        {
            
                if (!anime.GetCurrentAnimatorStateInfo(0).IsName(stringPortaAberta))
                {
                    anime.SetTrigger("Open");
                audioPorta.PlayOneShot(somPortaAbrir);
                }
            else {

                audioPorta.PlayOneShot(somPortaFechar);
                 anime.SetTrigger("Close");
            }
        }
        else
        {
            audioPorta.PlayOneShot(somPortaTrancada);
            anime.SetTrigger("Locked");
        }
    }

    

}
