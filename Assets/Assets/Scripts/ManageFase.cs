using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageFase : MonoBehaviour
{
    public static ManageFase instancie;
    public bool voltando;
    private void Awake()
    {
        if (!instancie)
        {
            instancie = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
