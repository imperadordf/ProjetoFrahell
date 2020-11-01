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
                switch (hit.collider.tag)
                {
                    case "Item":
                        Item item = hit.collider.GetComponent<GetItem>().item;
                        GerenciadorItem.instacie.ReceberItem(item);
                        // item.clipSom;
                        Destroy(hit.collider.gameObject);
                        
                        break;
                    case "Porta":
                        PortaScript portascript = hit.collider.GetComponent<PortaScript>();
                        GerenciadorItem.instacie.useritemArea = true;
                        if (portascript.locked)
                        {
                            GerenciadorItem.instacie.variaveGeral.scriptPorta = portascript;
                            hit.collider.GetComponent<PortaScript>().OpenTheDoorOurClose();
                        }
                        else
                        {
                            hit.collider.GetComponent<PortaScript>().OpenTheDoorOurClose();

                        }
                        break;
                    case "Turnel":
                        hit.collider.GetComponent<CarregaFase>().PlayAnimation();
                        break;
                    case "TurnelTurnel":
                        hit.collider.GetComponent<CarregaFaseTurnel>().CarregaFase();
                        break;
                    case "Puzzle":
                        hit.collider.GetComponent<PuzzleRei>().PuzzleGo();
                        break;
                    case "Armario":
                        hit.collider.GetComponent<Armario>().AbrirPorta();
                        break;
                    case "Roupa":
                        if (hit.collider.GetComponent<GetItem>())
                        {
                            Item itemn = hit.collider.GetComponent<GetItem>().item;
                            GerenciadorItem.instacie.ReceberItem(itemn);
                            Destroy(hit.collider.GetComponent<GetItem>());
                            hit.collider.gameObject.layer = 0;
                        }
                       
                        break;
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
