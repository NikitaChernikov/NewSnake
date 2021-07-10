using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject menu;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        if (GameIsPaused)
        {
            Resume();
        } else
        {
            PauseIt();
        }
    }

    void Resume()
    {
        FindObjectOfType<AudioManager>().Play("PauseOut");
        menu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void PauseIt()
    {
        FindObjectOfType<AudioManager>().Play("PauseIn");
        menu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
