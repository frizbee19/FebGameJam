//WIP

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    
    public Movement controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    public string title = "";

    //constructs an NPC using parameters
    public NPC(string name, float run, float hor) 
    {
        title = name;
        runSpeed = run;
        horizontalMove = hor;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //NPC movement determined by script in subclasses
    void FixedUpdate()
    {
        controller.Move(horizontalMove *Time.fixedDeltaTime, false, false);
    }
}
