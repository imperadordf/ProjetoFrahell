using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using TMPro;
public class IAFumaca : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform destinion;
    SphereCollider sphere;
    public AudioClip [] clipVozes;
    public AudioSource audioVoz;
    public VisualEffect effect;
    public AudioSource sourceFundo;

    [Header("TimelineLegenda")]
    public PlayableDirector timeline;
    PlayableGraph graph = PlayableGraph.Create();
    // Start is called before the first frame update

    private void Start()
    {
        StartPerseguicao();
    }
    public void StartPerseguicao()
    {
        
        agent = GetComponent<NavMeshAgent>();
        sphere = GetComponent<SphereCollider>();
        agent.SetDestination(destinion.position);
        sphere.enabled = true;
        StartCoroutine(Falar());
        
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instancie.DanoSofre(10);
        }
        else if (other.CompareTag("Inimigo"))
        {
            effect.SendEvent("Stop");
            audioVoz.Stop();
            sourceFundo.Stop();
            Destroy(gameObject);
        }
    }

    IEnumerator Falar()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            audioVoz.clip = clipVozes[Random.Range(0, clipVozes.Length)];
            audioVoz.Play();
            yield return new WaitForSeconds(8);
        }
    }
    
   
   
}
