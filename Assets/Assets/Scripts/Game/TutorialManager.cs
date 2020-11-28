using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    bool tutorialInventario;
   
    public void TutorialText(string tutorial)
    {
        text.text = tutorial;
        text.enabled = true;    
        StartCoroutine(AtivarDesativa());
    }

    IEnumerator AtivarDesativa()
    {
        
        while (true)
        {
            if (GameManager.instancie.ativarInventario)
            {
                text.enabled = false;
                break;
            }
            else if(!tutorialInventario)
            {
                Invoke("DesativarText", 10);
                tutorialInventario = true;
            }
            else if (text.enabled==false)
            {
                break;      
            }

            yield return new WaitForSeconds(0.1f);
            
        }
    }

    public void DesativarText()
    {
        if (text.enabled =! false)
        {
            text.text = "";
            text.enabled = false;
        }
        
    }
    
}
