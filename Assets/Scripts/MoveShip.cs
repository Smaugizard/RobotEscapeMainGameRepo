using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Main Camera").GetComponent<cameraMovement>().endgame)
        {
            if(transform.position.y > 19f)
            {
                transform.rotation = Quaternion.Euler(this.transform.rotation.x,this.transform.rotation.y,this.transform.rotation.z + rotationSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector3(this.transform.position.x, this.transform.position.y + speed * Time.deltaTime, this.transform.position.z);
            }
        }
    }
}
