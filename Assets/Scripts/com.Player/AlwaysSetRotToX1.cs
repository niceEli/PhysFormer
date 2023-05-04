using UnityEngine;

public class AlwaysSetRotToX1 : MonoBehaviour
{

    public Transform desiredPos;
    public Vector3 addidive;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = desiredPos.position;
        this.transform.position += addidive;
    }
}
