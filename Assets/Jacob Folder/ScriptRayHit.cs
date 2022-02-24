using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptRayHit : MonoBehaviour
{

    public RaycastHit2D hit;
    public Ray ray;
    private int counter;
    public Camera followCam;
    public Camera staticCam;
    private bool cam = false;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 4f);
        if (hit)
        {
            Debug.Log(" Hit a wall "+ hit.collider.name);
            staticCam.enabled = true;
            followCam.enabled = false;
            counter = 0;
            cam = true;
        }
        else if (cam && counter == 30)
        {
            staticCam.enabled = false;
            followCam.enabled = true;
            counter = 0;
            cam = false;
            Debug.Log("");
        }
        counter++;
    }

    
}
