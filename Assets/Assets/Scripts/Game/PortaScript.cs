using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaScript : MonoBehaviour
{
    public Animator anime;
    
    public bool locked;
    

    public  void OpenTheDoorOurClose()
    {
        if (!locked)
        {
            if (!anime.GetCurrentAnimatorStateInfo(0).IsName("Porta_Abre"))
            {
                anime.SetTrigger("Open");
            }
            else
            {
                anime.SetTrigger("Close");
            }
        }
    }

    

}
