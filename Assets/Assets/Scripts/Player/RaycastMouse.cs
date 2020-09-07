using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastMouse : MonoBehaviour
{
    public LayerMask layer;
    Image mouseImagem;
    public Camera cam;

    private void Start()
    {
        mouseImagem = GetComponent<Image>();
    }
    private void FixedUpdate()
    {
        RaycastHit hit;

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        if ((Physics.Raycast(ray, out hit, 2,layer)))
        {
            mouseImagem.color = Color.red;
            if (Input.GetKeyDown(KeyCode.E))
            {
                GerenciadorItem.instacie.ReceberItem(hit.collider.GetComponent<Item>());
                Destroy(hit.collider.gameObject);
            }
        }
        else
        {
            mouseImagem.color = Color.white;
        }
    }
}
