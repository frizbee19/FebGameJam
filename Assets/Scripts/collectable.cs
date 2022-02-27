using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : MonoBehaviour
{
    public int collect =0;
    public BoxCollider2D box;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") {
            box.isTrigger = true;
            this.gameObject.SetActive(false);
        }
    }
}
