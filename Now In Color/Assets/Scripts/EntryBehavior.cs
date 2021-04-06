using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryBehavior : MonoBehaviour
{
    private GameObject playerObj;

    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player(Clone)");
        sceneName = SceneManager.GetActiveScene().name;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (sceneName)
        {
            case "Level 1":
                SceneManager.LoadScene("Level 0");
                playerObj.transform.position = new Vector3(7.1f, -2.2f, -8.42f);
                break;
        }
    }
}
