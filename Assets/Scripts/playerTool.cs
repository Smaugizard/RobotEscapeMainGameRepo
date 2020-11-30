using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerTool : MonoBehaviour
{
    public GameObject insideObject;
    public string currentItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(insideObject != null && Input.GetKeyDown(KeyCode.E))
        {
            if(insideObject.gameObject.tag == "bush" && currentItem == "Shears" && SceneManager.GetActiveScene().name != "Tutorial")
            {
                GameObject.Find("BackPack").GetComponent<Backpack>().showSelectedText = false;
                insideObject.GetComponent<SpriteRenderer>().enabled = false;
                insideObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
            else if (insideObject.gameObject.tag == "bush" && currentItem == "Shears" && SceneManager.GetActiveScene().name == "Tutorial")
            {
                GameObject.Find("BackPack").GetComponent<Backpack>().showSelectedText = false;
                Destroy(insideObject);
            }

            if (insideObject.gameObject.tag == "cage" && currentItem == "Wrench")
            {
                GameObject.Find("BackPack").GetComponent<Backpack>().showSelectedText = false;
                insideObject.GetComponent<SpriteRenderer>().enabled = false;
                insideObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }

            if (insideObject.gameObject.tag == "rock" && currentItem == "Hammer")
            {
                GameObject.Find("BackPack").GetComponent<Backpack>().showSelectedText = false;
                insideObject.GetComponent<SpriteRenderer>().enabled = false;
                insideObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }

            if (insideObject.gameObject.tag == "safe" && currentItem == "Screwdriver")
            {
                GameObject.Find("BackPack").GetComponent<Backpack>().showSelectedText = false;
                insideObject.GetComponent<SpriteRenderer>().enabled = false;
                insideObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "bush" || collision.gameObject.tag == "cage" || collision.gameObject.tag == "rock" || collision.gameObject.tag == "safe") && collision.gameObject.GetComponent<SpriteRenderer>().enabled == true)
        {
            insideObject = collision.gameObject;
            //Debug.Log(collision.gameObject.tag);
            GameObject.Find("BackPack").GetComponent<Backpack>().showSelectedText = true;
            string toolText = GameObject.Find("UseToolText").GetComponent<Text>().text;
            if (collision.gameObject.tag == "bush")
            {
                toolText = "Press E to use your Shears";
            }
            else if (collision.gameObject.tag == "cage")
            {
                toolText = "Press E to use your Wrench";
            }
            else if (collision.gameObject.tag == "rock")
            {
                toolText = "Press E to use your Hammer";
            }
            else if (collision.gameObject.tag == "safe")
            {
                toolText = "Press E to use your Screwdriver";
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Shears" && SceneManager.GetActiveScene().name != "Tutorial")
        {
            GameObject.Find("Migration").GetComponent<Integration>().hasShears = true;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Shears" && SceneManager.GetActiveScene().name == "Tutorial")
        {
            GameObject.Find("Migration").GetComponent<Integration>().hasShears = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Hammer")
        {
            if (collision.gameObject.transform.parent.GetComponent<SpriteRenderer>().enabled == false)
            {
                GameObject.Find("Migration").GetComponent<Integration>().hasHammer = true;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "Screwdriver")
        {
            if(collision.gameObject.transform.parent.GetComponent<SpriteRenderer>().enabled == false)
            {
                GameObject.Find("Migration").GetComponent<Integration>().hasScrewdriver = true;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "Wrench")
        {
            if (collision.gameObject.transform.parent.GetComponent<SpriteRenderer>().enabled == false)
            {
                GameObject.Find("Migration").GetComponent<Integration>().hasWrench = true;
                Destroy(collision.gameObject);
            }
        }

        if((collision.gameObject.tag == "bush" || collision.gameObject.tag == "cage" || collision.gameObject.tag == "rock" || collision.gameObject.tag == "safe") && collision.gameObject.GetComponent<SpriteRenderer>().enabled == true)
        {
            insideObject = collision.gameObject;
            GameObject.Find("BackPack").GetComponent<Backpack>().showSelectedText = true;
        }

        Integration migrate = GameObject.Find("Migration").GetComponent<Integration>();
        if(collision.gameObject.tag == "ship" && migrate.hasBody && migrate.hasCockpit && migrate.hasEngine && migrate.hasLeftWing && migrate.hasRightWing)
        {
            Destroy(GameObject.Find("Player"));
            GameObject.Find("Main Camera").GetComponent<cameraMovement>().endgame = true;
        }

        if(collision.gameObject.tag == "exit")
        {
            Scene name = SceneManager.GetActiveScene();
            gameObject.GetComponent<PlayerMovement>().canMove = false;
            transform.position = new Vector3(GameObject.Find("exit").GetComponent<Transform>().transform.position.x, GameObject.Find("exit").GetComponent<Transform>().transform.position.y - 3.8f, this.transform.position.z);
            GameObject[] allEnemies;
            allEnemies = GameObject.FindGameObjectsWithTag("enemy");

            foreach (GameObject enemy in allEnemies)
            {
                Destroy(enemy);
            }

            if (name.name == "Tutorial")
            {
                GameObject.Find("Migration").GetComponent<Integration>().playerHealth = 3;
                GameObject.Find("Migration").GetComponent<Integration>().hasShears = false;
                GameObject.Find("Migration").GetComponent<Integration>().hasHammer = false;
                GameObject.Find("Migration").GetComponent<Integration>().hasScrewdriver = false;
                GameObject.Find("Migration").GetComponent<Integration>().hasWrench = false;
                GameObject.Find("Migration").GetComponent<Integration>().completedLevels = 0;
                GameObject.Find("Migration").GetComponent<Integration>().destroyItself();

                SceneManager.LoadScene("MainScreen");
            }
            else
            {
                GameObject.Find("BackPack").GetComponent<Backpack>().map.SetActive(true);
                GameObject.Find("Migration").GetComponent<Integration>().isCompleted = true;
            }
        }

        if (collision.gameObject.tag == "WingLeft")
        {
            if (collision.gameObject.transform.parent.GetComponent<SpriteRenderer>().enabled == false)
            {
                GameObject.Find("Migration").GetComponent<Integration>().hasLeftWing = true;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "WingRight")
        {
            if (collision.gameObject.transform.parent.GetComponent<SpriteRenderer>().enabled == false)
            {
                GameObject.Find("Migration").GetComponent<Integration>().hasRightWing = true;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "Cockpit")
        {
            if (collision.gameObject.transform.parent.GetComponent<SpriteRenderer>().enabled == false)
            {
                GameObject.Find("Migration").GetComponent<Integration>().hasCockpit = true;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "Engine")
        {
            if (collision.gameObject.transform.parent.GetComponent<SpriteRenderer>().enabled == false)
            {
                GameObject.Find("Migration").GetComponent<Integration>().hasEngine = true;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "Body")
        {
            if (collision.gameObject.transform.parent.GetComponent<SpriteRenderer>().enabled == false)
            {
                GameObject.Find("Migration").GetComponent<Integration>().hasBody = true;
                Destroy(collision.gameObject);
            }
        }

        if(collision.gameObject.tag == "Ducky")
        {
            if (collision.gameObject.transform.parent.GetComponent<SpriteRenderer>().enabled == false)
            {
                GameObject.Find("Migration").GetComponent<Integration>().hasDucky = true;
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        insideObject = null;
        GameObject.Find("BackPack").GetComponent<Backpack>().showSelectedText = false;
    }
}
