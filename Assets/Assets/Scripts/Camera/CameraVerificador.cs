using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVerificador : MonoBehaviour
{
    public CameraPuzzle camerapuzzle;
   public  int verificador;
    public float tamanhoRay;

   public CameraNumero numeroScript;
    public IEnumerator Verificar()
    {

        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward / 5);
            if (Physics.Raycast(ray, out hit, tamanhoRay))
            {
                
                    if (hit.collider.tag == "CameraNumero")
                    {
                        numeroScript = hit.collider.GetComponent<CameraNumero>();
                        camerapuzzle.RecebeNumero(verificador, numeroScript.numero);
                        print("Foi" + numeroScript.numero);
             
                
                    }
                    else
                    {
                        camerapuzzle.RecebeNumero(verificador, 0);
                        print("Foi" + 0);
                    }

               if(hit.transform.gameObject.tag=="CameraNumero")
            {
                print(hit.transform.GetComponent<CameraNumero>().numero);
            }
                    
                Debug.DrawRay(transform.position, transform.forward / 5, Color.red, tamanhoRay);
            yield return new WaitForSecondsRealtime(1);
        }
        
    }

    public void ApagarDados()
    {
        numeroScript = null;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward/5, Color.red, tamanhoRay);
    }

}
