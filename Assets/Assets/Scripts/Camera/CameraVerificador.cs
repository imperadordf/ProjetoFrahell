using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVerificador : MonoBehaviour
{
    public CameraPuzzle camerapuzzle;
   public  int verificador;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<CameraNumero>(out CameraNumero cameranumero))
        {
            camerapuzzle.RecebeNumero(verificador, cameranumero.numero);
            print("Foi");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<CameraNumero>(out CameraNumero cameranumero))
        {
            camerapuzzle.RecebeNumero(verificador, cameranumero.numero);
            print("Foi");
        }
        else
        {
            camerapuzzle.RecebeNumero(verificador, 0);
            print("Foi");
        }
    }
  
}
