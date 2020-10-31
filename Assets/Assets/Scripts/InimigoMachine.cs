using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoMachine : MonoBehaviour
{
    public EnemyState state;
    public List<GameObject> patrolObject;
    public NavMeshAgent navEnemy;
    public  Animator anime;

    public Transform PositionPlayer;
    public Player PlayerScript;
    
    public static int i = 0;
    public static bool seek;
    // A distancia minima para seguir e a distancia maxima para seguir
    [Range(0, 50)]
    public float distanceMaxSeek=20;
    public static float distanceMinSeek=10;
    // Distancia da Audição
    [Range(0, 30)]
    public float distanceSeekCorrendo=20;
    public float distanceSeekAndando=10;
    public float distanceSeekAgachado=0;
    // ALERTA
    public float TimeAlerta;
    public static float timealerta;
    //Distancia da visão
    [Range(0, 30)]
    public float distanceVision = 20;
    public GameObject objectVision;

    // Start is called before the first frame update

   

    public virtual void PegarComponentes()
    {
        navEnemy = GetComponent<NavMeshAgent>();
        anime = GetComponent<Animator>();
        StartCoroutine(RadarAuditivo());
        timealerta = TimeAlerta;
        state = EnemyState.PATROL;
    }
    // Update is called once per frame

  

    public virtual void MaquinaDeEstado()
    {
       
    }
    public virtual void MudarState(EnemyState newstate)
    {

    }

    //Sabe se o player esta correndo, andando ou agachado
   public virtual IEnumerator RadarAuditivo()
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
    ALERTED,
    ATTACK
}
