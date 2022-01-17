using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFishController : MonoBehaviour
{
    private float timeCounter = 0;

    private float moveSpeed; // vitesse de déplacement
    private float speed; // vitesse de rotation
    private float radius; // rayon de rotation
    private Vector2 center; // position initiale
    private Quaternion initialRotation;

    private bool trapped;

    private Rigidbody2D rb;
    private Transform target;

    float random;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 300; // vitesse de déplacement
        speed = 4; // vitesse de rotation
        radius = 100;
        center = transform.position;
        initialRotation = transform.rotation;
        trapped = true;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        random = Random.Range(1.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (trapped)
        {
            timeCounter += Time.deltaTime * speed * random;

            Vector3 oldPos = transform.position;
            transform.position = center + new Vector2(Mathf.Cos(timeCounter), Mathf.Sin(timeCounter)) * radius;

            Vector2 direction = (transform.position - oldPos).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward) * initialRotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, timeCounter*0.5f);
        }
        else
        {
            Vector2 direction = transform.position - target.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, moveSpeed * Time.deltaTime);

            rb.velocity = direction.normalized * moveSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            trapped = false;
            //transform.DetachChildren();
            transform.GetChild(0).GetComponent<PlasticBagController>().trapped = false;
            transform.GetChild(0).SetParent(transform.parent); // detach plastic bag from fish
        }
    }
}
