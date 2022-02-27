using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booMovement : MonoBehaviour
{
    private Transform player;
    public BoxCollider2D boxCollider;
    public float swimSpeed = .25f;
    private Rigidbody2D rb;
    private Vector2 movement = Vector2.zero;
    private float sizeOffset = 1f;
    public GameObject cat;
    public bool ball;
    public Movement mvt;
    public Animator anim;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        boxCollider = this.GetComponent<BoxCollider2D>();
        sizeOffset = Random.Range(2f, 10f);
        player = cat.transform;
        
        if (player == null)
        {
            Debug.Log("Player not found! Make sure Seiden's Char Movement has a tag of Player!");
        }
    }

    void Update()
    {
        if (Movement.pause) return;
        //if (boxCollider.transform.x < cat.transform.x && m_FacingRight)
         mvt = cat.GetComponent<Movement>();
        ball = mvt.m_FacingRight;

        if ((transform.position.x < player.position.x && ball)||(transform.position.x > player.position.x && !ball)) {
            player = cat.transform;
            Vector3 direction = player.position - transform.position;
            movement = direction.normalized;
        }
    }

    void FixedUpdate() {
        if (Movement.pause) return;
        if ((transform.position.x < player.position.x && ball) || (transform.position.x > player.position.x && !ball)) {
            moveMe(movement);
        } else {
            noMoveMe(transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().takeHit();
        }
    }

    void moveMe(Vector2 direction) {
        if (anim != null) anim.SetBool("Shy?", false);
        rb.MovePosition(rb.position + direction * swimSpeed * Time.fixedDeltaTime);
    }
    void noMoveMe(Transform transform) {
        if (anim != null) anim.SetBool("Shy?", true);
        rb.MovePosition(new Vector2(transform.position.x, transform.position.y));
    }
}
