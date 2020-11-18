using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPuzzleGerencer : PuzzleRei
{

    public GameObject objetoCameraPuzzle;
    public GameObject canvasCameraPuzzle;
    bool ativouPuzzle;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ativouPuzzle)
        {
            GameManager.instancie.ativarPuzzle = false;
            objetoCameraPuzzle.SetActive(false);
            canvasCameraPuzzle.SetActive(false);
        }
    }

    public void FecharPuzzle()
    {
        GameManager.instancie.ativarPuzzle = false;
        objetoCameraPuzzle.SetActive(false);
        canvasCameraPuzzle.SetActive(false);
    }
    public override void PuzzleGo()
    {
        objetoCameraPuzzle.SetActive(true);
        canvasCameraPuzzle.SetActive(true);
        ativouPuzzle = true;
        GameManager.instancie.ativarPuzzle = true;
    }

    public override void Concluiu()
    {
        
        GameManager.instancie.ativarPuzzle = false;
        objetoCameraPuzzle.SetActive(false);
        canvasCameraPuzzle.SetActive(false);
        ativouPuzzle = false;
        this.enabled = false;
    }
}
