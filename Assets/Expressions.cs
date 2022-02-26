using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expressions : MonoBehaviour {
    public Animator animator;
    private int counter;

    // Start is called before the first frame update
    void Start() {
        counter = 0;
    }

    // Update is called once per frame
    void Update() {
        counter++;
        animator.SetInteger("Animation", (counter / 100) % 12);
    }
}
