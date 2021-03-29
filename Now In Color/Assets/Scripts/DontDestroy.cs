using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private Scene scene;

    private GameObject playerObj;
    private GameObject playerUI;

    void Start()
    {
        scene = SceneManager.GetActiveScene();

        playerObj = GameObject.Find("Player");
        playerUI = GameObject.Find("PlayerUI");
    }

    private void Awake()
    {
        if (scene.name == "Start Screen")
        {
            Destroy(playerObj);
            Destroy(playerUI);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
