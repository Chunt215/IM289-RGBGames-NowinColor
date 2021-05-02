/*****************************************************************************
// File Name:                  
// Primary Author :            
// Additional Authors:         
//
// Who Completed What (if more than one author): 
*****************************************************************************/

using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
