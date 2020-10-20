using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Item",menuName ="Item")]
public class Item : ScriptableObject
{
    public string textItem;
    
    public Sprite imagemItem;
    public GameObject itemObject;
    public RenderTexture texture2dCanvas;
    public ItemName nomeItem=ItemName.N_Interative;
    public AudioClip clipSom;
   
    public  virtual void UsarItem(VariavelGames vargeral)
    {

    }

    public  virtual RenderTexture ExpandirItem()
    {
        
        return texture2dCanvas;
    }

   

}

public enum ItemName
{
    Camera,
    Chave,
    N_Interative
}
