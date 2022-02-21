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
        if (entered && counter >=150)
        {
            cam.transform.position -= moveCam;
            cat.transform.position -= moveCat;
            entered = false;
        }
        else
        {
            counter++;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!entered)
        {
            entered = true;

            Debug.Log("Trigger detected");
            cam.transform.position += moveCam;
            cat.transform.position += moveCat;
            Debug.Log(counter);
            counter = 0;
            //PlayerMovement.ChangePos(1, 2);
        }
    }

    /*void Interact(Collider2D col, ){
     * 
 }*/
}
