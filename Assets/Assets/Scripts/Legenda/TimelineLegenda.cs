using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class TimelineLegenda : Susto
{
   public PlayableDirector timeline;
    public TextMeshProUGUI textLegenda;
    // Start is called before the first frame update
    void Start()
    {
        timeline.Play();
        Invoke("ApagarTimeline", (float)timeline.duration+1);
    }

    private void Update()
    {
        if(GameManager.instancie.ativarMenu || GameManager.instancie.ativarInventario)
        {
            timeline.Pause();
        }
        else
        {
            timeline.Resume();
        }
    }

    public void ApagarTimeline()
    {
        GerenciadorFase.instancie.sustoListId.Add(id);
        textLegenda.gameObject.SetActive(false);
       
    }

    private void OnDestroy()
    {
        textLegenda.gameObject.SetActive(false);
    }
}
