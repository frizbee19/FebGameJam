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
    private Vector3 moveCat = new Vector3(4,0,0);
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
        if (!entered && counter >= 120)
        {
            entered = true;

            //Debug.Log("Move Cam Right");
            cam.transform.position += moveCam;
            cat.transform.position += moveCat;
            //Debug.Log(counter);
            counter = 0;
            //PlayerMovement.ChangePos(1, 2);
        }
        else if (counter >= 120 && entered)
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

    /*void Interact(Collider2D col, ){
     * 
 }*/
}
