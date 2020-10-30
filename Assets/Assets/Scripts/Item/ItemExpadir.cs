using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemExpadir : MonoBehaviour
{
    public ItemName nameitem;
    public GameObject myGameObject;

    public void AtivareDesativaGameObject(bool ativado)
    {
        this.gameObject.SetActive(ativado);
    }

    
}
