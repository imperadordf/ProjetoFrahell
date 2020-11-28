using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaIa : MonoBehaviour
{
    public PortaScript scritPorta;

    public void AbrirPortaIa()
    {
        scritPorta.AbrirPortaSom();
    }

    public void FecharPortaIa()
    {
        scritPorta.FecharPortaIa();
    }


   
}



