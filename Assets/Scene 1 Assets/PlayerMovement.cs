using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Movement controller;
    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update() {
        // Horizontal value is for the animation state machine. No code required, wow!
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            crouch = true;
        } else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
