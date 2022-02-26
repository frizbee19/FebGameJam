using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookTrigger : Trigger
{
    public GameObject levelSelect;
    

    public override void Action()
    {
        levelSelect.SetActive(true);
    }
}
