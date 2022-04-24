using System.Collections;
using UnityEngine;

public class FoodStealer : MonoBehaviour
{
    
    private bool inCombat = false;
    private CharacterBase m_CharacterBase = new CharacterBase();
    private UIUpdater UI;
    
    private Collider m_Collider;
    public GameObject self;

    bool doOnce;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("PlayerAttack"))
        {
            inCombat = true;
            m_CharacterBase.health--;
        }
    }

    private void Reheal()
    {
        if (m_CharacterBase.health < m_CharacterBase.healthMax)
        {
            m_CharacterBase.health++;
        }
    }

    void AttackPlayer()
    {
        if (Vector3.Distance(transform.position, PlayerBase.m_Transform.position) >= 3)
        {
                transform.LookAt(PlayerBase.m_Transform);
                transform.position += transform.forward * m_CharacterBase.walkSpeed * Time.deltaTime;
        }

        if (Vector3.Distance(transform.position, PlayerBase.m_Transform.position) <= 3)
        { 
            //PlayerBase.m_CharacterBase.health--;
        }
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
        m_CharacterBase.walkSpeed = 2;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!inCombat)
        {
            StartCoroutine(StealingLoop());
        }
        else if (m_CharacterBase.health >= 1 && inCombat)
        {
            AttackPlayer();
        }

        if (m_CharacterBase.health <= 0)
        {
            Dead();
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
}