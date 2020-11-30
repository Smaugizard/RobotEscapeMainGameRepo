using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraMovement : MonoBehaviour
{
    public GameObject player;
    public bool endgame;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!endgame && GameObject.Find("Migration").GetComponent<Integration>().playerHealth != 0)
        {
            transform.position = new Vector3(player.transform.position.x + 10, this.transform.position.y, -3);

            if (player.transform.position.y > 5.5f)
            {
                transform.position = new Vector3(this.transform.position.x, player.transform.position.y - 7f, -3);
            }
            else
            {
                transform.position = new Vector3(this.transform.position.x, -1.5f, -3);
            }
        }

        if (endgame)
        {
            GameObject camNewPos = GameObject.Find("Ship");
            GameObject.Find("BackPack").GetComponent<Backpack>().WinGameUI.SetActive(true);
            if (GameObject.Find("Migration").GetComponent<Integration>().hasDucky == false)
            {
                GameObject.Find("FriendText").GetComponent<Text>().text = "But you forgot your friend";
                GameObject.Find("DuckyImg").SetActive(false);
            }

            if(camNewPos.transform.position.y > 20f && camNewPos.transform.position.y < 22f)
            {
                transform.position = new Vector3(this.transform.position.x, camNewPos.transform.position.y, -3);
            }
        }
    }
}
