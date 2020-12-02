using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateriaInterative : MonoBehaviour
{
    public Material[] materias;
    bool mudouCor;
    public MeshRenderer mesh;
    public float emissiveIntesity = 50;
    public bool EmissiveBugado;
    public bool IsFoto;

    [Header("Tempo do Item")]
    public float tempoOcore= 10;
    public float emissiveItem = 30;
    public float grandiente = 0.1f;

    float emissive;
    private void Start()
    {
        RaycastFora();
        if (IsFoto)
        {
            StartCoroutine(ItemInterativeFoto());
        }
        else
        {
            StartCoroutine(ItemInterative());
        }
        
    }

    IEnumerator ItemInterativeFoto()
    {
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                emissive =  emissiveItem * i;
                mesh.sharedMaterial.SetColor("Emissive_Color", new Color(1, 1, 1, 1.0F) * emissive);
                yield return new WaitForSeconds(grandiente);
            }
            mesh.sharedMaterial.SetColor("Emissive_Color", new Color(1, 1, 1, 1.0F) * 0);
            yield return new WaitForSeconds(tempoOcore);
        }
    }

    IEnumerator ItemInterative()
    {
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                emissive = emissiveItem * i;
                mesh.sharedMaterial.SetColor("_EmissiveColor", new Color(1, 1, 1, 1.0F) * emissive);
                yield return new WaitForSeconds(grandiente);
            }

            for(int y = 10; y > 0; y--)
            {
                mesh.sharedMaterial.SetColor("_EmissiveColor", new Color(1, 1, 1, 1.0F) * emissive *y);
                yield return new WaitForSeconds(grandiente);
            }
           
            yield return new WaitForSeconds(tempoOcore);
        }
    }


    public void RaycastEmcima()
    {

            if (!mudouCor)
            {
                mesh.sharedMaterial.EnableKeyword("_EmissiveColorLDR");
                if (!EmissiveBugado)
                {
                    if(IsFoto)
                    mesh.sharedMaterial.SetColor("Emissive_Color", new Color(1, 1, 1, 1.0F) * emissiveIntesity);
                    else
                    mesh.sharedMaterial.SetColor("_EmissiveColor", new Color(1, 1, 1, 1.0F) * emissiveIntesity);
                }
                else
                {
                if (IsFoto)
                    mesh.sharedMaterial.SetColor("Emissive_Color", new Color(1, 1, 1, 1.0F) / emissiveIntesity);
                else
                mesh.sharedMaterial.SetColor("_EmissiveColor", new Color(1, 1, 1, 1.0F) / emissiveIntesity);
                }
                mudouCor = true;
            }
        
        
    }

   

    public void RaycastFora()
    {
        
        if (mudouCor)
        {
            if (IsFoto)
            {
                mesh.sharedMaterial.SetColor("Emissive_Color", new Color(0, 0, 0, 0.0F) * emissiveIntesity);
            }
            else
            {
                mesh.sharedMaterial.EnableKeyword("_EmissiveColorLDR");
                mesh.sharedMaterial.SetColor("_EmissiveColor", new Color(0, 0, 0, 0.0F) * emissiveIntesity);

            }
            
            mudouCor = false;
        }
    }
       
}
