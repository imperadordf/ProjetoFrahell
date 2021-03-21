using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class TimelineLegenda : Susto
{
   public PlayableDirector timeline;
    public TextMeshProUGUI textLegenda;
    public bool jumpTimeline=false;
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

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && jumpTimeline)
        {
            ApagarTimeline();
        }
    }

    public void ApagarTimeline()
    {
        GerenciadorFase.instancie.sustoListId.Add(id);
        textLegenda.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        textLegenda.gameObject.SetActive(false);
    }
}
