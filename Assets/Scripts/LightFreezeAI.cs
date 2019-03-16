using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFreezeAI : MonoBehaviour
{
    public GameObject player;

    public UnityEngine.AI.NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        //if(playerIsInRoom)
        try
        {
            if (Vector3.Distance(FindObjectOfType<Light>().transform.position, transform.position) < FindObjectOfType<Light>().range)
            {
                //agent.speed = 0;
                //agent.ResetPath();
                
                agent.destination = transform.position;
            }  
        }
        catch { agent.destination = player.transform.position; agent.speed = 3.5f; }
    }
}
