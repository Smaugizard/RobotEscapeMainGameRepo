using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name == "Engine" && GameObject.Find("Migration").GetComponent<Integration>().hasEngine)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (gameObject.name == "Body" && GameObject.Find("Migration").GetComponent<Integration>().hasBody)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        if (gameObject.name == "LeftWing" && GameObject.Find("Migration").GetComponent<Integration>().hasLeftWing)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        if (gameObject.name == "RightWing" && GameObject.Find("Migration").GetComponent<Integration>().hasRightWing)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        if (gameObject.name == "Cockpit" && GameObject.Find("Migration").GetComponent<Integration>().hasCockpit)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
