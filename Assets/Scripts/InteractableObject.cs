using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    public UnityEvent OnSingleTouchEvent;
    public UnityEvent OnDoubleTouchEvent;


    public void SingleTouchEvent (float timeBetweenTouches)
    {
        if (OnSingleTouchEvent != null)
        {
            Invoke("SingleTouch", timeBetweenTouches);
        }
    }

    void SingleTouch()
    {
        if (OnSingleTouchEvent != null)
        {
            OnSingleTouchEvent.Invoke();
        }
    }

    public void DoubleTouchEvent()
    {
        CancelInvoke("SingleTouch");
        if (OnDoubleTouchEvent != null)
        {
            OnDoubleTouchEvent.Invoke();
        }
    }
    
}
