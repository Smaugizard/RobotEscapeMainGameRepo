using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompletedLevelUpdater : MonoBehaviour
{
    public GameObject migrated;
    // Start is called before the first frame update
    void Start()
    {
        migrated = GameObject.Find("Migration");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void levelUpdater()
    {
        /*
        switch (migrated.GetComponent<Integration>().completedLevels)
        {
            case 8:
                GameObject.Find("Ice3").GetComponent<Button>().interactable = true;
                goto case 8;
            case 7:
                GameObject.Find("Ice2").GetComponent<Button>().interactable = true;
                goto case 7;
            case 6:
                GameObject.Find("Ice1").GetComponent<Button>().interactable = true;
                goto case 6;
            case 5:
                GameObject.Find("Metal3").GetComponent<Button>().interactable = true;
                goto case 5;
            case 4:
                GameObject.Find("Metal2").GetComponent<Button>().interactable = true;
                goto case 4;
            case 3:
                GameObject.Find("Metal1").GetComponent<Button>().interactable = true;
                goto case 3;
            case 2:
                GameObject.Find("Ground3").GetComponent<Button>().interactable = true;
                goto case 2;
            case 1:
                GameObject.Find("Ground2").GetComponent<Button>().interactable = true;
                goto case 1;
            case 0:
                GameObject.Find("Ground1").GetComponent<Button>().interactable = true;
                break;
            default:
                break;
        }
        */
    }
}
