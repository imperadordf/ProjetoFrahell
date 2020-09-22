using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaScript : MonoBehaviour
{
    Animator anime;
    
    public bool locked;
    private void Start()
    {
        anime = GetComponent<Animator>();
    }

    public  void OpenTheDoorOurClose()
    {
        if (!locked)
        {
            if (!anime.GetCurrentAnimatorStateInfo(0).IsName("PortaAbre"))
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
