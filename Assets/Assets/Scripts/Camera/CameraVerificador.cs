using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVerificador : MonoBehaviour
{
    public CameraPuzzle camerapuzzle;
   public  int verificador;
    public float tamanhoRay;
    public bool oie;
   public CameraNumero numeroScript;
   

    private void OnTriggerEnter(Collider other)
    {
       if( other.CompareTag("CameraNumero")){
            numeroScript = other.GetComponent<CameraNumero>();
            camerapuzzle.RecebeNumero(verificador, numeroScript.numero);
            print("Foi" + numeroScript.numero);
        }
    }
    public void ApagarDados()
    {
        numeroScript = null;

    }

   
}
