using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ocultista : InimigoMachine
{

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
                else
                {
                    MudarState(EnemyState.SEEK);
                }
                navEnemy.SetDestination(PositionPlayer.position);

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
        }
    }

    public override void MudarState(EnemyState newstate)
    {
        switch (newstate)
        {
            case EnemyState.PATROL:
                navEnemy.speed = 2;
                seek = false;
                timealerta = TimeAlerta;
                navEnemy.isStopped = false;
                break;
            case EnemyState.SEEK:
                timealerta = TimeAlerta;
                navEnemy.speed = 3;
                seek = true;
                if (Vector3.Distance(transform.position, PositionPlayer.position) <= 2 && !anime.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    anime.SetTrigger("Attack");
                }
                navEnemy.isStopped = anime.GetCurrentAnimatorStateInfo(0).IsName("Attack");
                break;
            case EnemyState.ALERTED:
                seek = false;
                navEnemy.isStopped = true;
                break;
        }

        state = newstate;
    }

    public override IEnumerator RadarAuditivo()
    {
        return base.RadarAuditivo();
    }
}
