using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 1;

    private bool targetHit = false;
    private Collision2D col;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (targetHit)
        {
            // Destroy Object if it collides with Collideable Layer
            if (col.gameObject.layer == 7)
                Destroy(gameObject);

            // Collision on Actor Layer
            if (col.gameObject.layer == 6)
            {
                col.collider.SendMessage("recieveDamage", damage);
                Debug.Log($"Projectile hit! --> {col.gameObject.name}");
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!targetHit && collision.gameObject.name != this.gameObject.transform.parent.name)
        {
            Destroy(GetComponent("BoxCollider2D")); 
            this.col = collision;
            targetHit = true;
            Debug.Log($"Target Hit! --> {collision.gameObject.name}");
        }
    }
}
