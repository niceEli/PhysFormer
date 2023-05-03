using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnPhysics : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    public float tta;
    int tagged;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }



    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        tagged = other.gameObject.layer;
        StartCoroutine(SCR());
    }

    IEnumerator SCR()
    {
        if (tagged == LayerMask.NameToLayer("Player"))
        {
            if (tta == 0f || tta.ToString("") == "")
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                yield return new WaitForEndOfFrame();
            }
            else
            {
                yield return new WaitForSecondsRealtime(tta);
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}