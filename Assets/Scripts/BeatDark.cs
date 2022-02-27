using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeatDark : MonoBehaviour
{
    public int currentLevel;
    public int i = 2;
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
    }

    public void BeatLevel()
    {

        if (i == currentLevel && i <= 6)
        {
            PlayerPrefs.SetInt("CurrentLevel", i + 1);
            SceneManager.LoadScene("Real World");
            Debug.Log(i);
        }
        else
        {
            SceneManager.LoadScene("Real World");
        }
    }
}
