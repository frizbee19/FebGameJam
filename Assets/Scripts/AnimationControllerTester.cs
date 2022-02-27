using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerTester : MonoBehaviour {
    public Animator animator;
    public int numberOfAnimations = 1;
    public string animationPropertyName = "Animation";

    // Update is called once per frame
    void Update() {
        // Get current time
        int second = (int) (Time.time / 1.5f);
        int animationIndex = second % numberOfAnimations;
        animator.SetInteger(animationPropertyName, animationIndex);
    }
}
