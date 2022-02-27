using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : Trigger
{
    // Start is called before the first frame update
    public GameObject player;
    public Vector2 respawn;
    [SerializeField] bool canHurt = true;

    public override void Action() {
        player.transform.position = respawn;
        if(canHurt) {
            player.GetComponent<Health>().takeHit();
        }
    }
}
