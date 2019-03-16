using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject match;
    private GameObject instantiatedMatch;

    public Transform fingers;


    // Update is called once per frame
    void Update()
    {
        if (instantiatedMatch == null)
        {
            if (Input.GetKeyDown(KeyCode.Q)) LightMatch();

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Q)) DropMatch();
            if (instantiatedMatch.GetComponent<Flicker>().LifeSpan < 0) DestroyMatch();
        }
    }

    public void DropMatch()
    {
        instantiatedMatch.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        instantiatedMatch.transform.parent = null;
    }

    public void LightMatch()
    {
        instantiatedMatch = Instantiate<GameObject>(match, getMatchTransform());
        instantiatedMatch.transform.localScale -= new Vector3(.099f,.099f,.099f);
        instantiatedMatch.transform.parent = getMatchTransform();
    }

    public void DestroyMatch()
    {
        Destroy(instantiatedMatch);
    }

    public Transform getMatchTransform()
    {
        return fingers.transform;
    }
}
