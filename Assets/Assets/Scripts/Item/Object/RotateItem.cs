using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    public float velocidadeRotacao = 2;

    public Transform objectItem;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * velocidadeRotacao;
        float mouseY = Input.GetAxis("Mouse Y") * velocidadeRotacao;

        if (Input.GetMouseButton(0))
        {
            objectItem.Rotate(new Vector3(-mouseY, -mouseX));
        }
       
    }
}
