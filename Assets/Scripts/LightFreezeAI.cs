using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFreezeAI : MonoBehaviour
{
    public GameObject player;

    float speed = 5;

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        //if(playerIsInRoom)
        try
        {
            if (Vector3.Distance(FindObjectOfType<Light>().transform.position,transform.position) > FindObjectOfType<Light>().range) Lerp();
        }
        catch { Lerp(); }
    }

    public void Lerp()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.y = 0;
        transform.Translate((direction).normalized * Time.deltaTime * speed);
    }
}
