using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldScreenController : MonoBehaviour
{
    public int currentLevel;
    public GameObject Fuki;

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
}
