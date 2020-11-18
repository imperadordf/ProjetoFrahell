using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

   
    private int vida = 3;
    public static GameManager instancie;
    public UiScript uiscript;
    public Player playerscript;
    public GameObject playerImagem;
    public bool ativarInventario,ativarMenu,ativarPuzzle;
    public bool portaOn;
    bool morreu;
    public bool carregandoFase;
    public string nomedacena;
    private void Awake()
    {
        if (!instancie)
        {
            instancie = this;
        }
        else
        {
            Destroy(this);
        }
        
    }

    private void Start()
    {
        nomedacena = SceneManager.GetActiveScene().name;
        vida = 3;
    }
    private void Update()
    {
        

        if (ativarInventario || ativarMenu || ativarPuzzle )
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
            playerscript.animator_Player.SetTrigger("Dead");
            playerscript.Morrer();
            Invoke("MorreuCarregaFase", 4f);
            morreu = true;
        }
        else if(!morreu)
        {
            StartCoroutine(uiscript.InterfaceDano());
            vida--;
        }
    }

    public void MorreuCarregaFase()
    {
        SceneManager.LoadScene(nomedacena);
        
    }
}
