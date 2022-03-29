using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reputation : MonoBehaviour
{
    public int reputation = 0;
    public float betterPrice;

    public bool tireOne, tireTwo, tireThree, tireFour, tireFive = false;

    public void AddPoints(int points) { reputation += points; }

    public void TireCheck (int ExpectationForTireOne, int ExpectationForTireTwo, int ExpectationForTireThree, int ExpectationForTireFour, int ExpectationForTireFive)
    {
        if (reputation >= ExpectationForTireOne && reputation <= ExpectationForTireTwo) { tireOne = true; }
        if (reputation >= ExpectationForTireTwo && reputation <= ExpectationForTireThree) { tireTwo = true; }
        if (reputation >= ExpectationForTireThree && reputation <= ExpectationForTireFour) { tireThree = true; }
        if (reputation >= ExpectationForTireFour && reputation <= ExpectationForTireFive) { tireFour = true; }
        if (reputation >= ExpectationForTireFive) { tireFive = true; }
    }
     public void TireReset()
    {
        tireOne = false; 
        tireTwo = false; 
        tireThree = false; 
        tireFour = false; 
        tireFive = false;
    }
}
