using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public GameObject ItemPrefab;

    public GameObject GetItemObject()
    {
        return ItemPrefab;
    }
}
