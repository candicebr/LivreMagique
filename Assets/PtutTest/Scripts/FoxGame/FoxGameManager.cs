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
    public AudioSource audioStart;
    AudioSource audioEndGame;
    bool EndGame;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        count = GameObject.FindGameObjectsWithTag("Enemy").Length;
        progressBar.fillAmount = 0;
        audioEndGame = GetComponent<AudioSource>();
        EndGame = false;
    }


    // Update is called once per frame
    void Update()
    {
        // Change scene
        if (EndGame && !audioEndGame.isPlaying)
        {
            audioEndGame.Stop();
            SceneManager.LoadScene("Scene1_new");
        }

        if (count == 0)
        { 
            //EndGame audio
            if (!EndGame && !audioEndGame.isPlaying)
            {
                audioStart.Stop();
                audioEndGame.Play();
                EndGame = true;
            }
        }

        if (progressBar.fillAmount < (float)(3 - count) / 3.0f)
            progressBar.fillAmount += FillSpeed * Time.deltaTime;
    }
           
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            count--;
        }
    }
}
