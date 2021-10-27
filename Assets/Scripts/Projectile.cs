using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy Object if it collides with Collideable Layer
        if (collision.gameObject.layer == 7)
            Destroy(gameObject);
    }
}
