using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resetGameScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        GameObject.Find("Migration").GetComponent<Integration>().destroyItself();

        SceneManager.LoadScene("MainScreen");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
