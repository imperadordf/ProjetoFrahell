using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoInimigo : MonoBehaviour
{
    bool dano;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !dano)
        {
            GameManager.instancie.DanoSofre(1);
            dano = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") && dano)
        {
            dano = false;
        }
    }
}
