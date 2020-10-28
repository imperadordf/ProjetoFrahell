using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofrePuzzleTela : PuzzleRei
{
    public GameObject canvasCofre;
    GameObject canvas;
    public override void PuzzleGo()
    {
        if (!canvas)
        {
            canvas = Instantiate(canvasCofre);
            Time.timeScale = 0;
            GameManager.instancie.ativarInventario = true;
        }
        
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
