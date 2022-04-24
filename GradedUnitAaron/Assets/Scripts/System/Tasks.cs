using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    public static bool checkedFood;
    public static bool filledFoodBox;
    public static bool filledFoodBoxOver100;
    public static bool allFoodStealersGone;
    public static bool discoveredVillage;
    public static bool startDefenceOne;
    public static bool startDefenceTwo;
    public static bool startDefenceThree;
    public static bool talkToTheEnemy;

    public static bool allComplete;

    void Update()
    {
        if (FoodBox.storage > 100)
        {
            filledFoodBoxOver100 = true;
        }
    }
}
