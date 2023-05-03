using UnityEngine;
using UnityEngine.SceneManagement;

public class Button2Scene : MonoBehaviour
{
    public string Scene2Load;
    // Start is called before the first frame update
    public void OnPressed()
    {
        SceneManager.LoadScene(Scene2Load);
    }
}
