using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeformPlane : MonoBehaviour
{
    MeshFilter meshFilter;

    Mesh PlaneMesh;

    Vector3[] verts;

    [SerializeField]
    float Radius = 4;

    [SerializeField]
    float Power = 2;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();

        PlaneMesh = meshFilter.mesh;

        verts = PlaneMesh.vertices;
    }

    public void DeformThisPlane(Vector3 PositionToDeform)
    {
        Debug.Log("go deformer45");
    
        PositionToDeform = transform.InverseTransformPoint(PositionToDeform);
        for (int i = 0; i < verts.Length; i++)
        {
            float dist = (verts[i] - PositionToDeform).sqrMagnitude;
            Debug.Log("distance  :" +dist+" < "+Radius);


            if (dist < Radius)
            {
                verts[i] -= Vector3.up * Power;
            }
        }

        PlaneMesh.vertices = verts;
    }
}