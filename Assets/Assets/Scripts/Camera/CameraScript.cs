using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CameraScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
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
            
        }
        else
        {
            scriptRotate.ApagarDados();
        }
    }


    public void OnEndDrag(PointerEventData data)
    {
        GameManager.instancie.DefinirTimeScale(1);
        print("OIEE");
    }
    
    public void CameraRotate2()
    {
        mouseX = Input.GetAxis("Mouse X");
        objectItem.Rotate((new Vector3(0, 0, -mouseX * speed)));
        objectItem2.Rotate((new Vector3(0, 0, -mouseX *speed  )));
    }
}
