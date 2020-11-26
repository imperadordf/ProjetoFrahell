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
    private void Start()
    {
        RaycastFora();
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
