using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    public Light Match;

    public float LifeSpan;

    float flickerWait = 0f;

    private void Awake()
    {
        LifeSpan = getLifeSpan();
    }

    void Update()
    {

        if (flickerWait <= 0f && LifeSpan > 2)
        {
            if (transform.hasChanged) Match.intensity = randomFlickerMoveing();
            else Match.intensity = randomFlickerIdle();
            flickerWait = Random.Range(.1f, .2f);
        }
        else Match.intensity = 2 * LifeSpan;
        flickerWait -= Time.deltaTime;
        LifeSpan -= Time.deltaTime;
    }

    public float randomFlickerIdle()
    {
        float intensity;
        intensity = Random.Range(60f, 70f);
        if (intensity > 75f) flickerWait += .8f;
        //Debug.Log(intensity);
        return intensity;
    }
    public float randomFlickerMoveing()
    {
        transform.hasChanged = false;
        float intensity;
        intensity = Random.Range(50f, 60f);
        if (intensity < 55f) flickerWait += .8f;
        //Debug.Log(intensity);
        return intensity;
    }
    private float getLifeSpan()
    {
        return Random.Range(5f, 7f);
    }
}
