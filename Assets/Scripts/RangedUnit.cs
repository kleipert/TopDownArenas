using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedUnit : MonoBehaviour
{
    public Rigidbody2D projectile;
    public float cooldown = 1.0f;
    public float health = 1.0f;
    
    float lastShot = 0;
    private float projectileSpeed = 2.0f;
    

    protected virtual void shootProjectileToMouse(Vector3 mousePos)
    {
        Vector3 direction = new Vector3(mousePos.x - transform.position.x, mousePos.y - transform.position.y, 2);

        Debug.Log($"mousePos X: {mousePos.x} transform X: {transform.position.x}");

        if (mousePos.x < transform.position.x && transform.localScale.x > 0)
            return;

        if (mousePos.x > transform.position.x && transform.localScale.x < 0)
            return;

        if(Time.time - lastShot > cooldown)
        {
            lastShot = Time.time;
            //Debug.Log("Ranged-> Shoot");
        
            Vector2 dir = direction.normalized;
            dir.Normalize();
            Rigidbody2D p;


            if (transform.localScale.x > 0)
            {
                p = Instantiate(projectile, new Vector3(transform.position.x + 0.15f, transform.position.y, 2.0f), transform.rotation, this.gameObject.transform);
            }
            else
            {
                p = Instantiate(projectile, new Vector3(transform.position.x - 0.15f, transform.position.y, 2.0f), transform.rotation, this.gameObject.transform);
            }


            p.transform.up = dir;
            p.velocity = new Vector2(dir.x, dir.y) * projectileSpeed;
        }
    }
    private void recieveDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
            death();
    }

    protected virtual void death()
    {
        Destroy(gameObject);
    }
}
