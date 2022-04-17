using System.Collections;
using UnityEngine;

public class FoodStealer : MonoBehaviour
{
    
    private bool inCombat;
    private AttackSystem m_AttackSystem = new AttackSystem();
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
            PlayerAttacked(collider);
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
        if (inCombat)
        {
            CancelInvoke("Stealing");
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
    }

    void PlayerAttacked(Collider collider)
    {
        if (collider.CompareTag("PlayerAttack"))
        {
            m_CharacterBase.health--;
        }
    }

    void Dead()
    {
        if (m_CharacterBase.health <= 0 && FoodBox.attackAttempts < 3)
        {
            FoodBox.doOnce = false;
            Destroy(self);
        }

        if (FoodBox.attackAttempts >= 3)
        {
            Debug.Log("DIALOG FOR VILLAGE");
            UI.UpdateTask("Lets explore and find the village");
            Destroy(self);
        }
    }

    private void Start()
    {
        UI = FindObjectOfType<UIUpdater>();
        m_AttackSystem = FindObjectOfType<AttackSystem>();
        m_CharacterBase.health = 5;
        m_CharacterBase.healthMax = 5;
        m_CharacterBase.walkSpeed = 2;

        InvokeRepeating("Stealing", 2, 5);
        InvokeRepeating("Reheal", 2, 5);
    }

    private void Stealing()
    {
        if (FoodBox.storage > 0)
        {
            FoodBox.storage -= 10;
            if (FoodBox.storage < 0)
            {
                FoodBox.storage = 0;
            }
        }

        UI.UpdateBerriesBox(FoodBox.storage);
    }

    // Update is called once per frame
    private void Update()
    {
        if (m_CharacterBase.health >= 1)
        {
            AttackPlayer();
        }
        if (m_CharacterBase.health <= 0)
        {
            Dead();
        }
        
    }
}