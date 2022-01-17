using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEvents : MonoBehaviour
{
	float firstTouchTime = 0f;
	float timeBetweenTouches = 0.2f;
	bool doubleTouchInitialized = false;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{ // if left button pressed...
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.tag == "Interactable")
				{
                    GameObject obj = null;
					GameObject[] interactables = GameObject.FindGameObjectsWithTag("Interactable");
                    foreach(GameObject go in interactables)
                    {
                        if (hit.collider == go.GetComponent<BoxCollider>())
                        {
                            obj = go;
                            //Debug.Log("\t\t COLLISION WITH " + obj.name);
                            break;
                        }
                    }
                    if(null == obj)
                    {
                        Debug.Log("\t\tCAN'T FIND OBJECT HIT");
                        obj = GameObject.FindGameObjectWithTag("Interactable");
                    }
					if (!doubleTouchInitialized)
					{
						obj.GetComponent<InteractableObject>().SingleTouchEvent(timeBetweenTouches);

						// init double tapping
						doubleTouchInitialized = true;
						firstTouchTime = Time.time;
					}
					else if (Time.time - firstTouchTime < timeBetweenTouches)
					{
						obj.GetComponent<InteractableObject>().DoubleTouchEvent();
					}
				}
			}
		}
		if (Time.time - firstTouchTime > timeBetweenTouches)
		{
			doubleTouchInitialized = false;
		}
	}
}
