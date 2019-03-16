using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    public Light Match;

    public float LifeSpan;

    float flickerWait = 0f;

    public float intensity;

    private void Awake()
    {
        LifeSpan = getLifeSpan();
    }

    void Update()
    {

        if (flickerWait <= 0f && LifeSpan > 2)
        {
            if (transform.hasChanged) randomFlickerMoveing();
            else randomFlickerIdle();
            flickerWait = Random.Range(.1f, .2f);
        }
        else Match.intensity = 3 * LifeSpan;
        FlickerLerp();
        flickerWait -= Time.deltaTime;
        LifeSpan -= Time.deltaTime;
    }

    public void FlickerLerp()
    {
        Match.intensity = Mathf.Lerp(Match.intensity, intensity, Time.deltaTime * 2);
    }

    public void randomFlickerIdle()
    {
        intensity = Random.Range(60f, 70f);
        if (intensity > 75f) flickerWait += .8f;
        //Debug.Log(intensity);
    }
    public void randomFlickerMoveing()
    {
        transform.hasChanged = false;
        intensity = Random.Range(50f, 60f);
        if (intensity < 55f) flickerWait += .8f;
        //Debug.Log(intensity);
    }
    private float getLifeSpan()
    {
        return Random.Range(5f, 7f);
    }
}
