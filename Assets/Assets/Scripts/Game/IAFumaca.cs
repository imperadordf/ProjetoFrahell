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
    public SustoPerseguicao susto;

    [Header("TimelineLegenda")]
    public PlayableDirector timeline;
    public TextMeshProUGUI text;
    public TimelineAsset assetTime;
    LegendaTrack trackLegenda;
    LegendaClip clipLegenda;
    TimelineClip timelineclip;
    // Start is called before the first frame update

  
    public void StartPerseguicao()
    {
        trackLegenda = (LegendaTrack)assetTime.GetOutputTrack(0);
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
            GerenciadorFase.instancie.sustoListId.Add(susto.id);
            Destroy(gameObject);
        }
    }

    IEnumerator Falar()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            int random = Random.Range(0, clipVozes.Length);
            audioVoz.clip = clipVozes[random];
            LegendaFalar(random, audioVoz.clip);
            audioVoz.Play();
            yield return new WaitForSeconds(8);
        }
    }
    
   public void LegendaFalar(int index, AudioClip clip)
    {
        timelineclip = trackLegenda.CreateClip<LegendaClip>();
        clipLegenda = (LegendaClip)timelineclip.asset;
        timelineclip.easeInDuration = 0.5f;
        timelineclip.easeOutDuration = 0.5f;
        switch (index)
        {
            case 0:
                clipLegenda.legendaText = "Die Die Die";
                break;
            case 1:
                clipLegenda.legendaText = "I'll kill you";
                break;
            case 2:
                clipLegenda.legendaText = "You have no escape";
                break;
            case 3:
                clipLegenda.legendaText = "Don't Run";
                break;
        }
        timelineclip.duration = clip.length;
        timeline.Play();
        Invoke("DeleterClip",(float) timeline.duration);
    }

    private void DeleterClip()
    {
        trackLegenda.timelineAsset.DeleteClip(timelineclip);
    }

    private void OnDestroy()
    {
        DeleterClip();
    }

}
