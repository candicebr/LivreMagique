using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RabbitGameManager : MonoBehaviour
{

    public Text scoreText;
    private int carotsLeft = 3;
    public Image progressBar;
    float FillSpeed = 0.2f;

    AudioSource audioEndGame;
    bool EndGame = false;
    public Image rotationScreen;
    public GameObject sound;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Rabbit", 1);
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        progressBar.fillAmount = 0;
        scoreText.text = "Encore " + carotsLeft + " carottes a ramasser";
        audioEndGame = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.orientation == ScreenOrientation.LandscapeLeft)
        {
            rotationScreen.gameObject.SetActive(false);
            sound.SetActive(true);
        }
        carotsLeft = GameObject.FindGameObjectsWithTag("Interactable").Length;
        scoreText.text = "Encore " + carotsLeft + " carottes a ramasser";

        if (progressBar.fillAmount < (float)(3 - carotsLeft) / 3.0f)
            progressBar.fillAmount += FillSpeed * Time.deltaTime;

        if (carotsLeft == 0)
        {
            if (EndGame && !audioEndGame.isPlaying)
            {
                Screen.orientation = ScreenOrientation.Portrait;
                SceneManager.LoadScene("Scene1_new");
            }
            else if (!audioEndGame.isPlaying)
            {
                sound.GetComponent<AudioSource>().Stop();
                audioEndGame.Play();
                EndGame = true;
            }
        }
    }
}
