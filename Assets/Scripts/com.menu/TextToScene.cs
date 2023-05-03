using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TextToScene : MonoBehaviour
{
    public TextMeshProUGUI Scene2Load;
    // Start is called before the first frame update
    public void OnPressed()
    {
        SceneManager.LoadScene("Level" + Scene2Load.text);
    }
}
