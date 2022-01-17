using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasBouche : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite tasSprite;
    public Sprite petitTasSprite;
    public Sprite fleurSprite;
    string myname;
    bool graineDansTrou;
    GameObject maTerre;
    Vector3 objectif;
    bool go = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        myname = name;
        maTerre = GameObject.Find("Terre" + myname[3]);

        objectif = maTerre.transform.position + new Vector3(0, 0, -0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        bool sourisCreuse = maTerre.GetComponent<TerreCreuse>().sourisCreuse;
        bool trouCreuse = maTerre.GetComponent<TerreCreuse>().trou;

        if (sourisCreuse)
        {
            spriteRenderer.sprite = petitTasSprite;
        }
        if (trouCreuse)
        {
            spriteRenderer.sprite = tasSprite;
        }

        if (go)
        {
            Vector3 direction = (objectif - transform.position).normalized;
            if ((objectif - transform.position).magnitude >= 0.15)
            {
                transform.position += direction * 0.05f;
            } else
            {
                spriteRenderer.sprite = fleurSprite;
            }
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        graineDansTrou = maTerre.GetComponent<TerreCreuse>().graineDansTrou;
        if (graineDansTrou)
        {
            if (!go)
            {
                GameObject.Find("Souris").GetComponent<SourisMouvement>().increaseCompteur();
            }
            go = true;
        }
            
    }
}
