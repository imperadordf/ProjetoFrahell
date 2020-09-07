using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonItem : MonoBehaviour
{
    private Item item;
    public Image imagemitem;
    // Start is called before the first frame update

    
    public void RecebeItem(Item item)
    {
        this.item = item;
        imagemitem.sprite = item.imagemItem;
    }

    public Item RetornItem()
    {
        return item;
    }

    public void InteragerItem()
    {
        GerenciadorItem.instacie.ClicouItem(item);
    }
}
