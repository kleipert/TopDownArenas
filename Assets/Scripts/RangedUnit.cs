using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedUnit : MonoBehaviour
{
    public Rigidbody2D projectile;
    public float cooldown = 0.5f;

    private SpriteRenderer sprite;

    protected virtual void shootProjectile(Vector3 direction)
    {
        //Debug.Log("Ranged-> Shoot");
        
        Vector2 dir = direction.normalized;
        dir.Normalize();
        Rigidbody2D p = Instantiate(projectile, new Vector3(transform.position.x + 0.15f, transform.position.y, 2.0f), transform.rotation);
        p.transform.up = dir;
        p.velocity = new Vector2(dir.x, dir.y);
    }
}
