using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button[] lvlButtons;

    private void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 3);

        for(int i = 0; i < lvlButtons.Length; i++)
        {
            if(i + 1 > levelAt)
            {
                lvlButtons[i].interactable = false;
            }
        }
    }

}
