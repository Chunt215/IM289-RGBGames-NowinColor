using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBehavior : MonoBehaviour
{
    public GameObject gcObject;
    private GameController gc;
<<<<<<< Updated upstream
    public int currentLevel;
=======
    private string sceneName;
>>>>>>> Stashed changes

    void Start()
    {
        gc = gcObject.GetComponent<GameController>();
        sceneName = SceneManager.GetActiveScene().name;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gc.canExit && currentLevel == 0)
        {
            SceneManager.LoadScene("Level 1");
        }
        else if(gc.canExit && currentLevel == 1)
        {
            SceneManager.LoadScene("Level 2");
        }
        else if (gc.canExit && currentLevel == 2)
        {
            switch(sceneName)
            {
                case "Level 0":
                    SceneManager.LoadScene("Level 1");
                    break;
                case "Level 1":
                    SceneManager.LoadScene("Level 2");
                    break;
                case "Level 2":
                    SceneManager.LoadScene("Level 4 Temp");
                    break;
            }
        }
    }
}
