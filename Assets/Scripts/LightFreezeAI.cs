using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFreezeAI : MonoBehaviour
{
    public GameObject player;

    public UnityEngine.AI.NavMeshAgent agent;

    float speed = 5;

    // Update is called once per frame
    void Update()
    {
        //if(playerIsInRoom)
        try
        {
            if (Vector3.Distance(FindObjectOfType<Light>().transform.position, transform.position) > FindObjectOfType<Light>().range)
            {
                agent.Stop();
                agent.isStopped = true;
            }  
        }
        catch { agent.destination = player.transform.position; }
    }
}
