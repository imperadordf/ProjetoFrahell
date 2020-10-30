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
                AbrirPortaSom();
            }
            else {

                FecharPortaIa();


            }
        }
        else
        {
            audioPorta.PlayOneShot(somPortaTrancada);
            anime.SetTrigger("Locked");
        }
    }

    public void AbrirPortaSom()
    {

          anime.SetTrigger("Open");
          audioPorta.PlayOneShot(somPortaAbrir);
 
    }
    
  public void FecharPortaIa()
    {
        anime.SetTrigger("Close");
        audioPorta.PlayOneShot(somPortaFechar);
    }
}
