using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamesCheck : MonoBehaviour
{
    public GameObject nextButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("Mouse") == 1 && PlayerPrefs.GetInt("Rabbit") == 1 && PlayerPrefs.GetInt("Badger") == 1 && PlayerPrefs.GetInt("Fox") == 1)
        {
            nextButton.SetActive(true);
        }
    }
}
