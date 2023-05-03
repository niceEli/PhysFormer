using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnPhysics : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}