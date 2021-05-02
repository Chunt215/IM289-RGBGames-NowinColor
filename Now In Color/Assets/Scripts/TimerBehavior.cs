/*****************************************************************************
// File Name:                  
// Primary Author :            
// Additional Authors:         
//
// Who Completed What (if more than one author): 
*****************************************************************************/

using UnityEngine;
using UnityEngine.UI;

public class TimerBehavior : MonoBehaviour
{
    public Text timerText;
    private float seconds;
    private int minutes;
    private int hours;

    private void Start()
    {
        seconds = 0;
        minutes = 0;
        hours = 0;
    }

    private void Update()
    {
       timerUpdate();
    }

    public void timerUpdate()
    {
        seconds += Time.deltaTime;

        if (seconds > 60)
        {
            minutes++;
            seconds = 0;

            if(minutes > 60)
            {
                hours++;
                minutes = 0;
            }
        }


        timerText.text = hours + ":" + minutes + ":" + (int)seconds;
    }
}
