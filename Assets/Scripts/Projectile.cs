using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy Object if it collides with Collideable Layer
        if (collision.gameObject.layer == 7)
            Destroy(gameObject);

        // Collision on Actor Layer
        if(collision.gameObject.layer == 6 && collision.gameObject.tag == "Enemy")
        {
            collision.collider.SendMessage("recieveDamage", damage);
            Debug.Log($"Projectile hit! --> {collision.gameObject.name}");
            Destroy(gameObject);
        }
    }
}
