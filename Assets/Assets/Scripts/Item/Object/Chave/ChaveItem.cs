using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaveItem : Item
{
    public override bool Intertive => true;
    public override void UsarItem(VariavelGames varGeral)
    {
        varGeral.scriptPorta.locked = false;
    }

    public override RenderTexture ExpandirItem()
    {
        return base.ExpandirItem();
    }
}
