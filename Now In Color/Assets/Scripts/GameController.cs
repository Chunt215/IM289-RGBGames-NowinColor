/*
spawning and platform behaviour stuff 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<GameObject> platforms;
    public bool canExit = false;

    // Start is called before the first frame update
    void Start()
    {
        platforms = new List<GameObject>(GameObject.FindGameObjectsWithTag("Platform"));
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

        for(int i = 0; i < platforms.Count; i++)
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

        return colored;
    }
}
