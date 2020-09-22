using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastMouse : MonoBehaviour
{
    public LayerMask layer;
    public Image mouseImagem;
    public Camera cam;
    
    private void Start()
    {
       
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
                if (hit.collider.tag == "Item")
                {
                    Item item = new Item();
                    item = hit.collider.GetComponent<GetItem>().ItemPrefab.GetComponent<Item>();
                    GerenciadorItem.instacie.ReceberItem(item);
                    Destroy(hit.collider.gameObject);
                    mouseImagem.color = Color.red;
                }
                else if (hit.collider.tag=="Porta" )
                {
                    PortaScript portascript = hit.collider.GetComponent<PortaScript>();
                    GerenciadorItem.instacie.useritemArea = true;
                    if (portascript.locked)
                    {
                        GerenciadorItem.instacie.variaveGeral.scriptPorta = portascript;
                    }
                    else
                    {
                        hit.collider.GetComponent<PortaScript>().OpenTheDoorOurClose();
                    }
                    
                }

                

            }
        }
        else
        {
            mouseImagem.color = Color.white;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Porta"))
        {
            GerenciadorItem.instacie.variaveGeral.scriptPorta = other.GetComponent<PortaScript>();
            GerenciadorItem.instacie.useritemArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Porta"))
        {
            GerenciadorItem.instacie.useritemArea = false;
        }
    }
}
