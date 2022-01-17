using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPS : MonoBehaviour
{
    public void playPS()
    {
        GetComponent<ParticleSystem>().Simulate(0.0f, true, true);
        GetComponent<ParticleSystem>().Play();
    }
}
