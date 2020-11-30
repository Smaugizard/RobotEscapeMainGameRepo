using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingScript : MonoBehaviour
{
    public float highest;
    public float lowest;
    public bool goingUp;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        highest = gameObject.transform.position.y + .5f;
        lowest = gameObject.transform.position.y - 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (goingUp)
        {
            rb.MovePosition(new Vector3(transform.position.x, transform.position.y + Time.deltaTime, transform.position.z));
            if(transform.position.y > highest)
            {
                goingUp = false;
            }
        }
        else
        {
            rb.MovePosition(new Vector3(transform.position.x, transform.position.y - Time.deltaTime, transform.position.z));
            if (transform.position.y < lowest)
            {
                goingUp = true;
            }
        }
    }
}
