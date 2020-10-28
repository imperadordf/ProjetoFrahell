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

            player.SetPositionAndRotation(pos1.position, pos1.rotation);          
           // playerAnimation.updateMode = AnimatorUpdateMode.AnimatePhysics;
        }
        else
        {
            player.SetPositionAndRotation(pos2.position, pos2.rotation);
           // playerAnimation.updateMode = AnimatorUpdateMode.AnimatePhysics;
        }
    }
}
