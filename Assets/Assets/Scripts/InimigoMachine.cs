﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoMachine : MonoBehaviour
{
    public EnemyState state;
    public List<GameObject> patrolObject;
    private NavMeshAgent navEnemy;
    private Animator anime;
    private Player scriptplayer;
    public Transform PositionPlayer { set; get; }
    public Player PlayerScript
    {
        get
        {
            return scriptplayer;
        }
        set
        {
            if (!scriptplayer)
            {
                scriptplayer = value;
            }
        }
    }
    int i = 0;
    bool seek;
    // A distancia minima para seguir e a distancia maxima para seguir
    public float distanceMaxSeek=20;
    public float distanceMinSeek=10;
    // Distancia da Audição
    public float distanceSeekCorrendo=20;
    public float distanceSeekAndando=10;
    public float distanceSeekAgachado=5;

    // Start is called before the first frame update
    void Start()
    {
        navEnemy = GetComponent<NavMeshAgent>();
        anime = GetComponent<Animator>();
        StartCoroutine(RadarAuditivo());
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case EnemyState.PATROL:
                if (Vector3.Distance(transform.position, PositionPlayer.position) <= distanceMinSeek)
                {
                    MudarState(EnemyState.SEEK);
                }
                else
                {
                    MudarState(EnemyState.PATROL);
                    if (Vector3.Distance(transform.position, patrolObject[i].transform.position) < 2)
                    {
                        i++;
                        if (patrolObject.Count <= i)
                        {
                            i = 0;
                        }                      
                    }
                    navEnemy.SetDestination(patrolObject[i].transform.position);
                }

                break;
            case EnemyState.SEEK:
                if (Vector3.Distance(transform.position, PositionPlayer.position) >= distanceMaxSeek)
                {
                    MudarState(EnemyState.PATROL);
                }
                else
                {
                    MudarState(EnemyState.SEEK);
                }
                navEnemy.SetDestination(PositionPlayer.position);
                break;
        }

        anime.SetFloat("Velocity", Mathf.Abs(navEnemy.velocity.magnitude));
        anime.SetBool("Seeking", seek);
    }

    private void MudarState(EnemyState newstate)
    {

        switch (newstate)
        {
            case EnemyState.PATROL:
                navEnemy.speed = 1;
                seek = false;
                break;
            case EnemyState.SEEK:
                seek = true;
                break;
        }

        state = newstate;
    }

    //Sabe se o player esta correndo, andando ou agachado
    IEnumerator RadarAuditivo()
    {
        while(true)
        {
            switch (PlayerScript.state)
            {
                case EstadoPlayer.IDLE:
                    distanceMinSeek = 0;
                    break;
                case EstadoPlayer.CROUCHED:
                    distanceMinSeek = distanceSeekAgachado;
                    break;
                case EstadoPlayer.RUN:
                    distanceMinSeek = distanceSeekCorrendo;
                    break;
                case EstadoPlayer.WALK:
                    distanceMinSeek = distanceSeekAndando;
                    break;
            }
            
            yield return new WaitForSeconds(1f);


        }

       
    }
}

public enum EnemyState
{
    SEEK,
    PATROL
}
