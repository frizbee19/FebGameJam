using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public string firstLevel;
    public GameObject optionsScreen;
    public GameObject creditsScreen;
    public GameObject binderRing;
    public int currentLevel = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        if (!PlayerPrefs.HasKey("CurrentLevel"))
        {
            PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        }
        SceneManager.LoadScene("Real World");
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
        binderRing.SetActive(false);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
        binderRing.SetActive(true);
    }

    public void OpenCredits()
    {
        creditsScreen.SetActive(true);
        binderRing.SetActive(false);
    }

    public void CloseCredits()
    {  
        creditsScreen.SetActive(false);
        binderRing.SetActive(true);
    }

    public void ResetLevel()
    {
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
