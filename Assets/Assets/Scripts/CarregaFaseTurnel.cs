using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregaFaseTurnel : MonoBehaviour
{
    public string NomeFase;

    public void CarregaFase()
    {
        SceneManager.LoadScene(NomeFase);
    }
}
