using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaIa : MonoBehaviour
{
    public PortaScript scritPorta;

    public bool portaOpen;
    public void AbrirPortaIa()
    {
        scritPorta.AbrirPortaSom();
        portaOpen=true;
    }

    public void FecharPortaIa()
    {
        scritPorta.FecharPortaIa();
        portaOpen=false;
    }


   
}



