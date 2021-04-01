using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private Scene scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

     /*   if (scene.buildIndex == 0)
        {
            Destroy(this.gameObject);
        }
        else
        {

        }*/


        if (FindObjectsOfType<DontDestroy>().Length > 2)
        {
            Destroy(gameObject);
        }
    }
}
