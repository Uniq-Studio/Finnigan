using System.Collections;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class SpawnAndPlace : MonoBehaviour
{
    public int durability;
    public GameObject self;
    private Rigidbody rb;

    public GameObject DF1;
    public GameObject DF2;
    public GameObject DF3;

    private void Start()
    {
        //They would randomly shivering so this helps it freeze in place
        rb = GetComponent<Rigidbody>();
        StartCoroutine(StopMoving());
    }

    private void Update()
    {
        //destroys itself when there is no durability
        if (durability <= 0)
        {
            KillObject();
        }
    }

    private void KillObject()
    {
        //Stops taking damage to free up resources
        StopCoroutine(TakeDamage());
        //Destroys itself
        Destroy(self);
    }

    private void OnTriggerEnter(Collider collider)
    {
        //When Raider enters, Durability takes damage
        if (collider.CompareTag("Raider"))
        {
            StartCoroutine(TakeDamage());
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        //Stops when Raider leaves
        if (collider.CompareTag("Raider"))
        {
            StopCoroutine(TakeDamage());
        }
    }

    private IEnumerator StopMoving()
    {
        //This is a jank way of "disabling" the "Gravity"
        yield return new WaitForSeconds(2.75f);
        rb.drag = 100;
        rb.angularDrag = 100;
    }

    private IEnumerator TakeDamage()
    {
        //When durability isn't 0, Takes durability and waits to repeat
        while (durability >= 1)
        {
            durability--;
            yield return new WaitForSeconds(5);
        }
    }

    public void SpawnIn(int round)
    {
        if (round == 1)
        {
            DF1.SetActive(true);
        }
        else if (round == 2)
        {
            DF2.SetActive(true);
            DF1.SetActive(false);
        }
        else if (round == 3)
        {
            DF3.SetActive(true);
            DF2.SetActive(false);
        }
        else
        {
            Debug.LogError("I cant spawn that in, Is the value higher than 3 or lower than one. Im seeing: " + round);
        }
    }

}