using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour {
    public float speed = 3f;
    
    private Rigidbody2D rb;
    public Vector2 startPositionRelativeToTransform;
    public Vector2 endPositionRelativeToTransform;

    private Vector2 absStartPosition, absEndPosition;

    void Start() {
        rb = this.GetComponent<Rigidbody2D>();
        absStartPosition = startPositionRelativeToTransform + rb.position;
        absEndPosition = endPositionRelativeToTransform + rb.position;
    }

    void FixedUpdate() {
        if (Movement.pause) return;
        // Calculate distance to end
        Vector2 distanceToFinish = absEndPosition - rb.position;

        if (distanceToFinish.magnitude < .02) {
            // If we're close enough to the end, reverse direction
            Vector2 temp = absStartPosition;
            absStartPosition = absEndPosition;
            absEndPosition = temp;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        Vector2 direction = absEndPosition - rb.position;

        moveMe(direction.normalized);
    }
    void moveMe(Vector2 direction) {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}
