using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateScript : Trigger
{
    public GameObject obj;
    public bool deactivate;

    public override void Action() {
        obj.SetActive(!deactivate);
    }
}
