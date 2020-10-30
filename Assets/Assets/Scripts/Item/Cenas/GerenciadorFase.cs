using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorFase : MonoBehaviour
{
    public static GerenciadorFase instancie;

   public  ManagerCena cenaManager;
    
    private void Awake()
    {
        if (!instancie)
        {
            instancie = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    private void OnLevelWasLoaded(int level)
    {
       cenaManager = FindObjectOfType<ManagerCena>();
        
       
            if(level==1 || level==3 || level == 5 || level == 7 || level == 9 || level ==11 || level == 13 || level == 15 && cenaManager)
            {
                foreach (ButtonItem listaitem in GerenciadorItem.instacie.listButtonitens)
                {
                    if (listaitem.item == null)
                    {
                       break;
                    }
                    else
                    {                 
                    for(int i =0;i<cenaManager.itensCena.Count;i++)
                    {
                       
                       if (cenaManager.itensCena[i].item.nomeItem == listaitem.item.nomeItem)
                        {
                            Destroy(cenaManager.itensCena[i].gameObject);
                            cenaManager.itensCena.Remove(cenaManager.itensCena[i]);
                        }
                    }
                    }
                }
            }

    }
}
