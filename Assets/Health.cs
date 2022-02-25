using UnityEngine;
using UnityEngine.Events;

// @MindfulMinun
public class Health : MonoBehaviour {
    public int startingHealth;
    public int currentHealth;
    public bool isInvincible;
    public bool isDead;
    public UnityEvent OnDead;
    public UnityEvent OnHit;

    void Start() {
        OnDead = new UnityEvent();
        OnHit = new UnityEvent();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            takeHit();
            OnHit.Invoke();
        }
    }

    void takeHit() {
        if (isInvincible) return;
        currentHealth = Mathf.Clamp(currentHealth - 1, 0, startingHealth);
        isDead = currentHealth <= 0;
        if (isDead) OnDead.Invoke();
    }
}
