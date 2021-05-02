/*****************************************************************************
// File Name:                  
// Primary Author :            
// Additional Authors:        Adam Jensen 
//
// Who Completed What 
//(if more than one author): Adam created everything in the Update function
*****************************************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public AudioClip exitSound;
    public List<GameObject> platforms;
    public bool canExit = false;
    public GameObject player;
    public GameObject playerCanvas;
    public Vector3 playerPos = new Vector3(-7.4f, -2.4f, -8.42f);
    public Vector3 canvasPos = new Vector3(1280, 720, 0);

    private string sceneName;
    private bool soundPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        platforms = new List<GameObject>(GameObject.FindGameObjectsWithTag("Platform"));
        sceneName = SceneManager.GetActiveScene().name;
        if(sceneName == "Level 0")
        {
            Instantiate(player, playerPos, Quaternion.identity);
            Instantiate(playerCanvas, canvasPos, Quaternion.identity);
        }
        else if(sceneName == "Level 1")
        {
            Instantiate(player, new Vector3(-10.88f, -2.91f, -8.42f), Quaternion.identity);
            Instantiate(playerCanvas, canvasPos, Quaternion.identity);
        }
        else if (sceneName == "Level 2")
        {
            Instantiate(player, new Vector3(-10.89f, -12.16f, -8.42f), Quaternion.identity);
            Instantiate(playerCanvas, canvasPos, Quaternion.identity);
        }
        else if (sceneName == "Level 3")
        {
            Instantiate(player, new Vector3(-23.41f, -7.91f, -8.42f), Quaternion.identity);
            Instantiate(playerCanvas, canvasPos, Quaternion.identity);
        }
        else if (sceneName == "Level 4")
        {
            Instantiate(player, new Vector3(-9.27f, 4.78f, -8.42f), Quaternion.identity);
            Instantiate(playerCanvas, canvasPos, Quaternion.identity);
        }
        else if (sceneName == "Level 5")
        {
            Instantiate(player, new Vector3(-14.92f, -5.21f, -8.42f), Quaternion.identity);
            Instantiate(playerCanvas, canvasPos, Quaternion.identity);
        }
        else if (sceneName == "Level 6")
        {
            Instantiate(player, new Vector3(-23.21f, -7.29f, -8.42f), Quaternion.identity);
            Instantiate(playerCanvas, canvasPos, Quaternion.identity);
        }
        else if (sceneName == "Boss Battle")
        {
            Instantiate(player, new Vector3(-38.99f, -8.44f, -8.42f), Quaternion.identity);
            Instantiate(playerCanvas, canvasPos, Quaternion.identity);
        }
        else if(sceneName == "Start Screen" || sceneName == "End Game" || sceneName == "Game Over")
        {
            Destroy(GameObject.Find("Player(Clone)"));
            Destroy(GameObject.Find("PlayerCanvas(Clone)"));
        }
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

        if (AllColored())
        {
            if (soundPlayed == false)
            {
                soundPlayed = true;

                Vector3 camPos = Camera.main.transform.position;

                AudioSource.PlayClipAtPoint(exitSound, camPos, 0.4f);
            }
        }
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
                //for (int i = 0; i < platforms.Count; i++)
                //{
                //    SpriteRenderer platformSR = platforms[i].GetComponent<SpriteRenderer>();
                //    if (platformSR.color == Color.white)
                //    {
                //        colored = false;
                //        return colored;
                //    }
                //    else
                //    {
                //        colored = true;
                //    }
                //}
                for (int i = 0; i < platforms.Count; i++)
                {
                    //SpriteRenderer platformSR = platforms[i].GetComponent<SpriteRenderer>();
                    //if (i < 15)
                    //{
                    //    if (platformSR.color != Color.yellow)
                    //    {
                    //        colored = false;
                    //        return colored;
                    //    }
                    //        colored = true;
                    //}
                    //else
                    //{
                    //    if (platformSR.color != Color.green)
                    //    {
                    //        colored = false;
                    //        return colored;
                    //    }
                    //    colored = true;
                    //}
                    colored = platforms[i].GetComponent<PlatformBehaviour>().correctColor;

                    if (colored == false)
                    {
                        return colored;
                    }
                }
                break;
            case "Level 3":
                for (int i = 0; i < platforms.Count; i++)
                {
                    //SpriteRenderer platformSR = platforms[i].GetComponent<SpriteRenderer>();
                    //if (platformSR.color == Color.white)
                    //{
                    //    colored = false;
                    //    return colored;
                    //}
                    //else
                    //{
                    //    colored = true;
                    //}
                    colored = platforms[i].GetComponent<PlatformBehaviour>().correctColor;

                    if (colored == false)
                    {
                        return colored;
                    }
                }
                break;
            case "Level 4":
                for (int i = 0; i < platforms.Count; i++)
                {
                    //SpriteRenderer platformSR = platforms[i].GetComponent<SpriteRenderer>();
                    //if (platformSR.color == Color.white)
                    //{
                    //    colored = false;
                    //    return colored;
                    //}
                    //else
                    //{
                    //    colored = true;
                    //}
                    colored = platforms[i].GetComponent<PlatformBehaviour>().correctColor;

                    if (colored == false)
                    {
                        return colored;
                    }
                }
                break;
            case "Level 5":
                for (int i = 0; i < platforms.Count; i++)
                {
                    //SpriteRenderer platformSR = platforms[i].GetComponent<SpriteRenderer>();
                    //if (platformSR.color == Color.white)
                    //{
                    //    colored = false;
                    //    return colored;
                    //}
                    //else
                    //{
                    //    colored = true;
                    //}
                    colored = platforms[i].GetComponent<PlatformBehaviour>().correctColor;

                    if (colored == false)
                    {
                        return colored;
                    }
                }
                break;
            case "Level 6":
                for (int i = 0; i < platforms.Count; i++)
                {
                    //SpriteRenderer platformSR = platforms[i].GetComponent<SpriteRenderer>();
                    //if (platformSR.color == Color.white)
                    //{
                    //    colored = false;
                    //    return colored;
                    //}
                    //else
                    //{
                    //    colored = true;
                    //}
                    colored = platforms[i].GetComponent<PlatformBehaviour>().correctColor;

                    if (colored == false)
                    {
                        return colored;
                    }
                }
                break;
            case "Boss Battle":
                //for (int i = 0; i < platforms.Count; i++)
                //{
                //    SpriteRenderer platformSR = platforms[i].GetComponent<SpriteRenderer>();
                //    if (platformSR.color == Color.white)
                //    {
                //        colored = false;
                //        return colored;
                //    }
                //    else
                //    {
                //        colored = true;
                //    }
                //}
                if(GameObject.Find("Boss") == null)
                {
                    return true;
                }
                break;
        }

        return colored;
    }
}
