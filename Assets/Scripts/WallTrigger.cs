using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    bool entered = false;
    public GameObject cam;
    public GameObject cat;
    private int counter = 0;
    private Vector3 moveCam = new Vector3(20,0,0);
    private Vector3 moveCat = new Vector3(5,0,0);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         counter++;  
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (Input.GetButtonDown("Interact"))
        {
            Interact(col);
        }
        if (!entered && counter >= 6)
        {
            entered = true;

            //Debug.Log("Move Cam Right");
            //Vector3 test = Vector3.Lerp(cam.transform.position, new Vector3(cam.transform.position.x + 10, cam.transform.position.y + 5, -1.3f), 10f*Time.fixedDeltaTime);
            //Vector3 smoothedPos = Vector3.Lerp(transform.position, new Vector3(((target.position.x - offset.x)*rayLength),
            //target.position.y - offset.y, -65f), smoothSpeed * Time.fixedDeltaTime);
            //cam.transform.position += test;
            cam.transform.position += moveCam;
            //float x = Mathf.Abs(cam.transform.position.x - test.x);
            //float y = Mathf.Abs(cam.transform.position.y - test.y);
            
            cat.transform.position += moveCat;
            //Debug.Log(counter);
            counter = 0;
            //PlayerMovement.ChangePos(1, 2);
        }
        else if (counter >= 6 && entered)
        {
            //Debug.Log("Moved cam left");
            //Debug.Log(counter);
            cam.transform.position -= moveCam;
            cat.transform.position -= moveCat;
            entered = false;

            counter = 0;
        }

    }

    private void Interact(Collider2D col)
    {
        Debug.Log("Interact Buttion Pressed!!");
    }

}
