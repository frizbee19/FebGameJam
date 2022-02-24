using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Transform detectionPoint;
    public float radius = 3f;
    public LayerMask detectLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    bool InteractInput() {
        if(Input.GetKeyDown(KeyCode.E))
            Debug.Log("input");
        return true;
    }
    // Update is called once per frame
    void Update()
    {
        if(DetectObject()) {
            if(InteractInput()) {
                Debug.Log("interacted");
            }
        }
    }

    bool DetectObject() {
        if(Physics2D.OverlapCircle(detectionPoint.position, radius, detectLayer))
            Debug.Log("detected");
        return false;
    }
}
