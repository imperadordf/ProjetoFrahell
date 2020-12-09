using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class IAFumaca : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform destinion;
    SphereCollider sphere;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        sphere = GetComponent<SphereCollider>();
        StartPerseguicao();
    }

   public void StartPerseguicao()
    {
        agent.SetDestination(destinion.position);
        sphere.enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instancie.DanoSofre(10);
        }
    }
}
