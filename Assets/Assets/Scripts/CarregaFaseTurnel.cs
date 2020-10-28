using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregaFaseTurnel : MonoBehaviour
{
    public string NomeFase;
    public bool isback;
    public void CarregaFase()
    {
        ManageFase.instancie.voltando = isback;
        SceneManager.LoadScene(NomeFase);
    }
}
