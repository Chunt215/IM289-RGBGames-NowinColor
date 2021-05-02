/*****************************************************************************
// File Name:                  
// Primary Author :            Adam Jensen
*****************************************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseUI;
    public GameObject helpScreen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void PauseGame()
    {
        pauseUI.SetActive(true);
        // Freeze the game
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Screen");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level 0");
    }

    public void LoadHelp()
    {
        pauseUI.SetActive(false);
        helpScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadBack()
    {
        helpScreen.SetActive(false);
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
