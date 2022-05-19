using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defence : MonoBehaviour
{
    public int durability;

    public Rigidbody rb;
    public GameObject self;

    void Update()
    {
        if (durability <= 0)
        {
            Destroy(self);
        }
    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Raider"))
            StartCoroutine(TakeDamage());
        

        if (collider.CompareTag("Ground"))
            rb.constraints = RigidbodyConstraints.FreezeAll;
            //https://docs.unity3d.com/ScriptReference/RigidbodyConstraints.FreezeAll.html
        
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Raider"))
            StopCoroutine(TakeDamage());
    }

    private IEnumerator TakeDamage()
    {
        //When durability isn't 0, Takes durability and waits to repeat
        while (durability >= 1)
        {
            yield return new WaitForSeconds(1);
            durability--;
        }
    }
}
