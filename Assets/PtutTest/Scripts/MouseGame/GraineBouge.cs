using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraineBouge : MonoBehaviour
{

    private bool plantee = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionSouris = GameObject.Find("Souris").transform.position;
        bool sourisProche = ((positionSouris - transform.position).magnitude < 1);

        Vector3 positionTrou = GameObject.Find("Terre0").transform.position;
        Vector3 positionTrou1 = GameObject.Find("Terre1").transform.position;
        Vector3 positionTrou2 = GameObject.Find("Terre2").transform.position;

        bool trouProche = ((positionTrou - transform.position).magnitude < 1);
        bool trouProche1 = ((positionTrou1 - transform.position).magnitude < 1);
        bool trouProche2 = ((positionTrou2 - transform.position).magnitude < 1);

        bool trouCreuse = GameObject.Find("Terre0").GetComponent<TerreCreuse>().trou;
        bool trouCreuse1 = GameObject.Find("Terre1").GetComponent<TerreCreuse>().trou;
        bool trouCreuse2 = GameObject.Find("Terre2").GetComponent<TerreCreuse>().trou;

        bool trouVide = !(GameObject.Find("Terre0").GetComponent<TerreCreuse>().graineDansTrou);
        bool trou1Vide = !(GameObject.Find("Terre1").GetComponent<TerreCreuse>().graineDansTrou);
        bool trou2Vide = !(GameObject.Find("Terre2").GetComponent<TerreCreuse>().graineDansTrou);

        if (!plantee)
        {
            if (trouCreuse && trouProche && trouVide)
            {
                transform.position = positionTrou + new Vector3(0, -0.1f, -0.2f);
                GameObject.Find("Terre0").GetComponent<TerreCreuse>().graineDansTrou = true;
                plantee = true;
                GameObject.Find("Souris").GetComponent<SourisMouvement>().increaseCompteur();
            }
            else if (trouCreuse1 && trouProche1 && trou1Vide)
            {
                transform.position = positionTrou1 + new Vector3(0, -0.1f, -0.2f);
                GameObject.Find("Terre1").GetComponent<TerreCreuse>().graineDansTrou = true;
                plantee = true;
                GameObject.Find("Souris").GetComponent<SourisMouvement>().increaseCompteur();
            }
            else if (trouCreuse2 && trouProche2 && trou2Vide)
            {
                transform.position = positionTrou2 + new Vector3(0, -0.1f, -0.2f);
                GameObject.Find("Terre2").GetComponent<TerreCreuse>().graineDansTrou = true;
                plantee = true;
                GameObject.Find("Souris").GetComponent<SourisMouvement>().increaseCompteur();
            }
            else if (sourisProche)
            {
                transform.position = positionSouris + new Vector3(0, 0, 0.1f);
                transform.rotation = GameObject.Find("Souris").transform.rotation;
            }
        }

    }
}
