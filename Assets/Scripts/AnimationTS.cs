using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTS : MonoBehaviour
{
    public GameObject Accueil1;
    public GameObject Accueil2;

    private int step;
    public Animator animAcc1;
    public Animator animAcc2;
    public AudioSource audioAcc;

    void Start()
    {
        step = 0;
        audioAcc.Stop();
        Debug.Log("\t\tAnim accueil 1 playing");
        animAcc1.Play("Accueil1");
    }

    void Update()
    {
        if (step == 0)
        {
            if (!animAcc1.GetComponent<Animation>().IsPlaying("Accueil1"))
            {
                Debug.Log("\t\tAnim Accueil 1 finished");
                Accueil1.SetActive(false);
                step = 1;
                animAcc2.GetComponent<Animation>().Play("Accueil2");
                Debug.Log("\t\tAnim accueil 2 playing");
                audioAcc.Play();
                Debug.Log("\t\tAudio accueil 2 playing");

            }
        }
        else if(step == 1)
        {
            if (!animAcc2.GetComponent<Animation>().IsPlaying("Accueil2"))
            {
                Debug.Log("\t\tAnim accueil 2 finished");
                step = 2; 
                Accueil2.SetActive(false);
            }
        }

    }
}
