using UnityEngine;
using UnityEngine.UI;

public class QuitApp : MonoBehaviour
{
    private Button quitButton;
    // Start is called before the first frame update
    void Start()
    {
        quitButton = GetComponent<Button>();
        quitButton.onClick.AddListener(Quit);
    }

    private void Quit()
    {
        Application.Quit();
    }
}
