using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armario : MonoBehaviour
{
    public Animator anime;
    bool aberto;
    
    public void AbrirPorta()
    {
        aberto = !aberto;
        anime.SetBool("Aperto",aberto);
    }
}
