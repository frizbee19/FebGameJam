using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrigger : Trigger
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Action() {
        Destroy(this.gameObject);
    }
}
