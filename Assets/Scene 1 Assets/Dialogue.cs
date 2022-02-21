using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TMP_Text textbox;
    List<string> pages;
    int curPage;
    public bool isOpen = true;
    //test object
    public GameObject textTest;
    // Start is called before the first frame update
    void Start()
    {
        //pages to scroll through
        pages = new List<string>();
        curPage = 0;
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
            // if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0 || Input.GetKeyDown(KeyCode.Return))
            // {
            //     //scroll through textbox using any movement key
            //     if(curPage >= pages.Count - 1) 
            //     {
            //         isOpen = false;
            //     }
            //     else
            //     {
            //         textbox.text = pages[++curPage];
            //     }
            // }
        }
        //unpause
        else 
        {
            Movement.pause = false;
        }
    }
}
