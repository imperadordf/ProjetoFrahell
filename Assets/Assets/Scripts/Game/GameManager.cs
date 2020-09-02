using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public  Player playerscript;
    private int vida = 3;
    public static GameManager instancie;
    public UiScript uiscript;
    private void Awake()
    {
        if (!instancie)
        {
            instancie = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void DanoSofre()
    {
       StartCoroutine( uiscript.InterfaceDano());
    }
}
