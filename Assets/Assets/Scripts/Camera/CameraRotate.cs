using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float velocidadeRotacao = 2;
    public LayerMask layer;
    public Transform objectItem;
    public Camera cameraoi;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = cameraoi.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, layer))
            {

                float mouseX = Input.GetAxis("Mouse X") * velocidadeRotacao;



                hit.collider.gameObject.transform.Rotate((new Vector3(0, 0, -mouseX)));

                if (hit.collider.TryGetComponent<CameraScript>(out CameraScript camerascript))
                {
                    camerascript.CameraRotate2(mouseX);
                }

            }
        }
    }
}
