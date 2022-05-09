using System.Collections;
using System.Collections.Generic;
using NGS.ExtendableSaveSystem;
using UnityEngine;

public class WallBlock : MonoBehaviour
{
    public GameObject self;

    private UIUpdater UI;
    private GameMaster m_GM;

    private bool doOnce;
    private bool canDestroy;
    void Start()
    {
        UI = FindObjectOfType<UIUpdater>();
        m_GM = FindObjectOfType<GameMaster>();
    }

    void Update()
    {
        if (Tasks.allFoodStealersGone && Tasks.filledFoodBoxOver100)
        {
            transform.localPosition += new Vector3(0, -150, 0);
            if (!GameMaster.triggerLoad)
                m_GM.SaveGame();
        }

        if (transform.localPosition.y <= -90)
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
