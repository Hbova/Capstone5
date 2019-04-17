using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : MonoBehaviour , IMoveableObject
{
    public Transform player;
    private Vector3 closedPosition;
    private bool close = false;
    private bool openInOpenOut;

    // Start is called before the first frame update
    void Start()
    {
        closedPosition = new Vector3(0f, transform.rotation.y, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < 10)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                close = true;
                if (transform.rotation.y > 0) openInOpenOut = true;
                else openInOpenOut = false;
            }
        }

        if (close)
        {
            transform.Rotate(new Vector3(0f, Mathf.Lerp(transform.position.y, closedPosition.y, Time.deltaTime), 0f));
            if (transform.rotation.y <= 0 && openInOpenOut)
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                close = false;
            }
            if (transform.rotation.y >= 0 && !openInOpenOut)
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                close = false;
            }
            //transform.rotation.eulerAngles = new Vector3(0f,Mathf.Lerp(transform.position.y,closedPosition.y,Time.deltaTime),0f);
        }
    }

    public void OnClicked()
    {
        
    }

    public void OnThrown()
    {
        
    }

    public void OnMouseHover()
    {
        if (Vector3.Distance(player.position, transform.position) < 8) Debug.Log("Care to pick this up?"); //Change cursor to indicate player can use this
    }

    public bool IsHeld()
    {
        return true;
    }
}
