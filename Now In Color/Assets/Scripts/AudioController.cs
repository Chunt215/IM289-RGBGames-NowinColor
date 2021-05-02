/*****************************************************************************
// File Name:                  
// Primary Author :            Adam Jensen
*****************************************************************************/
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private void Awake()
    {
        if(FindObjectsOfType<AudioController>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
