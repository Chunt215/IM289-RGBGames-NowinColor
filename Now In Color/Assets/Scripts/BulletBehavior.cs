using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
