using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : Reputation
{
    Transform snailBody;
    GameObject snailGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.name == "Player"){
            //run();
            //snailBody.transform.Rotate(0f, 0f, 0f, Space.World);
            //Add Happy Sound
            //AddPoints(10);
            Destroy(snailGameObject);
            
        }
    }

    void run()
    {
        Vector3 move = transform.forward * 5;
        snailBody.position = move * Time.deltaTime;
    }
}
