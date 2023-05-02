using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public GameObject gotd;
    public LayerMask playerLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is on the player layer
        if (((1 << collision.gameObject.layer) & playerLayer) != 0)
        {
            // Destroy the object that this script is attached to
            Destroy(gotd);
        }
    }
}
