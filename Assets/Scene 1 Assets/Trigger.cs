using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//to implement inheritance
public abstract class Trigger : MonoBehaviour
{
    //tags for the trigger
    public bool forceInteract;
    public bool repeatable;
    bool isActive;
    //only worry about this if it is not repeatable
    bool hasOccurred;
    public int value;
    // Start is called before the first frame update
    void Start()
    {
        hasOccurred = false;
    }

    //checks if player is in range of the trigger
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            isActive = false;
        }
        if(forceInteract && repeatable) {
            hasOccurred = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //checks if conditions are right
        if(isActive && !hasOccurred) 
        {
            //executes action upon entering
            if(forceInteract) 
            {
                Action();
                hasOccurred = true;
                isActive = false;
            }
            //only executes action if input is pressed
            else
            {
                if(Input.GetKeyDown(KeyCode.E)) {
                    Action();
                    if(!repeatable)
                    {
                        hasOccurred = true;
                    }
                }
            }
        }
    }

    public abstract void Action();

}
