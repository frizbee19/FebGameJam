using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookTrigger : Trigger
{
    public GameObject bookFinder;
    

    public override void Action()
    {
        bookFinder.GetComponent<WorldScreenController>().OpenBook();
    }
}
