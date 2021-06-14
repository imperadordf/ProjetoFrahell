using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Panda;

public class OcultistaScript : MonoBehaviour
{
    //Booleana para saber se esta seguindo, para quebrar a verificação da Visao e fazer uma falsa visao
    public bool isSeek;
    private void Update()
    {
        //Animação do Ocultista, pegando o valor da magnitude e transformando em positivo
        animator.SetFloat("Velocity", Mathf.Abs(agent.velocity.magnitude));
    }

    //Metodo que faz perseguir o Jogador
    [Task]
    public void SeekPlayer()
    {
        agent.SetDestination(playerTransform.position);
        animator.SetBool("Seeking", true);
        //Task.current.Succeed();
    }

    //Metodo que faz a patrulha, usando um Array de GameObject, tambem seguindo um Destino Patrol de bool, para fazer o Ocultista fica em alerta
    [Task]
    public void Patrol()
    {
        agent.isStopped = false;
        animator.SetBool("Seeking", false);
        Vector3 destination = patrolGameObjects[_contadorPatrol].transform.position;
        if (Vector3.Distance(destination, transform.position) < 1)
        {
            _contadorPatrol++;
            _destinoPatrol = true;
            if (_contadorPatrol >= patrolGameObjects.Length)
                _contadorPatrol = 0;
        }

        destination = patrolGameObjects[_contadorPatrol].transform.position;
        agent.SetDestination(destination);
        Task.current.Succeed();
    }


    //Metodo que faz o Ocultista fica em Alerta por um certo periodo de tempo, caso ele ja tenha chegado em um ponto do Patrol
    float timeStop = 0;
    [Task]
    public void Alerted()
    {
        if (_destinoPatrol)
        {
            timeStop = 5;
            agent.isStopped = true;
            _destinoPatrol = false;
        }

        Task.current.debugInfo = string.Format("tempo={0}", timeStop);
        timeStop = timeStop - Time.deltaTime;

        //Caso o tempo chegue a 0, a task foi finalizada
        if (timeStop <= 0)
        {
            Task.current.Succeed();
        }

    }

    //Verifica se o player esta na Visao do Ocultista
    [Task]
    bool VisionInPlayer()
    {
        //Caso o player ja esteja na visao e entrou no moodo perseguição, não é necessario faz a verificar da lista  de raycast
        if (isSeek)
        {
            if (DistancePlayer(10))
            {
                return true;
            }
        }

        //Aqui é criação de varios raycast, para fazer o Ocultista de uma visão por Raycast saindo em cada direção, podendo configurar na Unity
        float limiteCamadas = numeroDeCamadas * 0.5f;
        for (int x = 0; x <= raiosExtraPorCamada; x++)
        {
            for (float y = -limiteCamadas + 0.5f; y <= limiteCamadas; y++)
            {
                float angleToRay = x * (anguloDeVisao / raiosExtraPorCamada) + ((180.0f - anguloDeVisao) * 0.5f);
                Vector3 directionMultipl = (-objectVision.right) + (objectVision.up * y * distanciaEntreCamadas);
                Vector3 rayDirection = Quaternion.AngleAxis(angleToRay, objectVision.up) * directionMultipl;
                //
                RaycastHit hitRaycast;
                if (Physics.Raycast(objectVision.position, rayDirection, out hitRaycast, distanciaDeVisao, layerRay))
                {

                    if (!hitRaycast.transform.IsChildOf(transform.root))
                    {
                        print(hitRaycast.collider.tag + 2);
                        if (hitRaycast.collider.gameObject.CompareTag(tagdoPlayer))
                        {   //Caso ele collidar com a tag do Player, ele retorna verdadeiro e começa a perseguição
                            isSeek = true;
                            return true;
                        }
                    }
                }
            }
        }
        isSeek = false;
        return false;
    }

    //Distance do Player, retorna verdadeiro caso a distancia dele seja menor que a distance declarada no metodo
    [Task]
    bool DistancePlayer(float distance)
    {
        return (playerTransform.transform.position - transform.position).magnitude < distance;
    }

    //Animação de Attack
    [Task]
    public void Attack()
    {
        animator.SetTrigger("Ataque");
    }

    //Verifico se abrir uma porta
    [Task]
    bool OpenDoor()
    {   
        return _abriuPorta;
    }


