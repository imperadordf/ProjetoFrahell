using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{

    
    private void Start()
    {
        if (GerenciadorItem.instacie)
        {
            Destroy(GerenciadorItem.instacie.gameObject);
        }
        if (GerenciadorFase.instancie)
        {
            Destroy(GerenciadorFase.instancie.gameObject);
        }

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitarJogo()
    {
        Application.Quit();
    }

}
