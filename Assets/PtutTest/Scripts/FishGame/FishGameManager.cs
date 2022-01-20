using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FishGameManager : MonoBehaviour
{
    int count;

    // Start is called before the first frame update
    void Start()
    {
        count = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            count--;

        Destroy(collision.gameObject);

        if (count == 0)
            SceneManager.LoadScene("SceneFinal");
    }

}
