using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : RangedUnit
{
    private float verticalInput = 0;
    private float horizontalInput = 0;
    private SpriteRenderer spriteRenderer;
    private Vector3 mousePos;
    
    private bool shotPressed = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        
        if(verticalInput != 0)
        {
            transform.Translate(0, verticalInput * Time.deltaTime, 0);
        }

        if (horizontalInput != 0)
        {
            transform.Translate(horizontalInput * Time.deltaTime, 0, 0);
        }

        /*
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.right = direction;
        */

        if (shotPressed)
        {
            Vector3 direction = new Vector3(mousePos.x - transform.position.x, mousePos.y - transform.position.y, 2);
            shootProjectile(direction);
            shotPressed = false;
        }
    }

    protected override void shootProjectile(Vector3 direction)
    {
        //Debug.Log("Calling Base -> Shoot");
        base.shootProjectile(direction);
    }
}
