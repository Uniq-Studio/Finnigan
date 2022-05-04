using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAttackPlayer : MonoBehaviour
{
    public static bool enabled = false;

    private bool doOnce;
    void Update()
    {
        if (enabled)
        {
            if (Vector3.Distance(transform.position, PlayerBase.m_Transform.position) >= 3)
            {
                transform.LookAt(PlayerBase.m_Transform);
                transform.position += transform.forward * 3f * Time.deltaTime;
            }

            if (Vector3.Distance(transform.position, PlayerBase.m_Transform.position) <= 3)
            {
                transform.LookAt(PlayerBase.m_Transform);
                if (!doOnce)
                {
                    StartCoroutine(TakePlayerHealth());
                    doOnce = true;
                }
            }
        }
        
    }

    IEnumerator TakePlayerHealth()
    {
        yield return new WaitForSeconds(1);
        PlayerBase.m_CharacterBase.health--;
        yield return new WaitForSeconds(2);
        doOnce = false;

    }
}
