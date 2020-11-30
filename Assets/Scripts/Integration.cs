using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Integration : MonoBehaviour
{
    private static bool playerExist;
    public float playerHealth = 3;

    public bool hasShears;
    public bool hasWrench;
    public bool hasScrewdriver;
    public bool hasHammer;
    public bool updateLife;

    public bool hasDucky;

    public bool hasLeftWing;
    public bool hasRightWing;
    public bool hasCockpit;
    public bool hasEngine;
    public bool hasBody;

    public GameObject healthOne;
    public GameObject healthTwo;
    public GameObject healthThree;

    public float completedLevels = 0;
    public bool isCompleted = false;

    public bool gameOver = false;

    public Scene sceneName;

    public bool hitMarker;
    // Start is called before the first frame update
    void Start()
    {
        if (!playerExist)
        {
            playerExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        sceneName = SceneManager.GetActiveScene();
        healthOne = GameObject.Find("Health1");
        healthTwo = GameObject.Find("Health2");
        healthThree = GameObject.Find("Health3");
    }

    public void increaseLevelCount()
    {
        completedLevels = completedLevels + 1;
        isCompleted = false;
        GameObject.Find("Canvas").GetComponent<CompletedLevelUpdater>().levelUpdater();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCompleted)
        {
            Scene name = SceneManager.GetActiveScene();
            if(name.name == "GroundOne" && completedLevels == 0)
            {
                increaseLevelCount();
            }
            else if(name.name == "GroundTwo" && completedLevels == 1)
            {
                increaseLevelCount();
            }
            else if (name.name == "GroundThree" && completedLevels == 2)
            {
                increaseLevelCount();
            }
            else if (name.name == "MetalOne" && completedLevels == 3)
            {
                increaseLevelCount();
            }
            else if (name.name == "MetalTwo" && completedLevels == 4)
            {
                increaseLevelCount();
            }
            else if (name.name == "MetalThree" && completedLevels == 5)
            {
                increaseLevelCount();
            }
            else if (name.name == "IceOne" && completedLevels == 6)
            {
                increaseLevelCount();
            }
            else if (name.name == "IceTwo" && completedLevels == 7)
            {
                increaseLevelCount();
            }

            switch (completedLevels)
            {
                case 8:
                    GameObject.Find("Ice3").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ice2").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ice1").GetComponent<Button>().interactable = true;
                    GameObject.Find("Metal3").GetComponent<Button>().interactable = true;
                    GameObject.Find("Metal2").GetComponent<Button>().interactable = true;
                    GameObject.Find("Metal1").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ground3").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ground2").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ground1").GetComponent<Button>().interactable = true;
                    break;
                case 7:
                    GameObject.Find("Ice2").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ice1").GetComponent<Button>().interactable = true;
                    GameObject.Find("Metal3").GetComponent<Button>().interactable = true;
                    GameObject.Find("Metal2").GetComponent<Button>().interactable = true;
                    GameObject.Find("Metal1").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ground3").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ground2").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ground1").GetComponent<Button>().interactable = true;
                    break;
                case 6:
                    GameObject.Find("Ice1").GetComponent<Button>().interactable = true;
                    GameObject.Find("Metal3").GetComponent<Button>().interactable = true;
                    GameObject.Find("Metal2").GetComponent<Button>().interactable = true;
                    GameObject.Find("Metal1").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ground3").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ground2").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ground1").GetComponent<Button>().interactable = true;
                    break;
                case 5:
                    GameObject.Find("Metal3").GetComponent<Button>().interactable = true;
                    GameObject.Find("Metal2").GetComponent<Button>().interactable = true;
                    GameObject.Find("Metal1").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ground3").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ground2").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ground1").GetComponent<Button>().interactable = true;
                    break;
                case 4:
                    GameObject.Find("Metal2").GetComponent<Button>().interactable = true;
                    GameObject.Find("Metal1").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ground3").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ground2").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ground1").GetComponent<Button>().interactable = true;
                    break;
                case 3:
                    GameObject.Find("Metal1").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ground3").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ground2").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ground1").GetComponent<Button>().interactable = true;
                    break;
                case 2:
                    GameObject.Find("Ground3").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ground2").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ground1").GetComponent<Button>().interactable = true;
                    break;
                case 1:
                    GameObject.Find("Ground2").GetComponent<Button>().interactable = true;
                    GameObject.Find("Ground1").GetComponent<Button>().interactable = true;
                    break;
                case 0:
                    GameObject.Find("Ground1").GetComponent<Button>().interactable = true;
                    break;
                default:
                    break;
            }
        }

        Scene currentScene = SceneManager.GetActiveScene();
        if (sceneName.name != currentScene.name)
        {
            healthOne = GameObject.Find("Health1");
            healthTwo = GameObject.Find("Health2");
            healthThree = GameObject.Find("Health3");
            sceneName = SceneManager.GetActiveScene();
        }
        /*
        if (updateLife)
        {
            if (playerHealth == 3)
            {
                healthOne.SetActive(true);
                healthTwo.SetActive(true);
                healthThree.SetActive(true);
            }
            if (playerHealth == 2)
            {
                healthOne.SetActive(false);
                healthTwo.SetActive(true);
                healthThree.SetActive(true);
            }
            if (playerHealth == 1)
            {
                healthOne.SetActive(false);
                healthTwo.SetActive(false);
                healthThree.SetActive(false);
            }

            if(playerHealth == 0)
            {
                endgameInitiate();
            }

            updateLife = false;
        }
        */

        if (playerHealth == 3)
        {
            healthOne.SetActive(true);
            healthTwo.SetActive(true);
            healthThree.SetActive(true);
        }
        if (playerHealth == 2)
        {
            healthOne.SetActive(false);
            healthTwo.SetActive(true);
            healthThree.SetActive(true);
        }
        if (playerHealth == 1)
        {
            healthOne.SetActive(false);
            healthTwo.SetActive(false);
            healthThree.SetActive(true);
        }

        if (playerHealth == 0)
        {
            endgameInitiate();
        }

        updateLife = false;

        hitMarker = GameObject.Find("Player").GetComponent<hitPlayer>().wasHit;
        if (hitMarker)
        {
            if(playerHealth == 3)
            {
                playerHealth = 2;
                healthOne.SetActive(false);
            }
            else if(playerHealth == 2)
            {
                playerHealth = 1;
                healthTwo.SetActive(false);
            }
            else if(playerHealth == 1)
            {
                playerHealth = 0;
                healthThree.SetActive(false);
                //Debug.Log("GameEnd");
            }
            GameObject.Find("Player").GetComponent<hitPlayer>().wasHit = false;
        }
        
    }

    public void destroyItself()
    {
        playerExist = false;
        Destroy(gameObject);
    }

    public void endgameInitiate()
    {
        gameOver = true;
        Destroy(GameObject.Find("Player"));
    }
}
