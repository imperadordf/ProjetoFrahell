using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "DicasGame", menuName = "Assets/DicasGame", order = 0)]
public class DicasGame : ScriptableObject {
     public Sprite imageItem;

     public string nameItem;
    [TextArea(3,6)]
    public string dicaText;
}

