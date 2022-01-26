using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class FishGameManager : MonoBehaviour
{
    int count;
    private bool EndGame = false;
    AudioSource audioEndGame;

    public Image progressBar;
    float FillSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        count = 0; //GameObject.FindGameObjectsWithTag("Enemy").Length;
        audioEndGame = GetComponent<AudioSource>();
        progressBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 3)
        {
            // Change scene
            if (EndGame && !audioEndGame.isPlaying)
            {
                SceneManager.LoadScene("Scene9_new");
            }
            // LoseGame audio
            else if (!audioEndGame.isPlaying)
            {
                audioEndGame.Play();
                EndGame = true;
            }
        }

        if (progressBar.fillAmount < (float)count / 3.0)
            progressBar.fillAmount += FillSpeed * Time.deltaTime;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            count++;

        Destroy(collision.gameObject);
    }

}
