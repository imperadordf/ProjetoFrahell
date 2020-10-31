using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ocultista : InimigoMachine
{
    bool abriuPorta;
    bool podeabrirPorta=true;
    public GameObject danoObject;
    void Start()
    {
        PegarComponentes();
    }

    public override void PegarComponentes()
    {
        base.PegarComponentes();
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
                    RaycastHit hit1;
                    if (Physics.Raycast(objectVision.transform.position, objectVision.transform.TransformDirection(Vector3.forward), out hit1, distanceVision))
                    {
                        Debug.DrawRay(objectVision.transform.position, objectVision.transform.TransformDirection(Vector3.forward) * hit1.distance, Color.yellow);
                        if (hit1.collider.tag == "Player")
                        {
                            MudarState(EnemyState.SEEK);
                        }
                      
                    }

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

                RaycastHit hit;
                if (Physics.Raycast(objectVision.transform.position, objectVision.transform.TransformDirection(Vector3.forward), out hit, distanceVision))
                {
                    Debug.DrawRay(objectVision.transform.position, objectVision.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    if (hit.collider.tag == "Player")
                    {
                        MudarState(EnemyState.SEEK);
                    }
                }
                break;
            case EnemyState.ATTACK:
                if (Vector3.Distance(transform.position, PositionPlayer.position) <= 2)
                {
                    MudarState(EnemyState.ATTACK);
                }
                else
                {
                    MudarState(EnemyState.SEEK);
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
                navEnemy.speed = 2;
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
                break;
            case EnemyState.SEEK:
                timealerta = TimeAlerta;
                navEnemy.speed = 3;
                seek = true;
                anime.applyRootMotion = false;
                podeabrirPorta = true;
                anime.SetBool("Attack", false);
                navEnemy.isStopped = false;
                break;
            case EnemyState.ATTACK:
                anime.SetBool("Attack", true);
                podeabrirPorta = false;
                navEnemy.isStopped = true;
                break;
            case EnemyState.ALERTED:
                seek = false;
                navEnemy.isStopped = true;
                anime.applyRootMotion = true;
                podeabrirPorta = false;
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
            porta.AbrirPortaIa();
            abriuPorta = true;
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
