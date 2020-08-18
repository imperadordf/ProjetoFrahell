using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator_Player;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        animator_Player = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        animator_Player.SetFloat("X", x);
        animator_Player.SetFloat("Y", y);

       animator_Player.SetBool("IsSpriting",Input.GetKey(KeyCode.LeftShift));
        
        
    }
}
