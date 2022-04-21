using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    public static bool checkedFood;
    public static bool filledFoodBox;
    public static bool discoveredVillage;
    public static bool helpedSnail;
    public static bool defenceOne = true;
    public static bool defenceTwo = true;
    public static bool defenceThree = true;

    public static bool allComplete;

    void Update()
    {
        if(checkedFood && filledFoodBox && discoveredVillage && helpedSnail && defenceOne && defenceTwo && defenceThree)
        {
            allComplete = true;
        }
    }
}
