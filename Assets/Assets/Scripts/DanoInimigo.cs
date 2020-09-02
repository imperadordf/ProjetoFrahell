using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoInimigo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instancie.DanoSofre();
        }

    }
}
