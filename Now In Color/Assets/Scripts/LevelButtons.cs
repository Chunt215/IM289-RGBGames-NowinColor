using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelButtons : MonoBehaviour
{

    public void load0()
    {
        SceneManager.LoadScene("Level 0");
    }
    public void load1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void load2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void load3()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void load4()
    {
        SceneManager.LoadScene("Level 4");
    }
    public void load5()
    {
        SceneManager.LoadScene("Level 5");
    }
    public void load6()
    {
        SceneManager.LoadScene("Level 6");
    }
    public void loadBoss()
    {
        SceneManager.LoadScene("Boss Battle");
    }

}

