using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : Trigger
{
    public Dialogue TextBox;
    public override void Action()
    {
        TextBox.gameObject.SetActive(true);
        TextBox.GetComponent<Dialogue>().isOpen = true;
    }
}
