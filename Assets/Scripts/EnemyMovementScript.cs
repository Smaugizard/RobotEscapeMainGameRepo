using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public float speed = 5f;
    public bool facingRight;
    public bool playerCollided = false;
    public bool canMove = true;
    public bool playerHit;
    public float counter = 0;
    public bool allowed = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && allowed)
        {
            if (facingRight)
            {
                transform.position = new Vector2(transform.position.x + 1f * speed * Time.deltaTime, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(transform.position.x + 1f * speed * Time.deltaTime * -1, transform.position.y);
            }
        }

        if (playerHit)
        {
            allowed = false;
            counter = 0f;
            playerHit = false;
        }

        if(counter >= 1.5f)
        {
            allowed = true;
        }

        counter = counter + Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.gameObject.tag == "air" || collision.gameObject.tag == "enemy" || collision.gameObject.name == "box")&& !playerCollided)
        {
            //Debug.Log("COLLISION");
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            if (facingRight)
            {
                facingRight = false;
            }
            else
            {
                facingRight = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "air" || collision.gameObject.tag == "enemy" || collision.gameObject.name == "box") && !playerCollided)
        {
            //Debug.Log("COLLISION");
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            if (facingRight)
            {
                facingRight = false;
            }
            else
            {
                facingRight = true;
            }
        }
    }
}
