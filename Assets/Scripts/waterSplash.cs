using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class waterSplash : MonoBehaviour
{
    public GameObject splashAnimation;
    public bool playerHit = false;
    private GameObject player;
    public float counter;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        counter = counter + Time.deltaTime;
        if (playerHit)
        {
            if(counter > 1f)
            {
                if(GameObject.Find("Migration").GetComponent<Integration>().playerHealth != 0)
                {
                    Scene name = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(name.name);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player" && !playerHit)
        {
            Debug.Log(collision.gameObject.transform.position);
            var clone = Instantiate(splashAnimation);
            clone.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y,collision.gameObject.transform.position.z);
            playerHit = true;
            GameObject.Find("Player").GetComponent<hitPlayer>().wasHit = true;
            GameObject.Find("Player").GetComponent<PlayerMovement>().canMove = false;
            counter = 0f;
        }
    }
}
