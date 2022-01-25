using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimFishEating : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayAnim()
    {
        animator.SetTrigger("come");
    }
}
