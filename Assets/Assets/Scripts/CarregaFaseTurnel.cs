using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class CarregaFaseTurnel : MonoBehaviour
{
    public string NomeFase;
    public bool isback;
   public PlayableDirector timeline;
    
    public void CarregaFase()
    {
        timeline.Play();
        GameManager.instancie.carregandoFase = true;
        Invoke("CarregarCena",(float)timeline.duration - 1);
    }


    public void CarregarCena()
    {
        ManageFase.instancie.voltando = isback;
        ScriptLoading.instancie.AtivarLoad(NomeFase);
    }
}
