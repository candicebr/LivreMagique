using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabbitGameManager : MonoBehaviour
{

    public Text scoreText;
    private int carotsLeft = 3;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Encore " + carotsLeft + " carottes a ramasser";
    }

    // Update is called once per frame
    void Update()
    {
        carotsLeft = GameObject.FindGameObjectsWithTag("Interactable").Length;
        scoreText.text = "Encore " + carotsLeft + " carottes a ramasser";
    }
}
