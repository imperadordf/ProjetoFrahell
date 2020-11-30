﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class CarregaFase : MonoBehaviour
{
    public string NomeDaFase;
    public Animator anime;
    public bool isback;
    public PlayableDirector timeline;
    public Transform position;

    public void PlayAnimation()
    {

        GameManager.instancie.playerscript.transform.SetPositionAndRotation(position.position,position.rotation);
        
        StartCoroutine(CarregarCena());
         GameManager.instancie.carregandoFase = true;
        GameManager.instancie.ativarPuzzle = true;
        timeline.Play();
        ManageFase.instancie.voltando = isback;
    }

    IEnumerator CarregarCena()
    {
        yield return new WaitForSecondsRealtime((float)timeline.duration - 1.0f);
        SceneManager.LoadScene(NomeDaFase);
        print("Carrega");
    }
   
    
}
