using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool isMoving;
    public Vector3 positionToMoveTo;
    public float length;
    float prevY;
    Vector3 startPos;
    void Start()
    {
        if(isMoving)
        {
            startPos = transform.position;
            StartCoroutine(LerpPosition(positionToMoveTo, length));
        }
    }
    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        while (time < duration)
        {
            float t = time / duration;
            t = t * t * (3f - 2f * t);
            transform.position = Vector3.Lerp(startPos, targetPosition, t);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }

    void Switch() {
        Vector3 temp = startPos;
        startPos = positionToMoveTo;
        positionToMoveTo = temp;
    }

    // Update is called once per frame
    void Update()
    {

        if(isMoving) {
            if(transform.position == positionToMoveTo) {
                Switch();
                StartCoroutine(LerpPosition(positionToMoveTo, length));
            }
        }
    }

    // void OnCollisionEnter2D (Collision2D other) {
        
    //      if (other.gameObject.tag == "Player") {
    //          if(goThrough) {
    //             if(other.gameObject.GetComponent<Movement>().m_Velocity.y > 0.01f) {
    //                 GetComponent<Collider2D>().isTrigger = true;
    //             }
    //             else
    //             {
    //                 GetComponent<Collider2D>().isTrigger = false;
    //             }
    //          }
    //      }
    //  }
    void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "Player") {
            other.gameObject.transform.parent = transform;
        }
        // if(other.gameObject.tag == "Enemy") {
        //     Debug.Log("take hit");
        //     health.takeHit();
        // }
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
}
