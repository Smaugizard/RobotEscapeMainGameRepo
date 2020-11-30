using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpedOnHead : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 15f);
            collision.gameObject.GetComponent<PlayerMovement>().jump.Play();
            Destroy(transform.parent.gameObject);
        }
    }
}
