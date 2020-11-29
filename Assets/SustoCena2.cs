using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SustoCena2 : MonoBehaviour
{
    public PlayableDirector timelineSusto;
    public GameObject inimigoSusto;
    public MouseLook mouse;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instancie.ativarCutscene = true;
            mouse.enabled = false;
            timelineSusto.Play();
            Invoke("LigaMouseLook",(float)timelineSusto.duration);
            this.gameObject.SetActive(false);
            
        }
    }
   
    private void LigaMouseLook()
    {
        mouse.enabled = true;
        GameManager.instancie.ativarCutscene = false;
    }
}
