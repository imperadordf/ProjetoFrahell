using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorFase : MonoBehaviour
{
    public static GerenciadorFase instancie;

   public  ManagerCena cenaManager;
    public List<int> sustoListId;
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
        
       
        switch (level)
        {
            case 1:
                VerificarItem();
                VerificaSusto();
                break;
            case 2:
                VerificaSusto();
                break;
            case 3:
                VerificaSusto();
                VerificarItem();
                break;
            case 4:
                break;
            case 5:
                VerificarItem();
                break;
            case 6:
                break;
            case 7:
                VerificarItem();
                break;
        }
            

    }

    private void VerificarItem()
    {
        foreach (ButtonItem listaitem in GerenciadorItem.instacie.listButtonitens)
        {
            if (listaitem.item == null)
            {
                break;
            }
            else
            {
                for (int i = 0; i < cenaManager.itensCena.Count; i++)
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
    
    public void VerificaSusto()
    {
       foreach(int sustos in sustoListId)
        {
            foreach(Susto sustoCena in cenaManager.sustoLista)
            {
                if(sustoCena.id == sustos) 
                {
                    Destroy(sustoCena.gameObject);
                }

            }
        }
    }
}
