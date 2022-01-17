using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnsyncAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animation>()["Take 001"].time = Random.Range(0.0f, GetComponent<Animation>()["Take 001"].length);
    }
    
}
