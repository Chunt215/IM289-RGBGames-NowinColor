using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    private void OnMouseDown()
    {
        switch (gameObject.tag)
        {
            case "Level 0":
                SceneManager.LoadScene("Level 0");
                break;
            case "Level 1":
                SceneManager.LoadScene("Level 1");
                break;
            case "Level 2":
                SceneManager.LoadScene("Level 2");
                break;
            case "Level 3":
                SceneManager.LoadScene("Level 3");
                break;
            case "Level 4":
                SceneManager.LoadScene("Level 4");
                break;
            case "Level 5":
                SceneManager.LoadScene("Level 5");
                break;
            case "Level 6":
                SceneManager.LoadScene("Level 6");
                break;
            case "Boss":
                SceneManager.LoadScene("Boss Battle");
                break;

        }
    }
}
