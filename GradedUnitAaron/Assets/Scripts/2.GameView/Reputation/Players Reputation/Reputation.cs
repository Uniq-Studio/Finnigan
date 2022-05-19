using UnityEngine;

public class Reputation : MonoBehaviour
{
    public static int reputation;

    //Create tires for better items, NOTE IN USE ANYMORE.
    public bool tireOne, tireTwo, tireThree, tireFour, tireFive = false;

    //Adds Points
    public void AddPoints(int points) { reputation += points; }
}
