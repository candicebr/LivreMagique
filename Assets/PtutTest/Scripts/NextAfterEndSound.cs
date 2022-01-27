using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextAfterEndSound : MonoBehaviour
{
    AudioSource audioEnd;

    // Start is called before the first frame update
    void Start()
    {
        audioEnd = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioEnd.isPlaying)
            SceneManager.LoadScene("End");
    }
}
