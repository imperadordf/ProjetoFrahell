using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensibilidadeMouse=100;
    RaycastHit hit = new RaycastHit();
    public Transform playerTransforme;
    public Player scriptPlayer;
    public float xRotation=0;
    public Transform pescoco;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeMouse * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -74.458f, 74.458f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        playerTransforme.Rotate(Vector3.up * mouseX);
        scriptPlayer.AnimationRotation(mouseX);

      
    }

    public void Morreu()
    {
        transform.SetParent(pescoco);
    }
}
