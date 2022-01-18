using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    float moveSpeed; // vitesse de déplacement

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 200;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        transform.position = pos + (Vector2)transform.right * moveSpeed * Time.deltaTime;
    }
}
