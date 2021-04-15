using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (FindObjectsOfType<DontDestroy>().Length > 2)
        {
            Destroy(gameObject);
        }
    }
}
