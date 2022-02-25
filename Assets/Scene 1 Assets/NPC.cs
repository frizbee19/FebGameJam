//WIP

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    
    public Movement controller;
    public Animator animator;
    float horizontalMove = 1f;
    public float runSpeed = 20f;
    public float leftBound;
    public float rightBound;
    float elapsed;
    public float minDelay;
    public float maxDelay;
    float delay;

    //constructs an NPC using parameters

    void Start()
    {
        delay = Random.Range(minDelay, maxDelay);
        horizontalMove = horizontalMove * runSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(elapsed > delay) {
            horizontalMove = -1 * (horizontalMove/Mathf.Abs(horizontalMove)) * runSpeed;
            elapsed = 0f;
            delay = Random.Range(minDelay, maxDelay);
        }
        if(Movement.pause) {
            animator.SetFloat("Horizontal", 0);
        }
        if (animator != null && !Movement.pause) {
            animator.SetFloat("Horizontal", (horizontalMove/Mathf.Abs(horizontalMove)));
            animator.SetBool("Airborne", !controller.m_Grounded);
        }
        elapsed += Time.deltaTime;
        if(transform.position.x > rightBound) {
            horizontalMove = -1 * runSpeed;
        }
        if(transform.position.x < leftBound) {
            horizontalMove = runSpeed;
        }
    }

    //NPC movement determined by script in subclasses
    void FixedUpdate()
    {
        controller.Move(horizontalMove *Time.fixedDeltaTime, false, false);
    }
}
