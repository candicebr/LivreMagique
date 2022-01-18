using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapJellyFishController : MonoBehaviour
{
    private float timeCounter = 0;

    private float moveSpeed; // moving speed
    private float speed; // floating speed
    private Quaternion initialRotation;

    private bool trapped;
    private bool floatup;
    private float floatSpeed;

    private Rigidbody2D rb;
    private Transform target;

    float random;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 3000; // moving speed
        speed = 20; // floating speed
        initialRotation = transform.rotation;
        trapped = true;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        random = Random.Range(1.0f, 2.0f);

        floatup = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (trapped)
        {
            Time.timeScale = 1.0f;
            timeCounter = Time.deltaTime * speed * random;

            if (floatup)
                StartCoroutine(floatingup());
            else if (!floatup)
                StartCoroutine(floatingdown()); ;
        }
        else
        {
            Vector2 direction = transform.position - target.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward) * initialRotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, timeCounter);

            rb.velocity = direction.normalized * moveSpeed * Time.deltaTime;
        }
    }

    private IEnumerator floatingup()
    {
        Vector2 pos = transform.position;
        transform.position = pos + (Vector2)transform.right * timeCounter;
        yield return new WaitForSeconds(2);
        floatup = false;
    }

    private IEnumerator floatingdown()
    {
        Vector2 pos = transform.position;
        transform.position = pos - (Vector2)transform.right * timeCounter;
        yield return new WaitForSeconds(2);
        floatup = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && trapped)
        {
            trapped = false;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(1).SetParent(transform.parent); // detach plastic bag from fish
        }
    }
}
