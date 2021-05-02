/*****************************************************************************
// File Name:                  
// Primary Author :            Adam Jensen
*****************************************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private string scene;

    private void Start()
    {
        scene = SceneManager.GetActiveScene().name;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (FindObjectsOfType<DontDestroy>().Length > 2 
            || scene == "Game Over")
        {
            Destroy(gameObject);
        }
    }
}
