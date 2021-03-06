/*****************************************************************************
// File Name:                  
// Primary Author :            
// Additional Authors:         
//
// Who Completed What (if more than one author): 
*****************************************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBehavior : MonoBehaviour
{
    public GameObject gcObject;
    private GameController gc;
    private GameObject playerObj;
    private GameObject playerUI;
    private PlayerBehaviour player;
    private string sceneName;

    public int nextScene;

    void Start()
    {
        gc = gcObject.GetComponent<GameController>();
        sceneName = SceneManager.GetActiveScene().name;
        playerObj = GameObject.Find("Player(Clone)");
       /* playerUI = GameObject.Find("PlayerCanvas(Clone)");*/
        player = playerObj.GetComponent<PlayerBehaviour>();

        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gc.canExit)
            {
                player.sr.color = Color.white;
                player.jumpForce = 300f;
                player.speed = 5.0f;
                player.canKill = false;
                switch (sceneName)
                {
                    case "Level 0":
                        SceneManager.LoadScene("Level 1");
                        playerObj.transform.position = new Vector3(-11.5f, -2.85f, -8.42f);
                        break;
                    case "Level 1":
                        SceneManager.LoadScene("Level 2");
                        playerObj.transform.position = new Vector3(-12.08f, -12.38f, -8.42f);
                        break;
                    case "Level 2":
                        SceneManager.LoadScene("Level 3");
                        playerObj.transform.position = new Vector3(-23.41f, -7.91f, -8.42f);
                        break;
                    case "Level 3":
                        SceneManager.LoadScene("Level 4");
                        playerObj.transform.position = new Vector3(-10.8f, 4.6f, -8.42f);
                        break;
                    case "Level 4":
                        SceneManager.LoadScene("Level 5");
                        playerObj.transform.position = new Vector3(-15.81f, -5.01f, -8.42f);
                        break;
                    case "Level 5":
                        SceneManager.LoadScene("Level 6");
                        playerObj.transform.position = new Vector3(-23.79f, -7.11f, -8.42f);
                        break;
                    case "Level 6":
                        SceneManager.LoadScene("Boss Battle");
                        playerObj.transform.position = new Vector3(-39.94f, -8.03f, -8.42f);
                        break;
                    case "Boss Battle":
                        SceneManager.LoadScene("End Game");
                        Destroy(playerObj);
                        /*Destroy(playerUI);*/
                        break;
                }
            }

            if (nextScene > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextScene);
            }
        }
    }
}

