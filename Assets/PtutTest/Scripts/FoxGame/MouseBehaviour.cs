using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform target;
    public float speed;
    bool run;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        run = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(target.position, transform.position);
        if (distance < 2) //à partir d'une certaine distance, la souris s'enfuit à l'opposé du joueur
            run = true;
        else if (distance > 5) //elle arrête de s'enfuir si elle est assez loin
            run = false;

        if (run)
        {
            Vector2 direction = transform.position - target.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

            rb.velocity = direction.normalized * speed;
        }
        else
            rb.velocity = Vector2.zero;
    }
}
