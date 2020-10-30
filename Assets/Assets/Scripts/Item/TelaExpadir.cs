using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelaExpadir : MonoBehaviour
{
    public List<ItemExpadir> itemlist;
    public RenderTexture textureItem;
   public void ExpadirItem(ItemName itemname)
    {
        foreach (ItemExpadir itens in itemlist)
        {
            if (itens.nameitem == itemname)
            {
                itens.AtivareDesativaGameObject(true);
                print(itens.nameitem);
                
            }
            print(itens.name);
        }
    }

    public void Fechartelas()
    {

        foreach (ItemExpadir itens in itemlist)
        {
            itens.AtivareDesativaGameObject(false);
        }
    }

}
