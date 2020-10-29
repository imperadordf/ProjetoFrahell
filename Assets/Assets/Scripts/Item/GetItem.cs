using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public Item item;

    
    public Item GetItemObject()
    {
       
        item.pegou = true;
        return item;
        
    }
    
}
