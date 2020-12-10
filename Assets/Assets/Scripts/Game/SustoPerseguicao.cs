using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SustoPerseguicao : SustoCena2
{
    public IAFumaca iaScript;
    [Header("Tochas")]
    public GameObject tocha1;
    public GameObject tocha2;
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
        iaScript.gameObject.SetActive(true);
        iaScript.StartPerseguicao();
    }

    private void OnDestroy()
    {
        tocha1.SetActive(false);
        tocha2.SetActive(true);
    }
}
