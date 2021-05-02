/*****************************************************************************
// File Name:                  
// Primary Author :            
// Additional Authors:         
//
// Who Completed What (if more than one author): 
*****************************************************************************/
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    private SpriteRenderer sr;
    public Color goalColor;
    private Color curColor;
    public bool correctColor;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        curColor = sr.color;

        if(curColor == goalColor)
        {
            correctColor = true;
        }
        else
        {
            correctColor = false;
        }
    }
}
