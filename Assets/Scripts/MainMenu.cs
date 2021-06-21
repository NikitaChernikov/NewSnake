using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayLevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void PlayLevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void PlayLevelThree()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackToTheMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
