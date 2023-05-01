using UnityEngine;

public class AlwaysSetRotToX : MonoBehaviour
{

    public Transform desiredPos;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = desiredPos.position;
    }
}
