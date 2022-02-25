using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpirit : MonoBehaviour {
    public Transform player;
    public float swimSpeed = .25f;
    private Rigidbody2D rb;
    private Vector2 movement = Vector2.zero;
    private float sizeOffset = 1;

    void Start() {
        rb = this.GetComponent<Rigidbody2D>();
        sizeOffset = Random.Range(2f, 10f);
    }

    void Update() {
        if (Movement.pause) return;
        Vector3 direction = player.position - transform.position;
        movement = direction.normalized;
        // Scale spirit size so they look like the swim like squid lol
        float size = Mathf.Sin(Time.time * sizeOffset) + 4;
        transform.localScale = new Vector3(size, size, 1);
    }

    void FixedUpdate() {
        moveMe(movement);
    }

    void moveMe(Vector2 direction) {
        rb.MovePosition(rb.position + direction * swimSpeed * Time.fixedDeltaTime);
    }
}