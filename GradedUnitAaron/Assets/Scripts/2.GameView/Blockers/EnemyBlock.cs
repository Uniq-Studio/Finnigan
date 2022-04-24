using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlock : MonoBehaviour
{
    private UIUpdater UI;

    public GameObject self;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            UI.UpdateSubTask("Oh you don't want to go there! They were the one's stealing your food!");
        }
    }

    void Update()
    {
        if (Tasks.talkToTheEnemy)
        {
            Destroy(self);
        }
    }

    void Start()
    {
        UI = FindObjectOfType<UIUpdater>();
    }
}
