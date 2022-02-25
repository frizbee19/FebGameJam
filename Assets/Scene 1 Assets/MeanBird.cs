using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeanBird : MonoBehaviour
{
    // Start is called before the first frame update
    public Movement controller;
    public Animator animator;
    [SerializeField] float runSpeed = 5.0f;
    // private Rigidbody2D m_Rigidbody2D;
    private bool attack;
    private Vector3 direction;
    Transform player;
    [SerializeField] float detectRange;

    private float accelTime = 1f;
    private float elapsed = 0f;
    private float t;

    //constructs an NPC using parameters

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Movement.pause) {
        //     animator.SetFloat("Horizontal", 0);
        // }
        // if (animator != null && !Movement.pause) {
        //     animator.SetFloat("Horizontal", (horizontalMove/Mathf.Abs(horizontalMove)));
        //     animator.SetBool("Airborne", !controller.m_Grounded);
        // }
        

    }

    private void FixedUpdate() {
        if(!attack) {
            direction = player.position - transform.position;
            if(direction.magnitude < detectRange) {
                attack = true;
                Debug.Log("attack");

            }
        }
        else {
            if(t < 1f) {
                t = elapsed / accelTime;
                t = t * t * (3f - 2f * t);
            }
            else {
                t = 1f;
            }
            GetComponent<Rigidbody2D>().MovePosition(transform.position + direction.normalized * runSpeed * t / 100f);
            elapsed += Time.fixedDeltaTime;
        }
    }
}
