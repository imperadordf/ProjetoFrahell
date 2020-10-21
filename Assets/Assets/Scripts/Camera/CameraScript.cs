using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    

    public Transform objectItem;
    public Transform objectItem2;
    

   public void CameraRotate2(float mouseX)
    {
        objectItem.Rotate((new Vector3(0, 0, -mouseX)));
        objectItem2.Rotate((new Vector3(0, 0, -mouseX)));
    }
}
