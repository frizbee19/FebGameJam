using UnityEngine;
using UnityEngine.Events;
using System.Collections;

// @MindfulMinun
public class Health : MonoBehaviour {
    public int startingHealth = 3;
    public float damageTimeout = 1f;
    public int currentHealth;
    public bool isInvincible;
    public bool isDead;
    public UnityEvent OnDead = new UnityEvent();
    public UnityEvent OnHit = new UnityEvent();
    public GameObject three,two,one,zero;
    public AudioManager audioManager;

    void Start() {
        currentHealth = startingHealth;
    }

    void Update() {
        // if (Input.GetKeyDown(KeyCode.)) {
        //     takeHit();
        // }
    }

    public void takeHit() {
        if (isInvincible) return;
        currentHealth = Mathf.Clamp(currentHealth - 1, 0, startingHealth);
        isDead = currentHealth <= 0;
        OnHit.Invoke();
        if (currentHealth == 2)
        {
            three.SetActive(false);
            two.SetActive(true);
        }
        if (currentHealth == 1)
        {
            two.SetActive(false);
            one.SetActive(true);
        }
        if (currentHealth == 0)
        {
            one.SetActive(false);
            zero.SetActive(true);
        }
            audioManager.Play("pencilbreak");
        if (isDead) OnDead.Invoke();
        StartCoroutine(damageTimer());
    }

    // Waits for a second before allowing the player to take damage again
    private IEnumerator damageTimer() {
        bool wasInvincible = isInvincible;
        isInvincible = true;
        yield return new WaitForSeconds(damageTimeout);
        isInvincible = wasInvincible;
    }
}
