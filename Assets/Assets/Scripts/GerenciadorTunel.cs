using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorTunel : MonoBehaviour
{
    public Transform player;
    public Transform pos1;
    public Transform pos2;

    public Animator playerAnimation;

    private void Awake()
    {
        if (!ManageFase.instancie.voltando)
        {
            player.position = pos1.position;
            player.rotation = pos1.rotation;
            player.gameObject.SetActive(true);
        }
        else
        {
            player.position = pos2.position;
            player.rotation = pos2.rotation;
            player.gameObject.SetActive(true);

        }
    }

    private void Start()
    {
        
    }
}
