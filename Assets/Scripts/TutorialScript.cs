using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : Trigger
{
    public GameObject tutorialText;
    public int currentLevel;

    public void Start() {
      currentLevel = PlayerPrefs.GetInt("CurrentLevel");
    }
    

    public override void Action()
    {
        if(currentLevel == 1){
            tutorialText.SetActive(true);
        }
    }
}
