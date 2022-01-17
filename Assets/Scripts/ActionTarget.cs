using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// to activate the animation when we found the target
public class ActionTarget : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void isMoving()
    {
        anim.SetBool("isMoving", true);
    }
}
