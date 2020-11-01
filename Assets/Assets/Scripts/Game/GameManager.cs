using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

   
    private int vida = 3;
    public static GameManager instancie;
    public UiScript uiscript;
    public Player playerscript;
    public GameObject playerImagem;
    public bool ativarInventario,ativarMenu;
    public bool portaOn;
    bool morreu;
    public bool carregandoFase;
    
    private void Awake()
    {
        if (!instancie)
        {
            instancie = this;
            
        }
        
    }

    private void Start()
    {
        
    }
    private void Update()
    {
        

        if (ativarInventario || ativarMenu)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            playerImagem.SetActive(false);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
             Cursor.visible = false;
            Time.timeScale = 1;
            playerImagem.SetActive(true);
        }
    }
    public void DanoSofre()
    {
      
        if (vida <= 0 && !morreu)
        {
            playerscript.Morrer();
            morreu = true;
        }
        else if(!morreu)
        {
            StartCoroutine(uiscript.InterfaceDano());
            vida--;
        }
    }


}
