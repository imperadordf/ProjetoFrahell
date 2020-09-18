using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public string textItem;
    public string nomedoItem;
    public Sprite imagemItem;
    public GameObject itemObject;
    public RenderTexture texture2dCanvas;
    
    
    public  virtual void UsarItem(VariavelGames vargeral)
    {

    }

    public  virtual RenderTexture ExpandirItem()
    {
        
        return texture2dCanvas;
    }

}
