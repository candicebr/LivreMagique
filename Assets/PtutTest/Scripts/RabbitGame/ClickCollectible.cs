using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCollectible : MonoBehaviour
{

    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<ClickCollectible>().mainCamera;
        Debug.Log("start rabbit");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if(hit = Physics2D.Raycast(ray.origin, new Vector2(0,0))){

            if(Input.GetMouseButton(0)){
                Destroy(hit.transform.gameObject);
            }
        }
    }

}
