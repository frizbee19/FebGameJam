using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Vector3 positionToMoveTo;
    public float length;
    Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
        StartCoroutine(LerpPosition(positionToMoveTo, length));
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
        if(transform.position == positionToMoveTo) {
            Switch();
            StartCoroutine(LerpPosition(positionToMoveTo, length));
        }
    }


}
