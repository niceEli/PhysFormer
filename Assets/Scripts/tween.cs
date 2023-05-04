using DG.Tweening;
using UnityEngine;

public class tween : MonoBehaviour
{
    public Vector2 final;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(final, time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
