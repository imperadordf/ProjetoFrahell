using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    bool ativado=false;
    public GameObject menuPause;
    ManageFase fasescript;
   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ativado = !ativado;
            GameManager.instancie.ativarMenu = ativado;
            menuPause.SetActive(ativado);
        }
    }
    public void VoltaMenu()
    {
       
        Destroy(GerenciadorItem.instacie.gameObject);
        Destroy(ManageFase.instancie.gameObject);
        ScriptLoading.instancie.AtivarLoad("MenuPrincipal");

    }

    public void QuitarJogo()
    {
        Application.Quit();
    }

    public void ReturnGame()
    {
        ativado = false;
        menuPause.SetActive(ativado);
        GameManager.instancie.ativarMenu = ativado;
    }
}
