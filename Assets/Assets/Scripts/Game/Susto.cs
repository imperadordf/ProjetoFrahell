using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Susto : MonoBehaviour
{
    public AudioSource audiosource;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audiosource.Play();
            Destroy(this.gameObject);
        }
    }
}
