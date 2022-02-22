using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TMP_Text textbox;
    public TMP_Text arrow;
    public List<string> pages = new List<string>();
    int curPage = 0;
    public bool isOpen = true;
    //used to activate/deactivate test object
    //activate through outside means probably
    public GameObject textTest;
    //used to print the first x letters of the text
    int cCount = 0;
    //changes the pace at which chars appear
    //in seconds
    float pace = 0.05f;
    float elapsed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if(pages.Count > 0) 
        {
            textbox.text = pages[0];
            arrow.text = "";
        }
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
        if(isOpen) 
        {
            //pause
            Movement.pause = true;
            //checks if all of the characters are on the page
            if(cCount >= pages[curPage].Length) 
            {
                //prints the "next" arrow when at end of page except last page
                if(curPage < pages.Count - 1) 
                {
                    arrow.text = ">";
                }
                else
                {
                    arrow.text = "x";
                }
                elapsed = 0;
                if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.DownArrow) ||
                Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
                {
                    //scroll through textbox using any movement key
                    if(curPage >= pages.Count - 1) 
                    {
                        //exits the textbox
                        isOpen = false;
                        Movement.pause = false;
                        textTest.SetActive(false);
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
                //writes chars at specified pace
                elapsed += Time.deltaTime;
                if(elapsed > pace) 
                {
                    ++cCount;
                    textbox.text = pages[curPage].Substring(0, cCount);
                    elapsed = 0;
                }
                //skip ahead
                if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.DownArrow) ||
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
    }
}