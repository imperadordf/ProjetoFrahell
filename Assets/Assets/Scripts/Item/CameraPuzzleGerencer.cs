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
            AtivarDesativaObject(false);
        }
    }

    public void FecharPuzzle()
    {
        AtivarDesativaObject(false);
    }
    public override void PuzzleGo()
    {
        AtivarDesativaObject(true);
        ativouPuzzle = true;
    }
    private void AtivarDesativaObject(bool ativar)
    {
        GameManager.instancie.ativarPuzzle = ativar;
        objetoCameraPuzzle.SetActive(ativar);
        canvasCameraPuzzle.SetActive(ativar);
    }
    public override void Concluiu()
    {
        AtivarDesativaObject(false);
        ativouPuzzle = false;
        this.enabled = false;
    }
}
