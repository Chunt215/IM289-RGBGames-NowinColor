/*
spawning and platform behaviour stuff 
*/
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public List<GameObject> platforms;
    public bool canExit = false;
    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        platforms = new List<GameObject>(GameObject.FindGameObjectsWithTag("Platform"));
        sceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKey(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        canExit = AllColored();
    }

    public bool AllColored()
    {
        bool colored = false;

        switch (sceneName)
        {
            case "Level 0":
                for (int i = 0; i < platforms.Count; i++)
                {
                    SpriteRenderer platformSR = platforms[i].GetComponent<SpriteRenderer>();
                    if (platformSR.color == Color.white)
                    {
                        colored = false;
                        return colored;
                    }
                    else
                    {
                        colored = true;
                    }
                }
                break;
            case "Level 1":
                for (int i = 0; i < platforms.Count; i++)
                {
                    SpriteRenderer platformSR = platforms[i].GetComponent<SpriteRenderer>();
                    if (platformSR.color == Color.white)
                    {
                        colored = false;
                        return colored;
                    }
                    else
                    {
                        colored = true;
                    }
                }
                break;
            case "Level 2":
                for (int i = 0; i < platforms.Count; i++)
                {
                    SpriteRenderer platformSR = platforms[i].GetComponent<SpriteRenderer>();
                    if (platformSR.color == Color.white)
                    {
                        colored = false;
                        return colored;
                    }
                    else
                    {
                        colored = true;
                    }
                }
                break;
            case "Level 4":
                for (int i = 0; i < platforms.Count; i++)
                {
                    SpriteRenderer platformSR = platforms[i].GetComponent<SpriteRenderer>();
                    if (platformSR.color == Color.white)
                    {
                        colored = false;
                        return colored;
                    }
                    else
                    {
                        colored = true;
                    }
                }
                break;
        }

        return colored;
    }
}
