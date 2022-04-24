using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBlock : MonoBehaviour
{
    public GameObject self;

    private UIUpdater UI;
    private bool doOnce;
    void Start()
    {
        UI = FindObjectOfType<UIUpdater>();
    }

    void Update()
    {
        if (Tasks.allFoodStealersGone && Tasks.filledFoodBoxOver100)
        {
            Destroy(self);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") && !doOnce)
        {
            UI.UpdateSubTask("You shouldn't adventure that far from your cubs!");
            doOnce = true;
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(20);
        doOnce = false;
    }
}
