using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraItem : Item
{
    public override bool Intertive => false;
    // Start is called before the first frame update
    public override void UsarItem(VariavelGames varGeral)
    {
        
    }

    public override RenderTexture ExpandirItem()
    {
        return base.ExpandirItem();

    }
}
