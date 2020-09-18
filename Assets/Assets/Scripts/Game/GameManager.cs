using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public  Player playerscript;
    private int vida = 3;
    public static GameManager instancie;
    public UiScript uiscript;
    public GameObject inventarioCanvas;
   public bool ativarInventario;
    public bool portaOn;
    private void Awake()
    {
        if (!instancie)
        {
            instancie = this;
            
        }
        
    }
    private void Update()
    {
        

        if (ativarInventario)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
             Cursor.visible = false;
            Time.timeScale = 1;
        }
    }
    public void DanoSofre()
    {
       StartCoroutine( uiscript.InterfaceDano());
    }


}
