using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void ChangeScene(string idScene)
    {
        SceneManager.LoadScene("Scene"+idScene);
    }
}
