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


  
    public void Confirmar()
    {
      // scriptRotate.Verificar();
        StartCoroutine(VerificarOsNumeros());
    }

    public IEnumerator VerificarOsNumeros()
    {
        GameManager.instancie.ativarPuzzle = false;
        yield return new WaitForSeconds(0.3f);
        GameManager.instancie.ativarPuzzle = true;
    }
    public void CameraRotate2()
    {
        mouseX = Input.GetAxis("Mouse X");
        objectItem.Rotate((new Vector3(0, 0, -mouseX * speed)));
        objectItem2.Rotate((new Vector3(0, 0, -mouseX *speed  )));
    }
}
