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

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        boxCollider = this.GetComponent<BoxCollider2D>();
        sizeOffset = Random.Range(2f, 10f);
        player = cat.transform;
        
        
        //player = GameObject.FindWithTag("Player").transform;
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

        if ((transform.position.x < player.position.x && ball)||(transform.position.x > player.position.x && !ball))
        {
            //Debug.Log("Away");
            player = cat.transform;
            Vector3 direction = player.position - transform.position;
            movement = direction.normalized;
            // Scale spirit size so they look like the swim like squid lol
            float size = Mathf.Sin(Time.time * sizeOffset) * .25f + 1;
            transform.localScale = new Vector3(size, size, 1);
        }
    }

    void FixedUpdate()
    {
        if (Movement.pause) return;
        if ((transform.position.x < player.position.x && ball) || (transform.position.x > player.position.x && !ball))
        {
            moveMe(movement); 
        }
        else
        {
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

    void moveMe(Vector2 direction)
    {
        rb.MovePosition(rb.position + direction * swimSpeed * Time.fixedDeltaTime);
    }
    void noMoveMe(Transform transform)
    {
        rb.MovePosition(new Vector2(transform.position.x, transform.position.y));
    }
}