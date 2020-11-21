using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CameraScript : MonoBehaviour, IBeginDragHandler, IDragHandler
{

    
    public Transform objectItem;
    public Transform objectItem2;
    float mouseX;
     public Selectable select;
    public float speed;
    public CameraVerificador scriptRotate;
    public void OnBeginDrag(PointerEventData data)
    {
        StartCoroutine(scriptRotate.Verificar());
    }

    public void OnDrag(PointerEventData data)
    {
        if (data.dragging)
        {
            CameraRotate2();
            Time.timeScale = 0.5f;
        }
    }



    
    public void CameraRotate2()
    {
        mouseX = Input.GetAxis("Mouse X");
        objectItem.Rotate((new Vector3(0, 0, -mouseX * speed)));
        objectItem2.Rotate((new Vector3(0, 0, -mouseX *speed  )));
    }
}
