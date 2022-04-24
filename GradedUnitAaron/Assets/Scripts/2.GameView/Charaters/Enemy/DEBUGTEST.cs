using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUGTEST : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Tasks.startDefenceOne = true;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            Tasks.startDefenceTwo = true;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Tasks.startDefenceThree = true;
        }
    }
}
