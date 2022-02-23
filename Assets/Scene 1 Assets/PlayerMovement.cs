using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Movement controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            crouch = true;
        } else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove *Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }


    public void ChangePos(double x, double y)
    {
        transform.position = new Vector2();
    }
    /*void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger Detected!");
    }*/
}
