using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BauPuzzle : PuzzleRei
{
    BauPuzzle bau;
    public bool locked;
    Animator anime;
    private void Start()
    {
        bau = GetComponent<BauPuzzle>();
        anime = GetComponent<Animator>();
    }
    public override void PuzzleGo()
    {
        if (!locked)
        {
            anime.SetTrigger("Abriu");
            this.gameObject.layer = 1;
        }
        else
        {
            anime.SetTrigger("Tentou");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GerenciadorItem.instacie.useritemArea = true;
            GerenciadorItem.instacie.variaveGeral.scriptBau = bau;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            GerenciadorItem.instacie.useritemArea = true;
            GerenciadorItem.instacie.variaveGeral.scriptBau = bau;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GerenciadorItem.instacie.useritemArea = false;
            GerenciadorItem.instacie.variaveGeral.scriptBau = null;
        }
    }
}
