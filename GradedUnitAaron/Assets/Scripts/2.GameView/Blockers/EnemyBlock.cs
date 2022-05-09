using System.Collections;
using System.Collections.Generic;
using NGS.ExtendableSaveSystem;
using UnityEngine;

public class EnemyBlock : MonoBehaviour
{
    private UIUpdater UI;
    private GameMaster m_GM;

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
            transform.localPosition += new Vector3(0, -200, 0);
            if (!GameMaster.triggerLoad)
                m_GM.SaveGame();
        }

        if (transform.position.y <= -90)
        {
            Destroy(self);
        }
    }

    void Start()
    {
        UI = FindObjectOfType<UIUpdater>();
        m_GM = FindObjectOfType<GameMaster>();
    }
}
