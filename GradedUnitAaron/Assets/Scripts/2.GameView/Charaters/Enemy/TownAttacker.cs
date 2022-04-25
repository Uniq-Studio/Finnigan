using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownAttacker : MonoBehaviour
{
    private CharacterBase m_CharacterBase = new CharacterBase();
    private int num;
    private bool combat;

    private bool doOnceReheal;

    void Start()
    {
        m_CharacterBase.walkSpeed = 5;
        m_CharacterBase.health = 10;
        num = Mathf.RoundToInt(Random.Range(1, 6));
        Debug.Log("Im going for " + num);
    }

    void Update()
    {
        if (!combat)
        {
            if (num == 1)
            {
                lookAt(370, 39, 30);
            }
            else if (num == 2)
            {
                lookAt(310, 39, 55);
            }
            else if (num == 3)
            {
                lookAt(290, 39, 35);
            }
            else if (num == 4)
            {
                lookAt(350, 41, 55);
            }
            else if (num == 5)
            {
                lookAt(330, 43, 75);
            }
            else
            {
                Debug.LogError("How did the random gen fall out of its restrictions? " + num);
            }

            transform.position += transform.forward * m_CharacterBase.walkSpeed * Time.deltaTime;
        }
        else
        {
            FollowAttackPlayer.enabled = true;
        }

        if (!doOnceReheal)
        {
            StartCoroutine(Reheal());
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("PlayerAttack"))
        {
            combat = true;
        }
    }
        

    void lookAt(int x, int y, int z)
    {
        transform.LookAt(new Vector3(x, y, z));
    }
    IEnumerator Reheal()
    {
        if (!doOnceReheal)
        {
            if (m_CharacterBase.health < m_CharacterBase.healthMax)
            {
                m_CharacterBase.health++;
            }

            if (m_CharacterBase.health > m_CharacterBase.healthMax)
            {
                m_CharacterBase.health = m_CharacterBase.healthMax;
            }

            doOnceReheal = true;
        }
        yield return new WaitForSeconds(3);
        doOnceReheal = false;

    }
}

