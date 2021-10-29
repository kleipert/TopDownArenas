using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingUnits : MonoBehaviour
{
    protected BoxCollider2D movingBodyCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;

    protected virtual void Start()
    {
        this.movingBodyCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void updateMotor(Vector3 input, float movementSpeed)
    {
        // Reset moveDelta
        moveDelta = new Vector3(input.x * movementSpeed, input.y * movementSpeed, 0);

        // Swap sprite direction wether its going right or left
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // Check if we can move on Y Axis
        hit = Physics2D.BoxCast(transform.position, movingBodyCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Blocking", "Actor"));
        if (hit.collider == null)
        {
            // Move Character
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }


        // Check if we can move on X Axis
        hit = Physics2D.BoxCast(transform.position, movingBodyCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Blocking", "Actor"));
        if (hit.collider == null)
        {
            // Move Character
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
