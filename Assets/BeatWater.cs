using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeatWater : MonoBehaviour
   {
    public int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            BeatLevel();
        }
    }*/

    void BeatLevel()
    {

        if (currentLevel == 4)
        {
            PlayerPrefs.SetInt("CurrentLevel", 5);
            SceneManager.LoadScene("Real World");
        }
        else
        {
            SceneManager.LoadScene("Real World");
        }
    }
}
