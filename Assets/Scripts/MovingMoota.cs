using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMoota : MonoBehaviour
{
    private bool moving = false;
    private Animator anim;
    Vector3 tempPos;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        transform.localPosition = new Vector3( 1.750f, -0.04f , -0.46f );
        tempPos = transform.localPosition;
    }

    public void isMoving()
    {
        anim.SetBool("isMoving", true);
        moving = true;
        
    }
    // x = 0.16 final
    // x = 2.0 begin
    // Update is called once per frame
    void Update()
    {
         if(transform.localPosition.x <= 0.425f)
        {
            anim.SetBool("isMoving", false);
            moving = false;
            //transform.localPosition = new Vector3( 0.425f, -0.04f , -0.46f );
            
        }
        
        if(moving)
        {
            //tempPos = transform.localPosition;
            tempPos.x -= 0.005f;

            transform.localPosition = tempPos;
          
        }
       
    }
}
