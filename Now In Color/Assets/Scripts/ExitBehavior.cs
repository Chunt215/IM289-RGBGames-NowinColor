using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBehavior : MonoBehaviour
{
    public GameObject gcObject;
    private GameController gc;
    public int currentLevel;

    void Start()
    {
        gc = gcObject.GetComponent<GameController>();
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
            SceneManager.LoadScene("Level 4 Temp");
        }
    }
}
