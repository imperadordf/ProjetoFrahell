using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofrePuzzleTela : PuzzleRei
{
    public GameObject canvas;
    
    bool concluir;
    public CofrePuzzleTela script;
    public CofrePuzzle cofre;
    public override void PuzzleGo()
    {
        if (!concluir)
        {
            canvas.SetActive(true);
            canvas.GetComponent<CofrePuzzle>().PegarPuzzle(script) ;
            Time.timeScale = 0;
            GameManager.instancie.ativarInventario = true;
        }
        
    }

   

    public override void Concluiu()
    {
        Time.timeScale = 1;
        GameManager.instancie.ativarInventario = false;
        canvas.SetActive(false);
        concluir = true;
        this.gameObject.layer = 0;


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canvas.activeSelf || Input.GetKeyDown(KeyCode.F) && canvas.activeSelf)
        {
            canvas.SetActive(false);
            
            GameManager.instancie.ativarInventario = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GerenciadorItem.instacie.useritemArea = true;
            GerenciadorItem.instacie.variaveGeral.cofre = cofre;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            GerenciadorItem.instacie.useritemArea = true;
            GerenciadorItem.instacie.variaveGeral.cofre = cofre;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GerenciadorItem.instacie.useritemArea = false;
            GerenciadorItem.instacie.variaveGeral.cofre = null;
        }
    }
}
