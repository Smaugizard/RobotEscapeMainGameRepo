using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkAlreadyHave : MonoBehaviour
{
    public Integration checker;
    // Start is called before the first frame update
    void Start()
    {
        checker = GameObject.Find("Migration").GetComponent<Integration>();        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "Shears")
        {
            if (checker.hasShears)
            {
                Destroy(gameObject);
            }
        }
        else if(gameObject.tag == "Hammer")
        {
            if (checker.hasHammer)
            {
                Destroy(gameObject);
            }
        }
        else if (gameObject.tag == "ScrewDriver")
        {
            if (checker.hasScrewdriver)
            {
                Destroy(gameObject);
            }
        }
        else if (gameObject.tag == "Wrench")
        {
            if (checker.hasWrench)
            {
                Destroy(gameObject);
            }
        }
        else if (gameObject.tag == "WingLeft")
        {
            if (checker.hasLeftWing)
            {
                Destroy(gameObject);
            }
        }
        else if (gameObject.tag == "WingRight")
        {
            if (checker.hasRightWing)
            {
                Destroy(gameObject);
            }
        }
        else if (gameObject.tag == "Body")
        {
            if (checker.hasBody)
            {
                Destroy(gameObject);
            }
        }
        else if (gameObject.tag == "Cockpit")
        {
            if (checker.hasCockpit)
            {
                Destroy(gameObject);
            }
        }
        else if (gameObject.tag == "Engine")
        {
            if (checker.hasEngine)
            {
                Destroy(gameObject);
            }
        }
    }
}
