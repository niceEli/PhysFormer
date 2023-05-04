using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockrot : MonoBehaviour
{
    Transform ts;
    private void Start()
    {
        ts = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        ts.rotation = new Quaternion(0, 0, 0, 0);
    }
}
