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

    // Start is called before the first frame update
    void Start()
    {
        navEnemy = GetComponent<NavMeshAgent>();
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case EnemyState.PATROL:
                
                break;
            case EnemyState.SEEK:
                break;
        }
    }

    private void MudarState()
    {

    }
}

public enum EnemyState
{
    SEEK,
    PATROL
}
