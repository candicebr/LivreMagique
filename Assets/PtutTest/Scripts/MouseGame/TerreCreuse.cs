using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerreCreuse : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite trouSprite;
    public Sprite petitTrouSprite;
    public bool trou = false;
    public bool sourisCreuse = false;
    public bool graineDansTrou = false;

    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 positionSouris = GameObject.Find("Souris").transform.position;

        if ((positionSouris - transform.position).magnitude < 1.5f)
        {
            timer += Time.deltaTime;
            if (!trou)
            {
                sourisCreuse = true;
                spriteRenderer.sprite = petitTrouSprite;
            
                if (timer > 1f)
                {
                    spriteRenderer.sprite = trouSprite;
                    trou = true;
                    GameObject.Find("Souris").GetComponent<SourisMouvement>().increaseCompteur();
                    sourisCreuse = false;
                }
            }
        }
        else {
            timer = 0.0f;
        }
    }
}
