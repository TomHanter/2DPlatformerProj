using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    private Vector3 direction;


    private void Start()
    {
        direction = transform.right;
    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * direction.x * 0.7f, 0.1f);

        if (colliders.Length > 0) direction *= -1f;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime);
    }
    private void Update()
    {
        Move();
    }
}
