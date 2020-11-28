using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaScriptTutorial : PortaScript
{
    public GameObject tutorial;

    public override void OpenTheDoorOurClose()
    {
        base.OpenTheDoorOurClose();
    }
    public override void AbrirPortaSom()
    {
        base.AbrirPortaSom();
        tutorial.SetActive(false);
        
    }

    public override void FecharPortaIa()
    {
        base.FecharPortaIa();
    }


}
