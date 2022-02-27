using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TestingBehavior {
    Cycle,
    Set
};

public class AnimationControllerTester : MonoBehaviour {
    public Animator animator;
    public int numberOfAnimations = 1;
    public string animationPropertyName = "Animation";
    public TestingBehavior behavior = TestingBehavior.Cycle;
    public int setAnimationIndex = 0;

    void Start() {
        if (animator == null) {
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update() {
        if (behavior == TestingBehavior.Cycle) {
            // Get current time
            int second = (int) (Time.time / 1.5f);
            int animationIndex = second % numberOfAnimations;
            animator.SetInteger(animationPropertyName, animationIndex);
        } else {
            animator.SetInteger(animationPropertyName, setAnimationIndex);
        }
    }
}
