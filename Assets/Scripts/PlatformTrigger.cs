using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : Trigger
{
    public GameObject platform;
    public override void Action()
    {
        platform.GetComponent<Platform>().isMoving = true;
        platform.GetComponent<Platform>().Activate();
    }
}
