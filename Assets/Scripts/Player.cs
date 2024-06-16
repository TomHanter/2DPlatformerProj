using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player: MonoBehaviour
{

    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int health;
    public int life = 5;
    private bool isGrounded = false;

    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite aliveHeart;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    public static Player Instance { get; set; }

    private void Awake()
    {
        life = 5;
        health = life;

        rb = GetComponent<Rigidbody2D>();
        sprite = rb.GetComponentInChildren<SpriteRenderer>();
        Instance = this;
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    void Update()
    {
        if (Input.GetButton("Horizontal"))
            Walk();
        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();

        if (health > life)
            health = life;

        for(int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].sprite = aliveHeart;

            if (i < life)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }

        if (life == 0)
            SceneManager.LoadScene(0);
    }

    private void Walk()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0f;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;
    }

    public void GetDamage()
    {
        life -= 1;
        Debug.Log(life);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Respawn")
            SceneManager.LoadScene(0);
    }
}
