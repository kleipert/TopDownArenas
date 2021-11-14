using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 1;

    private bool targetHit = false;
    private GameObject gameobjectHit;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (targetHit)
        {
            // Destroy Object if it collides with Collideable Layer
            if (this.gameobjectHit.layer == 7)
                Destroy(gameObject);

            // Collision on Actor Layer
            if (this.gameobjectHit.layer == 6)
            {
                this.gameobjectHit.GetComponent("BoxCollider2D").SendMessage("recieveDamage", damage);
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!targetHit && collision.gameObject.name != this.gameObject.transform.parent.name)
        {
            Destroy(GetComponent("BoxCollider2D")); 
            this.gameobjectHit = collision.gameObject;
            targetHit = true;
            Debug.Log($"Hit! --> {this.gameobjectHit.name}");
        }
    }
}
