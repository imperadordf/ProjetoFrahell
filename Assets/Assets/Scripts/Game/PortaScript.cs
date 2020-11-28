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
    public string stringPortaFechado = "PortaFecha";

    public virtual  void OpenTheDoorOurClose()
    {
        if (!locked)
        {
            if (!anime.GetCurrentAnimatorStateInfo(0).IsName(stringPortaAberta))
            {
                AbrirPortaSom();
            }
            else if (!anime.GetCurrentAnimatorStateInfo(0).IsName(stringPortaFechado)) 
            { 
                FecharPortaIa();
            }
        }
        else
        {
            audioPorta.PlayOneShot(somPortaTrancada);
            anime.SetTrigger("Locked");
        }
    }

    public virtual void AbrirPortaSom()
    {
          anime.SetTrigger("Open");
          audioPorta.PlayOneShot(somPortaAbrir);
    }
    
  public   virtual void FecharPortaIa()
    {
        anime.SetTrigger("Close");
        audioPorta.PlayOneShot(somPortaFechar);
    }
}
