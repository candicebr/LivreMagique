using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticBagController : MonoBehaviour
{
    public bool trapped;
    private Rigidbody2D rb;
    private Transform target;
    float speed; // vitesse rotation
    float moveSpeed; // vitesse de déplacement

    // Start is called before the first frame update
    void Start()
    {
        trapped = true;
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<Transform>();
        speed = 2;
        moveSpeed = 200;
    }

    // Update is called once per frame
    void Update()
    {
        if (!trapped)
        {
            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle+180, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

            rb.velocity = direction.normalized * moveSpeed;
        }
        else
            rb.velocity = Vector2.zero;
    }
}
