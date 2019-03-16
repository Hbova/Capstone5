using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject match;
    private GameObject instantiatedMatch;

    public UnityEngine.AI.NavMeshAgent agent;
    public Transform agentTarget;

    public AnimationCurve mouseSensitivityCurve = new AnimationCurve(new Keyframe(0f, 0.5f, 0f, 5f), new Keyframe(1f, 2.5f, 0f, 0f));

    public Transform sceneCamera;

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
        RotateDestination(GetDestination());
        agent.destination =  agentTarget.position;
        if (Input.GetMouseButton(1))
        {
            var mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            var mouseSensitivityFactor = mouseSensitivityCurve.Evaluate(mouseMovement.magnitude);

            sceneCamera.eulerAngles -= new Vector3( mouseMovement.y * mouseSensitivityFactor,0f,0f);
            transform.eulerAngles += new Vector3(0f,mouseMovement.x * mouseSensitivityFactor,0f);
        }
    }

    public Vector3 GetDestination()
    {
        Vector3 direction = new Vector3();
        float run;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //transform.eulerAngles -= new Vector3(0f,1f,0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.eulerAngles += new Vector3(0f, 1f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = 2f;
        }
        else run = 1;
        return direction * Time.deltaTime * 8 * run;
    }

    public void RotateDestination(Vector3 direction)
    {
        Vector3 rotatedTranslation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z) * direction ;

        agentTarget.transform.position += rotatedTranslation;
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
