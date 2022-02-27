using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndLevelDialogue : MonoBehaviour
{
    public Animator animator;
    public Animator animatorb;
    public Animator animatorc;
    public RuntimeAnimatorController controller;
    public TMP_Text textbox;
    public TMP_Text arrow;
    public AudioManager audioManager;
    public List<string> pages = new List<string>();
    public List<int> emotes = new List<int>();
    public int curPage = 0;
    public bool isOpen = false;
    public bool isDream = false;
    [Range(1, 10)] public int first = 3;
    [Range(2, 20)] public int second = 4;
    [Range(1, 50)] public int last = 5;
    public GameObject lvlEnder;
    public GameObject headshotb;
    public GameObject headshotc;

    public Camera mainCam;
    public Camera secondCam;
    public Camera lastCam;
    public int current_cam = 0;
    public GameObject byebye, backupbyebye, nickelback;

    //used to activate/deactivate test object
    //activate through outside means probably
    public GameObject textTest;
    //used to print the first x letters of the text
    int cCount = 0;
    //changes the pace at which chars appear
    //in seconds
    float pace = 0.05f;
    float elapsed = 0f;
    //turns off and on sound
    public bool isTalking;
    // Start is called before the first frame update
    void Start()
    {
        if (pages.Count > 0)
        {
            arrow.text = "";
        }
        animator.runtimeAnimatorController = controller;
        animatorb.runtimeAnimatorController = controller;
        animatorc.runtimeAnimatorController = controller;
    }

    //Adds a page of text
    void AddPage(string text)
    {
        pages.Add(text);
    }
    // Update is called once per frame
    void Update()
    {
        //only pauses if opened
        if (isOpen)
        {
            //pause
            Movement.pause = true;
            //checks if all of the characters are on the page
            if (cCount >= pages[curPage].Length)
            {
                //stops the animation
                if (animator != null && emotes.Count == pages.Count)
                {
                    animator.SetInteger("Animation", emotes[curPage] - 1);
                }
                if (animatorb != null && emotes.Count == pages.Count)
                {
                    animatorb.SetInteger("Animation", emotes[curPage] - 1);
                }
                if (animatorc != null && emotes.Count == pages.Count)
                {
                    animatorc.SetInteger("Animation", emotes[curPage] - 1);
                }
                //prints the "next" arrow when at end of page except last page
                if (curPage < pages.Count - 1)
                {
                    arrow.text = ">";
                }
                else
                {
                    arrow.text = "x";
                }
                elapsed = 0;
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.DownArrow) ||
                Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
                {
                    //scroll through textbox using any movement key
                    if (curPage+1 == first || curPage+1 == second || curPage+1 == last)
                    {
                        current_cam++;
                    }
                    if (curPage >= pages.Count - 1)
                    {
                        //exits the textbox
                        isOpen = false;
                        Movement.pause = false;
                        Destroy(textTest);
                        cCount = 0;
                        curPage = 0;
                    }
                    else
                    {
                        //resets pace of chars
                        arrow.text = "";
                        ++curPage;
                        cCount = 0;
                    }

                }
            }
            else
            {
                //starts the animation
                if (animator != null && emotes.Count == pages.Count)
                {
                    animator.SetInteger("Animation", emotes[curPage]);
                }
                if (animatorb != null && emotes.Count == pages.Count)
                {
                    animatorb.SetInteger("Animation", emotes[curPage]);
                }
                if (animatorc != null && emotes.Count == pages.Count)
                {
                    animatorc.SetInteger("Animation", emotes[curPage]);
                }
                //writes chars at specified pace
                elapsed += Time.deltaTime;
                if (elapsed > pace)
                {
                    ++cCount;
                    textbox.text = pages[curPage].Substring(0, cCount);
                    elapsed = 0;
                    if (isTalking)
                    {
                        int RNGSound = Random.Range(0, 2);
                        if (isDream == true)
                        {
                            if (RNGSound == 0)
                            {
                                audioManager.Play("dreamblip");

                            }
                            else
                            {
                                audioManager.Play("dreamblop");

                            }
                        }
                        else
                        {
                            if (RNGSound == 0)
                            {
                                audioManager.Play("blip");
                                Debug.Log("blip");
                            }
                            else
                            {
                                audioManager.Play("blop");
                                Debug.Log("blop");
                            }
                        }
                    }
                }
                //skip ahead
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.DownArrow) ||
                Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
                {
                    cCount = pages[curPage].Length;
                    textbox.text = pages[curPage];
                }

            }
        }
        //unpause
        else
        {
            Movement.pause = false;
        }
        switch (current_cam)
        {
            //staticCam.enabled = true;
            default: return;
            case (1): mainCam.enabled = false;
                secondCam.enabled = true;
                byebye.SetActive(false);
                backupbyebye.SetActive(false);
                headshotb.SetActive(true);

                break;
            case (2):
                secondCam.enabled = false;
                lastCam.enabled = true;
                nickelback.SetActive(true);
                headshotb.SetActive(false);
                headshotc.SetActive(true);
                break;
            case (3):
                Debug.Log("Gay Sex");
                lvlEnder.GetComponent<BeatDark>().BeatLevel();
                break;
        }
    }
}