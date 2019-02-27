using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    public Light Match;

    float flickerWait = 0f;

    void Update()
    {
        
        if (flickerWait <= 0f)
        {
            if (transform.hasChanged) Match.intensity = randomFlickerMoveing();
            else Match.intensity = randomFlickerIdle();
            flickerWait = Random.Range(.1f, .2f);
        }
        flickerWait -= Time.deltaTime;
    }

    public float randomFlickerIdle()
    {
        float intensity;
        intensity = Random.Range(150f, 220f);
        if (intensity > 200f) flickerWait += .5f;
        return intensity;
    }
    public float randomFlickerMoveing()
    {
        transform.hasChanged = false;
        float intensity;
        intensity = Random.Range(50f, 150f);
        if (intensity < 100f) flickerWait += .5f;
        return intensity;
    }
}
