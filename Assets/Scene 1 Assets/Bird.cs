using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Start is called before the first frame update
    
    // public Movement controller;
    public int birdType;
    public Animator animator;
    public float horizontalMove = -1f;
    [SerializeField] float runSpeed = 40f;
    private Rigidbody2D m_Rigidbody2D;
    [SerializeField] float deltaY;
    [SerializeField] float frequency;
    private float elapsed = 0;
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;   
    Vector3 m_Velocity = Vector3.zero;

    //constructs an NPC using parameters

    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        horizontalMove *= runSpeed;
        animator.SetInteger("Animation", birdType);
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
        if(!Movement.pause){
            elapsed += Time.deltaTime;
            Vector3 targetVelocity = new Vector2(horizontalMove, Mathf.Sin(elapsed * frequency) * deltaY);
                    // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            
        }
        else {
            m_Rigidbody2D.velocity = Vector3.zero;
        }
    }

    //NPC movement determined by script in subclasses
    // void FixedUpdate()
    // {
    //     controller.Move(horizontalMove *Time.fixedDeltaTime, false, false);
    // }
}
