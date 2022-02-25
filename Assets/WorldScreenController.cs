using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldScreenController : MonoBehaviour
{
    public int currentLevel;
    public GameObject Fuki;
    public GameObject page1;
    public GameObject page2;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        if (currentLevel >= 2)
        {
            Fuki.SetActive(true);
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
            SceneManager.LoadScene("Crowds Level");
        }
    }

    public void Level2()
    {
        if (currentLevel >= 2)
        {
            SceneManager.LoadScene("Crowds Level");
        }
    }

    public void Level3()
    {
        if (currentLevel >= 3)
        {
            SceneManager.LoadScene("Crowds Level");
        }
    }

    public void Level4()
    {
        if (currentLevel >= 4)
        {
            SceneManager.LoadScene("Crowds Level");
        }
    }

    public void Level5()
    {
        if (currentLevel >= 5)
        {
            SceneManager.LoadScene("Crowds Level");
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
        page1.SetActive(true);
    }
}
