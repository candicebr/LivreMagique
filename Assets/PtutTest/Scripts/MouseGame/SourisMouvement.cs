using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SourisMouvement : MonoBehaviour
{
    private Vector3 touchPosition;
    private Vector3 direction;
    //private Vector3 firstPosition;
    private float speed = 0.2f;
    private int compteur = 0;


    private float timer = 0.0f;
    private bool victory = false;

    public Sprite fleur;
    public Image progressBar;
    float FillSpeed = 0.2f;
    AudioSource audioEndGame;
    bool EndGame = false;


    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        // firstPosition = transform.position;
        //direction = transform.position;
        touchPosition = transform.position;
        progressBar.fillAmount = 0;
        audioEndGame = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position).normalized;
        }

        if ((touchPosition - transform.position).magnitude >= 0.15)
        {
            transform.position += direction * speed;

            float scalAngle = Vector3.Dot(transform.up, direction);
            if (scalAngle != 0)
            {
                float sign = Mathf.Sign(Vector3.Dot(new Vector3(0, 0, 1), Vector3.Cross(transform.up, direction)));
                float angle = Mathf.Acos(Mathf.Abs(scalAngle)) * Mathf.Rad2Deg;
                transform.RotateAround(transform.position, new Vector3(0,0,1), sign*angle*0.1f);
            }
            
        }

        if (progressBar.fillAmount < compteur / 9.0f)
            progressBar.fillAmount += FillSpeed * Time.deltaTime;

        if (victory)
        {
            timer += Time.deltaTime;
            
            if (timer >= 1f)
            {   
                revealFlower();
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

    }

    public void increaseCompteur()
    {
        compteur++;
        if (compteur == 9)
        {
            victory = true;
        }
    }


    public void revealFlower()
    {
        GameObject.Find("Fleur0").GetComponent<SpriteRenderer>().sprite = fleur;
        GameObject.Find("Fleur1").GetComponent<SpriteRenderer>().sprite = fleur;
        GameObject.Find("Fleur2").GetComponent<SpriteRenderer>().sprite = fleur;
    }

 }
