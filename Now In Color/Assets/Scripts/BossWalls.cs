/*****************************************************************************
// File Name:                  
// Primary Author :            
// Additional Authors:         
//
// Who Completed What (if more than one author): 
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalls : MonoBehaviour
{
    public int disableTime = 5;

    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            collision.gameObject.SetActive(false);
            yield return new WaitForSeconds(disableTime);
            collision.gameObject.SetActive(true);
        }
    }
}
