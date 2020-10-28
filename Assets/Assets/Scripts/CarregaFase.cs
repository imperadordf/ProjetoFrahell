using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregaFase : MonoBehaviour
{
    public string NomeDaFase;
    public Animator anime;
    public bool isback;
    public void PlayAnimation()
    {
        anime.SetTrigger("Abrir");
        GameManager.instancie.carregandoFase = true;
        ManageFase.instancie.voltando = isback;
    }
    public void LoadCena()
    {
        SceneManager.LoadScene(NomeDaFase);
    }
    
}
