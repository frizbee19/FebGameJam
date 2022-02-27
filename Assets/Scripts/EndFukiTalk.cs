using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFukiTalk : EndTrigger
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
    void Instant()
    {
        instance = Instantiate(TextBox, TextBox.transform.position, Quaternion.identity);
        instance.SetActive(true);
        instance.GetComponent<EndLevelDialogue>().pages = pages;
        instance.GetComponent<EndLevelDialogue>().emotes = emotes;
        instance.GetComponent<EndLevelDialogue>().controller = controller;
        instance.GetComponent<EndLevelDialogue>().audioManager = audioManager;
        instance.GetComponent<EndLevelDialogue>().isOpen = true;
        instance.GetComponent<EndLevelDialogue>().isTalking = isTalking;
    }
    public override void Action()
    {
        Instant();
    }
}
