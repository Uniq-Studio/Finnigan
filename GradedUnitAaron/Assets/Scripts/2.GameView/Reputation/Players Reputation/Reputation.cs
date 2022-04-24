using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reputation : MonoBehaviour
{
    public static int reputation = 3;

    //Create tires for better items
    public bool tireOne, tireTwo, tireThree, tireFour, tireFive = false;

    public void AddPoints(int points) { reputation += points; }
}
