/*****************************************************************************
// File Name:                  
// Primary Author :            Adam Jensen
*****************************************************************************/

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
            case "Level 2":
                SceneManager.LoadScene("Level 1");
                playerObj.transform.position = new Vector3(-9.4f, 3.1f, -8.42f);
                break;
            case "Level 3":
                SceneManager.LoadScene("Level 2");
                playerObj.transform.position = new Vector3(8.7f, 3.08f, -8.42f);
                break;
            case "Level 4":
                SceneManager.LoadScene("Level 3");
                playerObj.transform.position = new Vector3(23.3f, 4.95f, -8.42f);
                break;
            case "Level 5":
                SceneManager.LoadScene("Level 4");
                playerObj.transform.position = new Vector3(7.6f, 2.1f, -8.42f);
                break;
            case "Level 6":
                SceneManager.LoadScene("Level 5");
                playerObj.transform.position = new Vector3(14f, -4.85f, -8.42f);
                break;
            case "Boss Battle":
                SceneManager.LoadScene("Level 6");
                playerObj.transform.position = new Vector3(22.8f, -6.76f, -8.42f);
                break;
        }
    }
}
