using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Susto : MonoBehaviour
{
    public AudioSource audiosource;
    public int id;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audiosource.Play();
            GerenciadorFase.instancie.sustoListId.Add(id);
            Destroy(this.gameObject);
        }
    }
}
