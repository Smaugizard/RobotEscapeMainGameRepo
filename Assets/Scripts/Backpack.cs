using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Backpack : MonoBehaviour
{
    public bool backpackisOpen = false;
    public GameObject playerInv;
    public GameObject player;
    public GameObject map;

    public GameObject selectedText;
    public bool showSelectedText;
    public GameObject WinGameUI;
    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.Find("Map");
        player = GameObject.Find("Player");
        playerInv = GameObject.Find("Inventory");
        playerInv.SetActive(false);
        selectedText = GameObject.Find("useToolText");
        selectedText.SetActive(false);
        if(SceneManager.GetActiveScene().name != "Tutorial")
        {
            map.SetActive(false);
        }

        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name != "Tutorial")
        {
            if (currentScene.name == "Ship")
            {
                WinGameUI = GameObject.Find("WinGame");
                WinGameUI.SetActive(false);
            }
            else
            {
                WinGameUI = GameObject.Find("LoseGame");
                WinGameUI.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Migration").GetComponent<Integration>().gameOver)
        {
            WinGameUI.SetActive(true);
        }

        if (showSelectedText)
        {
            selectedText.SetActive(true);
        }
        else
        {
            selectedText.SetActive(false);
        }
    }

    public void backpackinv()
    {
        if (!backpackisOpen)
        {
            playerInv.SetActive(true);
            backpackisOpen = true;
            player.GetComponent<PlayerMovement>().canMove = false;
        }
        else
        {
            player.GetComponent<PlayerMovement>().canMove = true;
            playerInv.SetActive(false);
            backpackisOpen = false;
        }
    }
}
