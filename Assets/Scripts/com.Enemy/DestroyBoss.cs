using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DestroyBoss : MonoBehaviour
{
    public LayerMask playerLayer;
    public int health = 3;
    public string credits;
    public TextMeshPro tmp;
    int timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (timer <= 0)
        {
            // Check if the colliding object is on the player layer
            if (((1 << collision.gameObject.layer) & playerLayer) != 0)
            {
                Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
                RigidbodyMovement playerM = collision.GetComponent<RigidbodyMovement>();
                playerRb.velocity = new Vector2(playerRb.velocity.x, playerM.jumpForce);
                playerM.Grounded = 1;
                // Destroy the object that this script is attached to
                health--;
                timer = 25;
            }
        }
    }
    private void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(credits);
        }
        tmp.text = health.ToString("");
    }
    private void FixedUpdate()
    {
        timer--;
    }
}