using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void groundOne()
    {
        SceneManager.LoadScene("GroundOne");
    }

    public void groundTwo()
    {
        SceneManager.LoadScene("GroundTwo");
    }

    public void groundThree()
    {
        SceneManager.LoadScene("GroundThree");
    }

    public void iceOne()
    {
        SceneManager.LoadScene("IceOne");
    }

    public void iceTwo()
    {
        SceneManager.LoadScene("IceTwo");
    }

    public void iceThree()
    {
        SceneManager.LoadScene("IceThree");
    }

    public void metalOne()
    {
        SceneManager.LoadScene("MetalOne");
    }

    public void metalTwo()
    {
        SceneManager.LoadScene("MetalTwo");
    }

    public void metalThree()
    {
        SceneManager.LoadScene("MetalThree");
    }

    public void ship()
    {
        SceneManager.LoadScene("Ship");
    }
}
