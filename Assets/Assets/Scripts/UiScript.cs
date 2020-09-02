using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    public Image damageUi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator InterfaceDano()
    {
        damageUi.enabled = true;
        yield return new WaitForSeconds(0.5f);
        damageUi.enabled = false;
    }

}
