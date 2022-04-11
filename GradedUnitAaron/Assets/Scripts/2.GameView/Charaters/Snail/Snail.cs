using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
    public GameObject m_gameObject;
    int m_RepPoints = 10;
    public Rigidbody m_Rigidbody;

    Reputation m_Reputation;
    SoundEffects m_SoundEffects;
    private TriggerSystem m_triggerSystem;

    private bool m_CloseToHelp = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Reputation = FindObjectOfType<Reputation>();
        m_SoundEffects = FindObjectOfType<SoundEffects>();
        m_triggerSystem = new TriggerSystem();
    }

    void Update()
    {
    }

    void Help()
    {
        StartCoroutine(HelpExecute());
    }

    #region Check if player Is close
    void OnTriggerStay(Collider collider)
    {
        m_triggerSystem.Interact(Help, collider);
    }

    #endregion

    

    IEnumerator HelpExecute()
    {
        //Flip him over
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        m_SoundEffects.GainReputation();
        yield return new WaitForSeconds(1);
        //Run away
        m_Rigidbody.velocity = new Vector3(0, 0, 25f);
        yield return new WaitForSeconds(.5f);
        //Gives you 10 points
        m_Reputation.AddPoints(m_RepPoints);
        //Destroy actor 
        Destroy(m_gameObject);
    }
}
/*
 * Because of the new Visual Studio Update of
 * predictive text, I look up what VS recommends
 * and look at the documentation from Unity. For
 * example, the Quaternion was a recommend, so I
 * checked the documentation to see what it needed.
 */