using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour , IMoveableObject
{
    public Transform player;
    public Transform playerHand;

    public float ThrowForce = 10;

    float LerpSpeed = 5;

    public bool Held = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Held) gameObject.GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(transform.position, playerHand.position, Time.deltaTime * LerpSpeed));//transform.Translate(GetDirection() / LerpSpeed);
    }

    public void OnClicked()
    {
        if (Vector3.Distance(player.position, transform.position) < 8)
        {
            Held = true;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    public void OnThrown()
    {
        Held = false;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().AddForce(-GetDirectionTo(player.position) * ThrowForce,ForceMode.Impulse);
    }

    public void OnMouseHover()
    {
        if (Vector3.Distance(player.position, transform.position) < 8) Debug.Log("Care to pick this up?"); //Change cursor to indicate player can use this
    }

    public bool IsHeld()
    {
        return Held;
    }

    public Vector3 GetDirectionTo(Vector3 input)
    {
        return (input - transform.position).normalized;
    }
}
