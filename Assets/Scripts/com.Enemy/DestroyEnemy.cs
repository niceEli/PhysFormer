using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyEnemy : MonoBehaviour
{
    public GameObject gotd;
    public LayerMask playerLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is on the player layer
        if (((1 << collision.gameObject.layer) & playerLayer) != 0)
        {
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
            RigidbodyMovement playerM = collision.GetComponent<RigidbodyMovement>();
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerM.jumpForce);
            // Destroy the object that this script is attached to
            Destroy(gotd);
        }
    }
}