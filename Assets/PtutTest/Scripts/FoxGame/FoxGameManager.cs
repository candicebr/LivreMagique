using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class FoxGameManager : MonoBehaviour
{
    int count;
    public Image progressBar;
    float FillSpeed = 0.2f;
    AudioSource audioEndGame;
    bool EndGame = false;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        count = GameObject.FindGameObjectsWithTag("Enemy").Length;
        progressBar.fillAmount = 0;
        audioEndGame = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (progressBar.fillAmount < (float)(3 - count) / 3.0f)
            progressBar.fillAmount += FillSpeed * Time.deltaTime;

        if (count == 0)
        {
            // Change scene
            if (EndGame && !audioEndGame.isPlaying)
                SceneManager.LoadScene("Scene1_new");
            //EndGame audio
            else if (!audioEndGame.isPlaying)
            {
                audioEndGame.Play();
                EndGame = true;
            }
        }
    }
           
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            count--;
        }
    }
}
