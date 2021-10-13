using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float verticalInput = 0;
    private float horizontalInput = 0;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
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
    }
}
