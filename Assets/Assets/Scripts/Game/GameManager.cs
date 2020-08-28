using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public  Player playerscript;

    public static GameManager instancie;
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
    // Start is called before the first frame update
    void Start()
    {
       
    }
   
    // Update is called once per frame
    void Update()
    {
       
    }
}
