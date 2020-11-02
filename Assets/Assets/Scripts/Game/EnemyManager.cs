using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    private Transform playerPosition;
    public  static EnemyManager instancie;
    public List<InimigoMachine> inimigosScripts;
    private Player playerscript;
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
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameManager.instancie.playerscript.PlayerPosition;
        playerscript = GameManager.instancie.playerscript;
        foreach (InimigoMachine enemy in inimigosScripts)
        {
            enemy.PositionPlayer = playerPosition;
            enemy.PlayerScript = playerscript;
            enemy.gameObject.SetActive(true);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

   
}
