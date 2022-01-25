using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class FoxGameManager : MonoBehaviour
{
    int count;
    public Image progressBar;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        count = GameObject.FindGameObjectsWithTag("Enemy").Length;
        progressBar.fillAmount = (3 - count) / 3;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            count--;
            progressBar.fillAmount = (float)(3 - count) / 3.0f;
        }
        if (count == 0)
            SceneManager.LoadScene("Scene1_new");

    }
}
