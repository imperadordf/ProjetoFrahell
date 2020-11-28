using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ocultista : InimigoMachine
{
   public  bool abriuPorta;
    bool podeabrirPorta=true;
    public GameObject danoObject;
    public float tempoPortaMax;
    float tempoporta;
  public EnemyState ultimoState;
    void Start()
    {
        PegarComponentes();
    }

    public override void PegarComponentes()
    {
        base.PegarComponentes();
        tempoporta = tempoPortaMax;
    }

    void FixedUpdate()
    {
        MaquinaDeEstado();
        anime.SetFloat("Velocity", Mathf.Abs(navEnemy.velocity.magnitude));
        anime.SetBool("Seeking", seek);
        
    }
    public override void MaquinaDeEstado()
    {

        switch (state)
        {
            //Maquina de estado Patrol
            case EnemyState.PATROL:
                if (Vector3.Distance(transform.position, PositionPlayer.position) <= distanceMinSeek)
                {
                    MudarState(EnemyState.SEEK);
                }
                else
                {

                    if (Vector3.Distance(transform.position, patrolObject[i].transform.position) < 0.5f)
                    {
                       
                        MudarState(EnemyState.ALERTED);
                        
                    }
                    navEnemy.SetDestination(patrolObject[i].transform.position);

                }
                break;
            //Maquina de estado Seek
            case EnemyState.SEEK:
                if (Vector3.Distance(transform.position, PositionPlayer.position) >= distanceMaxSeek)
                {
                    MudarState(EnemyState.ALERTED);
                }
                else if((Vector3.Distance(transform.position, PositionPlayer.position) > 2))
                {
                    MudarState(EnemyState.SEEK);
                    navEnemy.SetDestination(PositionPlayer.position);
                }
                else
                {
                    MudarState(EnemyState.ATTACK);
                }
                

                break;
            //Maquina de estado Alerta
            case EnemyState.ALERTED:
                if (Vector3.Distance(transform.position, PositionPlayer.position) <= distanceMinSeek)
                {
                    MudarState(EnemyState.SEEK);
                }
                else if (timealerta <= 0)
                {
                    MudarState(EnemyState.PATROL);
                }
                else
                {
                    timealerta -= Time.deltaTime;
                    MudarState(EnemyState.ALERTED);
                }

                
                break;
            case EnemyState.ATTACK:
                if (Vector3.Distance(transform.position, PositionPlayer.position) <= 1.0)
                {
                    MudarState(EnemyState.ATTACK);
                }
                else
                {
                    MudarState(EnemyState.SEEK);
                }
                break;
            case EnemyState.ABRIUPORTA:
                if (tempoporta <= 0)
                {
                    MudarState(ultimoState);
                }
                else
                {
                    tempoporta -= Time.deltaTime;
                    MudarState(EnemyState.ABRIUPORTA);
                }
                break;
        }

        danoObject.SetActive(anime.GetBool("Attack")); 
    }

    public override void MudarState(EnemyState newstate)
    {
        switch (newstate)
        {
            case EnemyState.PATROL:
                navEnemy.speed =1.0f;
                seek = false;
                timealerta = TimeAlerta/2;
                navEnemy.isStopped = false;
                i++;
                anime.applyRootMotion = false;
                podeabrirPorta = true;
                if (patrolObject.Count <= i)
                {
                    i = 0;
                }
                ultimoState = newstate;
                break;
            case EnemyState.SEEK:
                timealerta = TimeAlerta;
                navEnemy.speed = 1.7f;
                seek = true;
                anime.applyRootMotion = false;
                podeabrirPorta = true;
                anime.SetBool("Attack", false);
                navEnemy.isStopped = false;
                ultimoState = newstate;
                break;
            case EnemyState.ATTACK:
                anime.SetBool("Attack", true);
                podeabrirPorta = false;
                navEnemy.isStopped = true;
                ultimoState = newstate;
                break;
            case EnemyState.ALERTED:
                seek = false;
                navEnemy.isStopped = true;
                anime.applyRootMotion = true;
                ultimoState = newstate;
                podeabrirPorta = false;
                ultimoState = newstate;
                break;
            case EnemyState.ABRIUPORTA:
                anime.applyRootMotion = true;
                podeabrirPorta = false;
                navEnemy.isStopped = true;
                break;
        }

        state = newstate;
    }

    public override IEnumerator RadarAuditivo()
    {
        return base.RadarAuditivo();
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PortaIa>(out PortaIa porta) && !abriuPorta && !porta.scritPorta.locked && podeabrirPorta)
        {
            print("Abriu");
            porta.AbrirPortaIa();
            abriuPorta = true;
          //  MudarState(EnemyState.ABRIUPORTA);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PortaIa>(out PortaIa porta) && abriuPorta && !porta.scritPorta.locked && podeabrirPorta)
        {
            porta.FecharPortaIa();
            abriuPorta = false;
        }
    }
}
