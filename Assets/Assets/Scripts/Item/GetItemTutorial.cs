using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemTutorial : GetItem
{
    public TutorialManager tutorial;
    public override Item GetItemObject()
    {
       
        return base.GetItemObject();
    }

    private void OnDestroy()
    {
        tutorial.TutorialText("Open and Close your Inventory with I ");
    }
}
