using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCam : MonoBehaviour
{

    Ray ray;
    RaycastHit Hit;

    Camera cam;

    private void Start()
    {
        cam = transform.GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            DeformMesh();
        }
    }

    void DeformMesh()
    {
        
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out Hit))
        {
            // Deform mesh

            DeformPlane deformPlane = Hit.transform.GetComponent<DeformPlane>();
            if (deformPlane)
            { 
                deformPlane.DeformThisPlane(Hit.point);

            }
        }
    }

}
