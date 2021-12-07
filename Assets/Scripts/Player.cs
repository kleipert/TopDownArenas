using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : RangedUnit
{
    private float verticalInput = 0;
    private float horizontalInput = 0;
    private SpriteRenderer spriteRenderer;
    private Vector3 mousePos;
    private BoxCollider2D collider;
    private RaycastHit2D hitMoving;
    
    private bool shotPressed = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        health = maxHealth;
    }
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        mousePos = Input.mousePosition;
        mousePos.z = 2.0f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (Input.GetButtonDown("Jump"))
            shotPressed = true;
    }

    private void FixedUpdate()
    {

        if (mousePos.x > transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);


        if (verticalInput != 0)
        {
            hitMoving = Physics2D.BoxCast(transform.position, collider.size, 0, new Vector2(verticalInput, 0), Mathf.Abs(verticalInput * Time.deltaTime), LayerMask.GetMask("Blocking", "Actor"));
            if (hitMoving.collider == null)
            {
                transform.Translate(0, verticalInput * Time.deltaTime, 0);
            }
            else
                Debug.Log(collider.name);
        }

        if (horizontalInput != 0)
        {
            hitMoving = Physics2D.BoxCast(transform.position, collider.size, 0, new Vector2(0, horizontalInput), Mathf.Abs(horizontalInput * Time.deltaTime), LayerMask.GetMask("Blocking", "Actor"));
            if(hitMoving.collider == null)
            {
                transform.Translate(horizontalInput * Time.deltaTime, 0, 0);
            }
            else
                Debug.Log(collider.name);
        }

        if (shotPressed)
        {
            shootProjectileToMouse(mousePos);
            shotPressed = false;
        }
    }

    protected override void shootProjectileToMouse(Vector3 mousePos)
    {
        //Debug.Log("Calling Base -> Shoot");
        base.shootProjectileToMouse(mousePos);
    }
}
