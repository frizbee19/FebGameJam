using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : Trigger
{
    public GameObject TextBox;
    // public GameObject HeadBox;
    public List<string> pages;
    public List<int> emotes;
    public RuntimeAnimatorController controller;
    public Sprite startSprite;
    public AudioManager audioManager;
    public bool isTalking;
    GameObject instance;
    // GameObject instance;
    // GameObject headInstance;
    void Instant() {
        instance = Instantiate(TextBox, TextBox.transform.position, Quaternion.identity);
        instance.SetActive(true);
        instance.GetComponent<Dialogue>().pages = pages;
        instance.GetComponent<Dialogue>().emotes = emotes;
        instance.GetComponent<Dialogue>().controller = controller;
        instance.GetComponent<Dialogue>().audioManager = audioManager;
        instance.GetComponent<Dialogue>().isOpen = true;
        instance.GetComponent<Dialogue>().isTalking = isTalking;
    }
    public override void Action()
    {
        Instant();
    }
}
