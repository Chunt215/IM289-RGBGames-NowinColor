using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBehavior : MonoBehaviour
{
    public GameObject gcObject;
    private GameController gc;
    private GameObject playerObj;
    private PlayerBehaviour player;
    private string sceneName;

    void Start()
    {
        gc = gcObject.GetComponent<GameController>();
        sceneName = SceneManager.GetActiveScene().name;
        playerObj = GameObject.Find("Player(Clone)");
        player = playerObj.GetComponent<PlayerBehaviour>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
                    SceneManager.LoadScene("Level 4");
                    playerObj.transform.position = new Vector3(-10.8f, 4.6f, -8.42f);
                    /* playerObj.transform.position = new Vector3(-15.1f, -5.2f, -8.42f);*/
                    break;
               /* case "Level 3":
                    SceneManager.LoadScene("Level 4");
                    playerObj.transform.position = new Vector3(-10.8f, 4.6f, -8.42f);
                    break;*/
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
                    break;
            }
        }
    }
}

