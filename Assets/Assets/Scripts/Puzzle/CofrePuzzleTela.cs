using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofrePuzzleTela : PuzzleRei
{
    public GameObject canvasCofre;
    GameObject canvas;
    bool concluir;
    public CofrePuzzleTela script;
    public override void PuzzleGo()
    {
        if (!canvas &&!concluir)
        {
            canvas = Instantiate(canvasCofre);
            canvas.GetComponent<CofrePuzzle>().PegarPuzzle(script) ;
            Time.timeScale = 0;
            GameManager.instancie.ativarInventario = true;
        }
        
    }


    public override void Concluiu()
    {
        Time.timeScale = 1;
        GameManager.instancie.ativarInventario = false;
        Destroy(canvas);
        concluir = true;
        this.gameObject.layer = 0;


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canvas)
        {
            Destroy(canvas);
            
            GameManager.instancie.ativarInventario = false;
        }
    }

}
