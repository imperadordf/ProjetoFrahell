using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraScript : MonoBehaviour   
{

    
    public Transform objectItem;
    public Transform objectItem2;
    float mouseX;
     public Selectable select;

    private void Update()
    {
       
    }

    
    public void CameraRotate2()
    {
        mouseX = Input.mousePosition.x;
        objectItem.Rotate((new Vector3(0, 0, -mouseX)));
        objectItem2.Rotate((new Vector3(0, 0, -mouseX)));
    }
}
