using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBehavior : MonoBehaviour
{
    public GameObject gcObject;
    private GameController gc;
    private string sceneName;

    void Start()
    {
        gc = gcObject.GetComponent<GameController>();
        sceneName = SceneManager.GetActiveScene().name;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gc.canExit)
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
                    SceneManager.LoadScene("Level 3");
                    playerObj.transform.position = new Vector3(-11.5f, 4.5f, -8.42f);
                    break;
                case "Level 3":
                    SceneManager.LoadScene("Level 4");
                    break;
                case "Level 4":
                    SceneManager.LoadScene("End Game");
                    break;
            }
        }
    }
}
