using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject PlayI;
    public GameObject TutorialI;
    public GameObject ExitI;
    public AudioSource uiHover;
    // Start is called before the first frame update
    void Start()
    {
        PlayI = GameObject.Find("PlayImg");
        TutorialI = GameObject.Find("TutorialImg");
        ExitI = GameObject.Find("ExitImg");

        PlayI.SetActive(false);
        TutorialI.SetActive(false);
        ExitI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playGame()
    {
        SceneManager.LoadScene("GroundOne");
    }

    public void tutorialGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void exit()
    {
        Application.Quit();
    }

    public void playHoverOn()
    {
        uiHover.Stop();
        uiHover.Play();
        PlayI.SetActive(true);
    }

    public void playHoverOff()
    {
        PlayI.SetActive(false);
    }

    public void tutorialHoverOn()
    {
        uiHover.Stop();
        uiHover.Play();
        TutorialI.SetActive(true);
    }

    public void tutorialHoverOff()
    {
        TutorialI.SetActive(false);
    }

    public void exitHoverOn()
    {
        uiHover.Stop();
        uiHover.Play();
        ExitI.SetActive(true);
    }

    public void exitHoverOff()
    {
        ExitI.SetActive(false);
    }
}
