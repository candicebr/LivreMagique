using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtInformation : MonoBehaviour
{
    public bool isGood;
    private bool isDigged;

    float _time;

    Color badColor;
    Color goodColor;
    Color neutralColor;

    // Start is called before the first frame update
    void Start()
    {
        isDigged = false;
        _time = 0f;
        badColor = new Color(1f, 0.2f, 0.3f, 1f);
        goodColor = new Color(0.3f, 1f, 0.4f, 1f);
        neutralColor = new Color(1f, 1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if ((int)_time%9 == 0)
        {
            if (isGood)
                gameObject.GetComponent<SpriteRenderer>().color = goodColor;
            else
                gameObject.GetComponent<SpriteRenderer>().color = badColor;

        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = neutralColor;
        }

        if (gameObject.GetComponent<SpriteRenderer>().sprite.name == "dirtdugged")
        {
            isDigged=true;
        }
    }

    public bool GetIsDigged() { return isDigged;}
}
