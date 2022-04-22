using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class FoodBox : MonoBehaviour
{
    public static int storage;
    public GameObject stealerPrefab;
    private bool getTask = true;
    public static bool doOnce;
    public static int attackAttempts;
    private TriggerSystem m_TriggerSystem = new TriggerSystem();
    private UIUpdater UI;
    private void LowFood()
    {
        UI.UpdateTask("You're low on food, Find bushes and pick the berries! Then drop them in.");
        getTask = false;
        Tasks.checkedFood = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (getTask)
        {
            m_TriggerSystem.Interact(LowFood, collider);
        }
        else if (!getTask && Inventory.berryAmount >= 1)
        {
            storage += Inventory.berryAmount;
            Inventory.berryAmount = 0;
            UI.UpdateBerries(Inventory.berryAmount);
            UI.UpdateBerriesBox(storage);
            Tasks.filledFoodBox = true;
        }
    }

    private void Start()
    {
        UI = FindObjectOfType<UIUpdater>();
    }


    IEnumerator SpawnStealer()
    {
        yield return new WaitForSeconds(5);
        UI.UpdateTask("Oh no, They are stealing your food from your food box!");
        Vector3 foodStealerLocation = transform.position + new Vector3(-2, +1, 0);
        Instantiate(stealerPrefab, foodStealerLocation, Quaternion.Euler(0,90,0));
        attackAttempts++;
    }

    private void Update()
    {
        if (storage >= 10 && attackAttempts <= 2 && !doOnce)
        {
            StartCoroutine(SpawnStealer());
            doOnce = true;
        }

    }
}
//https://answers.unity.com/questions/399924/using-a-custom-rotation-in-instantiate.html