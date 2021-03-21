using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public MenuConfig config;
    
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
        config.Inicialize();
    }
    public void StartGame()
    {
        ScriptLoading.instancie.AtivarLoad("Cena1");
    }

    public void Options()
    {
        config.gameObject.SetActive(true);
        
    }

    public void QuitarJogo()
    {
        Application.Quit();
    }

}
