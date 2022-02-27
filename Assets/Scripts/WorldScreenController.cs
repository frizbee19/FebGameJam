using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldScreenController : MonoBehaviour
{
    public int currentLevel;
    public GameObject openingDialogue, tutorialDialogue, speedDialogue, darkDialogue, waterDialogue, birdDialogue, crowdDialogue, epilogueDialogue;
    public GameObject page1;
    public GameObject page2;
    public GameObject trophy1, trophy2, trophy3, trophy4, trophy5, trophy6;
    public GameObject picture1, picture2, picture3, picture4, picture5, picture6;
    public GameObject fpicture1, fpicture2, fpicture3, fpicture4, fpicture5, fpicture6;


    // Start is called before the first frame update
    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        if (currentLevel == 1)
        {
            openingDialogue.SetActive(true);
        }
        if (currentLevel >= 2)
        {
            trophy1.SetActive(true);
        }
        if (currentLevel >= 3)
        {
            trophy2.SetActive(true);
        }
        if (currentLevel >= 4)
        {
            trophy3.SetActive(true);
        }
        if (currentLevel >= 5)
        {
            trophy4.SetActive(true);
        }
        if (currentLevel >= 6)
        {
            trophy5.SetActive(true);
        }
        if (currentLevel >= 7)
        {
            trophy6.SetActive(true);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Level1()
    {
        if (currentLevel >= 1)
        {
            SceneManager.LoadScene("Heights Level");
        }
    }

    public void Level2()
    {
        if (currentLevel >= 2)
        {
            SceneManager.LoadScene("Speed Level");
        }
    }

    public void Level3()
    {
        if (currentLevel >= 3)
        {
            SceneManager.LoadScene("Dark Level");
        }
    }

    public void Level4()
    {
        if (currentLevel >= 4)
        {
            SceneManager.LoadScene("Water Level");
        }
    }

    public void Level5()
    {
        if (currentLevel >= 5)
        {
            SceneManager.LoadScene("Bird Level");
        }
    }

    public void Level6()
    {
        if (currentLevel >= 6)
        {
            SceneManager.LoadScene("Crowds Level");
        }
    }

    public void NextPage()
    {
        page2.SetActive(true);
        page1.SetActive(false);
    }

    public void PreviousPage()
    {
        page1.SetActive(true);
        page2.SetActive(false);
    }
    
    public void ClosePage()
    {
        page2.SetActive(false);
        page1.SetActive(false);
    }

    public void OpenBook()
    {
        if (currentLevel == 1)
        {
            picture1.SetActive(true);
            tutorialDialogue.SetActive(true);
        }
        if (currentLevel == 2)
        {
            fpicture1.SetActive(true);
            picture2.SetActive(true);
            speedDialogue.SetActive(true);
        }
        if (currentLevel == 3)
        {
            fpicture1.SetActive(true);
            fpicture2.SetActive(true);
            picture3.SetActive(true);
            darkDialogue.SetActive(true);
        }
        if (currentLevel == 4)
        {
            fpicture1.SetActive(true);
            fpicture2.SetActive(true);
            fpicture3.SetActive(true);
            picture4.SetActive(true);
            waterDialogue.SetActive(true);
        }
        if (currentLevel == 5)
        {
            fpicture1.SetActive(true);
            fpicture2.SetActive(true);
            fpicture3.SetActive(true);
            fpicture4.SetActive(true);
            picture5.SetActive(true);
            birdDialogue.SetActive(true);
        }
        if (currentLevel == 6)
        {
            fpicture1.SetActive(true);
            fpicture2.SetActive(true);
            fpicture3.SetActive(true);
            fpicture4.SetActive(true);
            fpicture5.SetActive(true);
            picture6.SetActive(true);
            crowdDialogue.SetActive(true);
        }
        if (currentLevel == 7)
        {
            fpicture1.SetActive(true);
            fpicture2.SetActive(true);
            fpicture3.SetActive(true);
            fpicture4.SetActive(true);
            fpicture5.SetActive(true);
            fpicture6.SetActive(true);
            epilogueDialogue.SetActive(true);
        }
        page1.SetActive(true);       
    }
}
