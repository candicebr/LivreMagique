using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Camera cam;
    private Ray ray;
    private RaycastHit Hit;
    public Sprite diggedDirt;
    private GameObject burrow;

    private int goodCaseDigged;
    private int badCaseDigged;
    private int goodCaseToDigged;


    private GameObject[] dirts;

    public Animator animator;
    public Text scoreText;

    private bool EndGame;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        cam = Camera.main.transform.GetComponent<Camera>();

        dirts = GameObject.FindGameObjectsWithTag("DirtUndigged");
        goodCaseDigged = 0;
        badCaseDigged = 0;
        goodCaseToDigged = 0;

        burrow = GameObject.Find("Burrow");

        foreach (GameObject dirt in dirts)
        {
            if (dirt.GetComponent<DirtInformation>().isGood && dirt.GetComponent<SpriteRenderer>().sprite.name == "dirt")
                goodCaseToDigged++;
        }
        Debug.Log("nb good : " + goodCaseToDigged);

        EndGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out Hit))
            {
                Debug.Log(Hit.collider.GetComponent<ChangeSprite>());
                SpriteRenderer currentDirt = Hit.collider.GetComponent<SpriteRenderer>();
                currentDirt.sprite = diggedDirt;
                if (!Hit.collider.GetComponent<DirtInformation>().GetIsDigged())
                {
                    if (Hit.collider.GetComponent<DirtInformation>().isGood)
                    {
                        goodCaseDigged++;
                    }
                    else
                    {
                        badCaseDigged++;
                    }
                }

            }

        }

        Debug.Log("nb dirt digged : " + goodCaseDigged+badCaseDigged);

        if (goodCaseDigged == goodCaseToDigged)
        {
            Debug.Log("Tu as creusé : " + goodCaseDigged + "bonnes cases et " + badCaseDigged + " mauvaises.");
            animator.SetTrigger("EndGame");
            burrow.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 1);
            EndGame = true;
        }
        scoreText.text = "Score : " + goodCaseDigged + " / " + goodCaseToDigged;
    }

    public bool GetEndGame() { return EndGame; }
}
