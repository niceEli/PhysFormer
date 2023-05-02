using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}