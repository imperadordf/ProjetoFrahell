using System.Collections;
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
    // ALERTA
    public float TimeAlerta;
    float timealerta;
    // Start is called before the first frame update
    
    void Start()
    {
        navEnemy = GetComponent<NavMeshAgent>();
        anime = GetComponent<Animator>();
        StartCoroutine(RadarAuditivo());
        timealerta = TimeAlerta;
        state = EnemyState.PATROL;
    }

    // Update is called once per frame
   
    void FixedUpdate()
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
                else if(timealerta<=0)
                {
                    MudarState(EnemyState.PATROL);
                }
                else
                {
                    timealerta -= Time.deltaTime;
                }

               
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
                timealerta = TimeAlerta;
                navEnemy.isStopped = false;
                break;
            case EnemyState.SEEK:
                timealerta = TimeAlerta;
                navEnemy.speed = 2;
                seek = true;
                if (Vector3.Distance(transform.position, PositionPlayer.position) <= 1 && !anime.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
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
    PATROL,
    ALERTED
}
