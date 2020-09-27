using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaScript : MonoBehaviour
{
    public Animator anime;
    
    public bool locked;

    public string stringPortaAberta = "PortaAbre";
    public void OpenTheDoorOurClose()
    {
        if (!locked)
        {
            
                if (!anime.GetCurrentAnimatorStateInfo(0).IsName(stringPortaAberta))
                {
                    anime.SetTrigger("Open");
                }
            else { 

 
                 anime.SetTrigger("Close");
            }
        }
        else
        {
            anime.SetTrigger("Locked");
        }
    }

    

}
