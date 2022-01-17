using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningRoses : MonoBehaviour
{
    public GameObject rosePrefab;
    private float nextSpawn = 0;
    public float spawnRate = 2;
    public float dist;
    private Vector3 position = new Vector3(0, 0, 0);
    private int cpt = 0;

    private void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        while ((cpt++) <= 20)
        {
            position.z += Random.Range(0.5f, 1);
            if (Time.time > nextSpawn && position.z < dist)
            {
                Instantiate<GameObject>(rosePrefab, position, Quaternion.identity).transform.parent = transform;
                nextSpawn += Time.time + spawnRate;
                Debug.Log("`\tSwpaning " + cpt + " at " + position);
            }
        }
        

    }
}
