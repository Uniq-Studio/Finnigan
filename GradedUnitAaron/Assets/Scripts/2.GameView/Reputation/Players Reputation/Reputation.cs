using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reputation : MonoBehaviour
{
    public int reputation = 0;
    public float betterPrice;

    //Create tires for better items
    public bool tireOne, tireTwo, tireThree, tireFour, tireFive = false;

    public void AddPoints(int points) { reputation += points; }

    //Other charaters will have diffrent expectations
    public void TireCheck (int ExpectationForTireOne, int ExpectationForTireTwo, int ExpectationForTireThree, int ExpectationForTireFour, int ExpectationForTireFive)
    {
        if (reputation >= ExpectationForTireOne && reputation <= ExpectationForTireTwo) { tireOne = true; }
        if (reputation >= ExpectationForTireTwo && reputation <= ExpectationForTireThree) { tireTwo = true; }
        if (reputation >= ExpectationForTireThree && reputation <= ExpectationForTireFour) { tireThree = true; }
        if (reputation >= ExpectationForTireFour && reputation <= ExpectationForTireFive) { tireFour = true; }
        if (reputation >= ExpectationForTireFive) { tireFive = true; }
    }
    
    //Restes them after so player cant use Tire 5 on someone who needs lots of reputaion for little.
     public void TireReset()
    {
        tireOne = false; 
        tireTwo = false; 
        tireThree = false; 
        tireFour = false; 
        tireFive = false;
    }
    //DEBUG
    private void Update()
    {
        //Debug.Log("Reputation = " + reputation);
    }
}
