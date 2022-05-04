using System.Collections;
using UnityEngine;

public class FoodStealer : MonoBehaviour
{
    private bool inCombat;
    private CharacterBase m_CharacterBase = new CharacterBase();
    private UIUpdater UI;
    
    private Collider m_Collider;
    public GameObject self;

    bool doOnce;
    private bool doOnceReheal;
    private bool doOnceDamage;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("PlayerAttack") && !doOnceDamage)
        {
            StartCoroutine(TakeHealth());
        }
    }

    IEnumerator TakeHealth()
    {
        inCombat = true;
        m_CharacterBase.health--;
        doOnceDamage = true;
        yield return new WaitForSeconds(1);
        doOnceDamage = false;
    }

    void Dead()
    {
        if (m_CharacterBase.health <= 0 && FoodBox.attackAttempts < 3)
        {
            FoodBox.doOnce = false;
            UI.UpdateTask("They are gone! Time to get more berries.");
            Destroy(self);
        }

        if (FoodBox.attackAttempts >= 3)
        {
            Debug.Log("DIALOG FOR VILLAGE");
            UI.UpdateTask("Lets explore and find the village");
            Tasks.allFoodStealersGone = true;
            Destroy(self);
        }
    }

    private void Start()
    {
        UI = FindObjectOfType<UIUpdater>();
        m_CharacterBase.health = 5;
        m_CharacterBase.healthMax = 5;
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(m_CharacterBase.health);
        if (!inCombat)
        {
            StartCoroutine(StealingLoop());
        }
        else if (m_CharacterBase.health >= 1 && inCombat)
        {
            FollowAttackPlayer.enabled = true;
        }

        if (m_CharacterBase.health <= 0)
        {
            FollowAttackPlayer.enabled = false;
            inCombat = false;
            Dead();
        }

        if (!doOnceReheal)
        {
            StartCoroutine(Reheal());
            doOnceReheal = true;
        }

    }

    IEnumerator StealingLoop()
    {
        if (!doOnce)
        {
            if (FoodBox.storage > 0)
            {
                FoodBox.storage -= 1;
                if (FoodBox.storage < 0)
                {
                    FoodBox.storage = 0;
                }
            }

            UI.UpdateBerriesBox(FoodBox.storage);
            doOnce = true;
            yield return new WaitForSeconds(2);
            doOnce = false;
        }
        
    }

    IEnumerator Reheal()
    {
        yield return new WaitForSeconds(3);
        if (m_CharacterBase.health < m_CharacterBase.healthMax)
            {
                m_CharacterBase.health++;
            }

            if (m_CharacterBase.health > m_CharacterBase.healthMax)
            {
                m_CharacterBase.health = m_CharacterBase.healthMax;
            }
            doOnceReheal = false;
        
    }
}