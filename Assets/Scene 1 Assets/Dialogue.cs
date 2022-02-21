using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TMP_Text textbox;
    ArrayList<string> pages;
    int curPage;
    // Start is called before the first frame update
    void Start()
    {
        //pages to scroll through
        pages = new ArrayList<string>();
    }

    //Adds a page of text
    void AddText(string text) 
    {
        pages.Add(text);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
