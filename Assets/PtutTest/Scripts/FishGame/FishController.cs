using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FishController : MonoBehaviour
{
    public GameObject ARCamera;
    private Rigidbody2D rb;
    private float moveSpeed = 4000f;
    private bool canMove;


    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3 (-ARCamera.transform.up.x, ARCamera.transform.up.y, 0);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, moveSpeed * 0.5f * Time.deltaTime);

        if (canMove)
            rb.velocity = direction * moveSpeed * Time.deltaTime;
        else
            rb.velocity = Vector2.zero;
    }
}
