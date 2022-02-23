using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : Trigger
{
    public GameObject TextBox;
    public GameObject HeadBox;
    public List<string> pages;
    public List<int> emotes;
    public Animator animator;
    public RuntimeAnimatorController controller;
    public Sprite startSprite;
    public AudioManager audioManager;
    public bool isTalking;
    GameObject instance;
    GameObject headInstance;
    void Instant() {
        instance = Instantiate(TextBox, TextBox.transform.position, Quaternion.identity);
        headInstance = Instantiate(HeadBox, HeadBox.transform.position, Quaternion.identity);
        instance.GetComponent<Dialogue>().pages = pages;
        instance.GetComponent<Dialogue>().emotes = emotes;
        headInstance.GetComponent<Animator>().runtimeAnimatorController = controller;
        instance.GetComponent<Dialogue>().animator = animator;
        instance.GetComponent<Dialogue>().animator.gameObject.SetActive(true);
        instance.GetComponent<Dialogue>().audioManager = audioManager;
        headInstance.GetComponent<SpriteRenderer>().sprite = startSprite;
        instance.SetActive(true);
        headInstance.SetActive(false);
        instance.GetComponent<Dialogue>().isOpen = true;
        instance.GetComponent<Dialogue>().isTalking = isTalking;
        
    }
    public override void Action()
    {
        Instant();
    }
}
