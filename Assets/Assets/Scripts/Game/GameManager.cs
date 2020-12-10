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
    public bool ativarInventario,ativarMenu,ativarPuzzle,ativarCutscene;
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
            if (ativarInventario || ativarMenu || ativarPuzzle)
            {
                DefinirTimeScale(0);
                AtivarDesativaMouse(true);
            }
            else
            {
                DefinirTimeScale(1);
                AtivarDesativaMouse(false);
            }
    }

    public void DefinirTimeScale(float time)
    {
        Time.timeScale = time;
    }

    public void AtivarDesativaMouse(bool verdade)
    {
        if (verdade)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        playerImagem.SetActive(!verdade);

    }
    public void DanoSofre(int dano)
    {
        vida -= dano;
        if (vida <= 0 && !morreu)
        {
            
            playerscript.Morrer();
            Invoke("MorreuCarregaFase", 4f);
            morreu = true;
        }
        else if(!morreu)
        {
            StartCoroutine(uiscript.InterfaceDano(vida));
            playerscript.SomDano();
        }
    }

    public void MorreuCarregaFase()
    {
        SceneManager.LoadScene(nomedacena);
        
    }
}