    //Caso eu abrir uma porta, eu entro nessa logica e a distancia entre a IA e a Porta for maior que 2, eu fecho a porta 
    [Task]
    private void DistanceDoorOpen()
    {
        if (Vector3.Distance(transform.position, _portaIa.transform.position) > 2 && _portaIa.portaOpen)
        {
            _portaIa.FecharPortaIa();
            _abriuPorta = false;
            _portaIa = null;
            Task.current.Succeed();
        }
    }


    private void OnDrawGizmos()
    {
        //Mesmo sistema de Array de RAYCAST do VisionOnPLayer, apenas que é para Debug, pode verificar na Unity como esta a visao dele
        float limiteCamadas = numeroDeCamadas * 0.5f;
        for (int x = 0; x <= raiosExtraPorCamada; x++)
        {
            for (float y = -limiteCamadas + 0.5f; y <= limiteCamadas; y++)
            {
                float angleToRay = x * (anguloDeVisao / raiosExtraPorCamada) + ((180.0f - anguloDeVisao) * 0.5f);
                Vector3 directionMultipl = (-objectVision.right) + (objectVision.up * y * distanciaEntreCamadas);
                Vector3 rayDirection = Quaternion.AngleAxis(angleToRay, objectVision.up) * directionMultipl;
                //
                RaycastHit hitRaycast;
                if (Physics.Raycast(objectVision.position, rayDirection, out hitRaycast, distanciaDeVisao))
                {
                    if (!hitRaycast.transform.IsChildOf(transform.root))
                    {
                        if (hitRaycast.collider.gameObject.CompareTag(tagdoPlayer))
                        {
                            Debug.DrawRay(objectVision.position, rayDirection * distanciaDeVisao, Color.red);
                        }
                        else
                        {
                            Debug.DrawRay(objectVision.position, rayDirection * distanciaDeVisao, Color.blue);
                        }

                    }
                }
                else
                {
                    Debug.DrawRay(objectVision.position, rayDirection * distanciaDeVisao, Color.green);
                }
            }
        }
    }

    //Para saber se eu collidir com a porta assim eu abro ela e coloca abriu a porta como true, tambem verifico se a porta n esta trancada
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PortaIa>(out PortaIa porta) && !_abriuPorta && !porta.scritPorta.locked && !porta.portaOpen)
        {
            print("Abriu");
            porta.AbrirPortaIa();
            _abriuPorta = true;
            _portaIa = porta;
            //  MudarState(EnemyState.ABRIUPORTA);
        }
    }




    #region LOGIC VISION OCULTISTA  
    [Header("Vision Ocultista")]
    [SerializeField] private LayerMask layerRay;
    //Object que sai a vision do Player, a lsita de Raycast sai desse object
    [SerializeField] private Transform objectVision;

    // A distancia da Visão
    [SerializeField] private float distanciaDeVisao = 10;
    [Header("Raycast")]
    // A tag que é para saber que é o player (o que ele vai seguir)
    [SerializeField] private string tagdoPlayer = "Player";
    [Range(2, 180)]
    //Dar um valor de quantos raios vai ter 
    [SerializeField] private float raiosExtraPorCamada = 20;
    [Range(5, 180)]
    //O Valor do angulo de visão, qual sera o angulo do Raycast
    [SerializeField] private float anguloDeVisao = 120;
    [Range(1, 10)]
    //Numero de camadas, que seria a altura do raycast, quantas camadas
    [SerializeField] private int numeroDeCamadas = 3;
    [Range(0.02f, 0.15f)]
    //A distancia entre elas, se ela são separadas ou não
    [SerializeField] private float distanciaEntreCamadas = 0.1f;

    #endregion

    [Space]
    [Header("Componente Player")]
    // O transform do Player
    [SerializeField] private Transform playerTransform;
    //O navMeshAgent do Ocultista
    [SerializeField] private NavMeshAgent agent;

    //A LISTA de Gameobjects para o Patrol
    [SerializeField] private GameObject[] patrolGameObjects;
    //Animator para animaçao
    [SerializeField] Animator animator;

    //Booleana para verificar se ja chegou no destino do Patrol para fazer o Alerted
    private bool _destinoPatrol;
    //O Contador do Patrol para dar uma nova rota ao Ocultista
    private int _contadorPatrol;
    //Verificar se colidiu com a porta
    private bool _abriuPorta;

    private PortaIa _portaIa;

}
