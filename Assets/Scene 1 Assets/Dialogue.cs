using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TMP_Text textbox;
    public List<string> pages = new List<string>();
    int curPage = 0;
    public bool isOpen = true;
    //used to activate/deactivate test object
    //activate through outside means probably
    public GameObject textTest;
    //used to print the first x letters of the text
    int cCount = 0;
    //changes the pace at which chars appear
    float pace = 10.0f;
    float elapsed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if(pages.Count > 0) 
        {
            textbox.text = pages[0];
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
                elapsed = 0;
                if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.DownArrow) ||
                Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
                {
                    //scroll through textbox using any movement key
                    if(curPage >= pages.Count - 1) 
                    {
                        isOpen = false;
                        Movement.pause = false;
                        textTest.SetActive(false);
                    }
                    else
                    {
                        ++curPage;
                        cCount = 0;
                    }
                }
            }
            else
            {
                elapsed += Time.deltaTime;
                if(elapsed % pace == 0) 
                {
                    textbox.text = pages[curPage].Substring(0, ++cCount);
                }
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
