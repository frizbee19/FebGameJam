using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour {
    public Movement controller;
    public Animator animator;
    public Health health;
    public Animator healthBarAnimator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Awake() {
        if (health == null) {
            Debug.Log("Health not found! Please attach the Health script to the player so the player can take damage.");
        } else {
            health.OnHit.AddListener(OnHit);
            health.OnDead.AddListener(OnDead);
        }
    }

    // Update is called once per frame
    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            crouch = true;
        } else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            crouch = false;
        }
        
        if (Movement.pause) {
            animator.SetFloat("Horizontal", 0);
        } else if (animator != null) {
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
            animator.SetBool("Airborne", !controller.m_Grounded);
            if (healthBarAnimator != null) {
                healthBarAnimator.SetInteger("Health", health.currentHealth);
            }
        }
    }
    void FixedUpdate() {
        if (Movement.pause) return;
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    //if colliding with platform, move with platform
    void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "Platform") {
            transform.parent = other.transform;
        }
        //  if(other.gameObject.tag == "Detection") {
        //     Debug.Log("detect");
        //      other.gameObject.GetComponent<MeanBird>().Detected(transform.position - other.gameObject.transform.position);
        //  }
    }
    void OnCollisionExit2D (Collision2D other) {
        if (other.gameObject.tag == "Platform") {
            transform.parent = null;
        }
    }


    public void ChangePos(double x, double y) {
        transform.position = new Vector2();
    }
    /*void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger Detected!");
    }*/

    void OnHit() {
        Debug.Log("Hit Detected!");
    }

    void OnDead() {
        Debug.Log("Fuck, I'm dead!");
        Movement.pause = true;
    }
}
