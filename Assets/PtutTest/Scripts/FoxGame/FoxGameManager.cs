using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FoxGameManager : MonoBehaviour
{
    int count;

    // Start is called before the first frame update
    void Start()
    {
        count = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            count--;
        }
        if (count == 0)
            SceneManager.LoadScene("Scene1");

    }
}
