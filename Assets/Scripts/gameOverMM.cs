using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverMM : MonoBehaviour
{
    public GameObject MMIcon;
    public GameObject ExitIcon;
    public AudioSource uiHover;
    
    // Start is called before the first frame update
    void Start()
    {
        MMIcon = GameObject.Find("MMImg");
        ExitIcon = GameObject.Find("ExitImg");
        ExitIcon.SetActive(false);
        MMIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onExit()
    {
        uiHover.Stop();
        uiHover.Play();
        ExitIcon.SetActive(true);
    }

    public void offExit()
    {
        ExitIcon.SetActive(false);
    }

    public void onMM()
    {
        uiHover.Stop();
        uiHover.Play();
        MMIcon.SetActive(true);
    }

    public void offMM()
    {
        MMIcon.SetActive(false);
    }
}
