using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUnit : MovingUnits
{
    // Melee Enemy Parameters
    public int xpWorth = 1;
    public float aggroRadius = 0.5f;
    public float health = 1.0f;
    public float walkingSpeed = 2.0f;
    public float damagePerHit = 1.0f;

    protected bool isChasing = false;
    protected bool connectingToHero = false;
    protected Transform heroPosition;
    protected Vector3 startPosition;

    private Animator animator;

    // Hitbox
    public ContactFilter2D filter;
    private Collider2D[] hits = new Collider2D[10];

    
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

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        startPosition = transform.position;
        heroPosition = GameManager.instance.hero.transform;
    }

    private void lookForHero()
    {
        Vector3 transformScreenSpace = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 heroScreenSpace = Camera.main.WorldToScreenPoint(heroPosition.position);
        
        
        float dist = Vector3.Distance(transformScreenSpace, heroScreenSpace);
        // Check if hero is in range
        //Debug.Log($"MeleeUnit::lookForHero: Distance = {dist} Range = {aggroRadius}");
        if (dist > aggroRadius)
        {
            return;
        }
        else
        {
            Debug.Log("Found Hero!");
            isChasing = true;
            animator.SetBool("isWalking", true);
            
        }
    }

    protected virtual void FixedUpdate()
    {
        // look for player
        if (!isChasing)
        {
            lookForHero();
            return;
        }

        if (isChasing && !connectingToHero)
        {
            // chase player
            updateMotor((heroPosition.position - transform.position).normalized, walkingSpeed);
            animator.SetBool("isWalking", true);
            //Debug.Log("Chasing Hero!");
            //Debug.Log(animator.GetBool("isWalking"));
        }

        // Check for Collision Overlap
        connectingToHero = false;
        movingBodyCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            if (hits[i].tag == "Hero" && hits[i].name == "Player")
            {
                animator.SetBool("isWalking", false);
                //Debug.Log(animator.GetBool("isWalking"));
                connectingToHero = true;
            }

            // clean array
            hits[i] = null;
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Hero")
        {
            collision.collider.SendMessage("recieveDamage", damagePerHit);
        }
    }
}
