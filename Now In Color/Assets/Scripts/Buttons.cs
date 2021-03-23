using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private void OnMouseDown()
    {
        switch (gameObject.tag)
        {
            case "Start":
                Invoke("StartGame", 0.25f);
                break;
            case "Help":
                Invoke("LoadHelp", 0.25f);
                break;
            case "Menu":
                Invoke("LoadMenu", 0.25f);
                break;
            case "Credits":
                Invoke("LoadCredits", 0.25f);
                break;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 0");
    }

    public void LoadHelp()
    {
        SceneManager.LoadScene("Help");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}