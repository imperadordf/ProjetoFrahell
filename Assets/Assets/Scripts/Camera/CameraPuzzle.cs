using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPuzzle : MonoBehaviour
{
    

    public double numeroCerto1;
    public double numeroCerto2;
    public double numeroCerto3;

    bool verificador1, verificador2, verificador3;

    public double numeroteste1, numeroteste2, numeroteste3;
    public void RecebeNumero(int verificadornumero, double numero)
    {
        switch (verificadornumero)
        {
            case 1:
                if (numero == numeroCerto1)
                {
                    verificador1 = true;
                }
                else
                {
                    verificador1 = false;
                }
                numeroteste1 = numero;
                break;
            case 2:
                if (numero == numeroCerto2)
                {
                    verificador2 = true;
                }
                else
                {
                    verificador2 = false;
                }
                numeroteste2 = numero;
                break;
            case 3:
                if (numero == numeroCerto3)
                {
                    verificador3 = true;
                }
                else
                {
                    verificador3 = false;
                }
                numeroteste3 = numero;
                break;
        }

        if (verificador3 && verificador2 && verificador1)
        {
            print("Foi Ganhou o item");
        }
    }
}
