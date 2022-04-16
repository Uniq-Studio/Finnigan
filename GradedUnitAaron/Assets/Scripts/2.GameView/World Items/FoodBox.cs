using System.Collections;
using UnityEngine;

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
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (getTask)
        {
            m_TriggerSystem.Interact(LowFood, collider);
        }
        else if (!getTask && Berries.berryAmount >= 1)
        {
            storage += Berries.berryAmount;
            Berries.berryAmount = 0;
            UI.UpdateBerries(Berries.berryAmount);
            UI.UpdateBerriesBox(storage);
        }
    }

    private void Start()
    {
        UI = FindObjectOfType<UIUpdater>();
    }


    IEnumerator SpawnStealer()
    {
        yield return new WaitForSeconds(5);
        Vector3 foodStealerLocation = transform.position + new Vector3(0, +2, -5);
        Instantiate(stealerPrefab, foodStealerLocation, transform.rotation);
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