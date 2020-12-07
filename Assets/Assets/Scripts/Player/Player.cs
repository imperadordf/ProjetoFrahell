﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator_Player;
    
    //Camera em Pé e Camera Agachado
    public Camera cameraPe;
    
    public EstadoPlayer state;
    //Variavel do Usuario
    bool isSpriting,isCrouch,isIdle;
    float x, y;

    private Transform playerposition;
    // Start is called before the first frame update
    public MouseLook mousePlayer;

    public AnimationClip animeDeath;
    public Transform SpawnItem;
    [Header("Som")]
    [Header("Voz ")]
    public AudioClip [] somDano;
    public AudioSource audiosourceVocal;
    [Header("Geral")]
    public AudioClip[] somPassos;
    public AudioSource audiosourcePassos;
    public Transform PlayerPosition
    {
        get
        {
            return this.transform;
        }
    }

    private void Awake()
    {
        
    }

    void Start()
    {
        animator_Player = GetComponent<Animator>();
       Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instancie.ativarCutscene)
            return;
        //Entrada do Usuario 
         x = Input.GetAxis("Horizontal")*5;
         y = Input.GetAxis("Vertical")*5;
        
        isCrouch = Input.GetKey(KeyCode.LeftControl);
       
        //Maquina de estado
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
            case EstadoPlayer.DEATH:
                break;
        }

    }

    //Mudar o State
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
                audiosourcePassos.volume = 0.5f;
                break;
            case EstadoPlayer.CROUCHED:
                isSpriting = Input.GetKey(KeyCode.LeftShift);
                isIdle = false;
                audiosourcePassos.volume = 0.1f;
                break;
            case EstadoPlayer.RUN:
                isSpriting = Input.GetKey(KeyCode.LeftShift);
                isIdle = false;
                audiosourcePassos.volume = 1f;
                break;
            case EstadoPlayer.DEATH:
                break;
        }
        ParametrosAnimator();
        state = newState;
    }

    //Parametros de animação
    private void ParametrosAnimator()
    {
        if (state != EstadoPlayer.DEATH)
        {
            animator_Player.SetFloat("X", x);
            animator_Player.SetFloat("Y", y);
            animator_Player.SetBool("IsCrouch", isCrouch);
            animator_Player.SetBool("IsSpriting", isSpriting);
            animator_Player.SetBool("IsIdle", isIdle);
        }
        else
        {
            animator_Player.SetFloat("X", 0);
            animator_Player.SetFloat("Y", 0);
            animator_Player.SetBool("IsCrouch", false);
            animator_Player.SetBool("IsSpriting", false);
            animator_Player.SetBool("IsIdle", false);
        }
    }
    //Animação de rotação que tem referencia no Script "MouseLook"
    public void AnimationRotation(float mousex)
    {
        animator_Player.SetFloat("MouseX", mousex);
    }
    public EstadoPlayer ReturnStatePlayer()
    {
        return state;
    }

    public void Morrer()
    {
        mousePlayer.enabled = false;
        MudarState(EstadoPlayer.DEATH);
        animator_Player.SetTrigger("Dead");       
        
    }

    public void MorrerCamera()
    {
        mousePlayer.Morreu();
    }

    public void SomPassos()
    {
        audiosourcePassos.PlayOneShot(somPassos[Random.Range(0, 2)]);
    }
    public void SomDano()
    {
        audiosourceVocal.PlayOneShot(somDano[Random.Range(0,2)]);
    }
}

public enum EstadoPlayer
{
    WALK,
    RUN,
    CROUCHED,
    IDLE,
    DEATH

}
