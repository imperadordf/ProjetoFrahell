using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVerificador : MonoBehaviour
{
    public CameraPuzzle camerapuzzle;
   public  int verificador;
    public float tamanhoRay;

    public IEnumerator Verificar()
   {
        while (true)
        {
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(transform.position, transform.forward / 5, out hit, tamanhoRay))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "CameraNumero")
                    {
                        CameraNumero numeroScript = hit.collider.GetComponent<CameraNumero>();
                        camerapuzzle.RecebeNumero(verificador, numeroScript.numero);

                        print("Foi" + numeroScript.numero);
                   
                    }
                    else
                    {
                        camerapuzzle.RecebeNumero(verificador, 0);
                        print("Foi" + 0);
                    }
                }
                Debug.DrawRay(transform.position, transform.forward / 5, Color.red, tamanhoRay);
                yield return new WaitForSecondsRealtime(0.5f);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward/5, Color.red, tamanhoRay);
    }

}
