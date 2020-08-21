﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator_Player;
    Vector3 velocity;
    //Camera em Pé e Camera Agachado
    public Camera cameraPe;
    public Camera cameraAgacha;
    public EstadoPlayer state;
    //Variavel do Usuario
    bool isSpriting,isCrouch,isIdle;
    float x, y;
    // Start is called before the first frame update
    void Start()
    {
        animator_Player = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        //Entrada do Usuario 
         x = Input.GetAxis("Horizontal");
         y = Input.GetAxis("Vertical");
        
        isCrouch = Input.GetKey(KeyCode.LeftControl);
        switch (state)
        {
            case EstadoPlayer.IDLE:
                if (Mathf.Abs(y)>0 || Mathf.Abs(x) > 0)
                {
                    MudarState(EstadoPlayer.WALK);
                }         
                else if (isCrouch)
                {
                    MudarState(EstadoPlayer.CROUCHED);
                }
                else
                {
                    MudarState(EstadoPlayer.IDLE);
                }

                break;
            case EstadoPlayer.WALK:
                if (Mathf.Abs(y) == 0 && Mathf.Abs(x) == 0)
                {
                    MudarState(EstadoPlayer.IDLE);
                }
                else if (isSpriting)
                {
                    MudarState(EstadoPlayer.RUN);
                }
                else if (isCrouch)
                {
                    MudarState(EstadoPlayer.CROUCHED);
                }
                else
                {
                    MudarState(EstadoPlayer.WALK);
                }

                break;
            case EstadoPlayer.CROUCHED:
                if (isCrouch)
                {
                    MudarState(EstadoPlayer.CROUCHED);
                }
                else if (Mathf.Abs(y) > 0 || Mathf.Abs(x) > 0)
                {
                    MudarState(EstadoPlayer.WALK);
                }
                else if (isSpriting)
                {
                    MudarState(EstadoPlayer.RUN);
                }
                else
                {
                    MudarState(EstadoPlayer.IDLE);
                }
                break;
            case EstadoPlayer.RUN:
                if (isSpriting)
                {
                    MudarState(EstadoPlayer.RUN);
                }
                else if (Mathf.Abs(y) > 0 || Mathf.Abs(x) > 0)
                {
                    MudarState(EstadoPlayer.WALK);
                }
                else if (isCrouch)
                {                 
                    MudarState(EstadoPlayer.CROUCHED);
                }
                else
                {
                    MudarState(EstadoPlayer.IDLE);
                }
                break;
        }

    }
    public void MudarState(EstadoPlayer newState)
    {
        switch(newState)
        {
            case EstadoPlayer.IDLE:
                isIdle = true;
                break;
            case EstadoPlayer.WALK:     
                isSpriting = Input.GetKey(KeyCode.LeftShift);
                isIdle = false;
                break;
            case EstadoPlayer.CROUCHED:
                isSpriting = Input.GetKey(KeyCode.LeftShift);
                isIdle = false;
                break;
            case EstadoPlayer.RUN:
                isSpriting = Input.GetKey(KeyCode.LeftShift);
                isIdle = false;
                break;
        }
        ParametrosAnimator();
        state = newState;
    }

    private void ParametrosAnimator()
    {
        animator_Player.SetFloat("X", x);
        animator_Player.SetFloat("Y", y);
        animator_Player.SetBool("IsCrouch", isCrouch);
        animator_Player.SetBool("IsSpriting", isSpriting);
        animator_Player.SetBool("IsIdle", isIdle);
    }

    public void AnimationRotation(float mousex)
    {
        animator_Player.SetFloat("MouseX", mousex);
    }
    public EstadoPlayer ReturnStatePlayer()
    {
        return state;
    }
}

public enum EstadoPlayer
{
    WALK,
    RUN,
    CROUCHED,
    IDLE

}
