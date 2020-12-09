using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SustoPerseguicao : SustoCena2
{
    public IAFumaca iaScript;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AtivarCustece();
        }
    }

    public override void AtivarCustece()
    {
        base.AtivarCustece();
       Invoke("AtivarNave", (float)timelineSusto.duration);
    }

    public void AtivarNave()
    {
        iaScript.StartPerseguicao();
    }
}
