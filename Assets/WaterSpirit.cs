using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpirit : MonoBehaviour {
    private Transform player;
    public BoxCollider2D boxCollider;
    public float swimSpeed = .25f;
    private Rigidbody2D rb;
    private Vector2 movement = Vector2.zero;
    private float sizeOffset = 1;

    void Start() {
        rb = this.GetComponent<Rigidbody2D>();
        boxCollider = this.GetComponent<BoxCollider2D>();
        sizeOffset = Random.Range(2f, 3f);
        player = GameObject.FindWithTag("Player").transform;
        if (player == null) {
            Debug.Log("Player not found! Make sure Seiden's Char Movement has a tag of Player!");
        }
    }

    void Update() {
        if (Movement.pause) return;
        Vector3 direction = player.position - transform.position;
        movement = direction.normalized;
        // Scale spirit size so they look like the swim like squid lol
        float size = Mathf.Sin(Time.time * sizeOffset) * .25f + 1;
        transform.localScale = new Vector3(size, size, 1);
    }

    void FixedUpdate() {
        if (Movement.pause) return;
        moveMe(movement);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            collision.GetComponent<Health>().takeHit();
        }
    }

    void moveMe(Vector2 direction) {
        rb.MovePosition(rb.position + direction * swimSpeed * Time.fixedDeltaTime);
    }
}
