using UnityEngine;
using UnityEngine.Events;

// @MindfulMinun
public class Health : MonoBehaviour {
    public int startingHealth = 3;
    public int currentHealth;
    public bool isInvincible;
    public bool isDead;
    public Animator healthBarAnimator;
    public UnityEvent OnDead;
    public UnityEvent OnHit;

    void Start() {
        OnDead = new UnityEvent();
        OnHit = new UnityEvent();
        if (healthBarAnimator == null) {
            Debug.Log("HealthBarAnimator not found! Please attach the Health bar's animator to the Health script so the health bar can be animated.");
        }
        currentHealth = startingHealth;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            takeHit();
            OnHit.Invoke();
        }

        if (healthBarAnimator != null) {
            healthBarAnimator.SetInteger("Health", currentHealth);
        }
    }

    void takeHit() {
        if (isInvincible) return;
        currentHealth = Mathf.Clamp(currentHealth - 1, 0, startingHealth);
        isDead = currentHealth <= 0;
        if (isDead) OnDead.Invoke();
    }
}
