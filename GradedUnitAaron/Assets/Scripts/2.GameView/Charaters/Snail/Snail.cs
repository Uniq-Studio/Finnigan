using System.Collections;
using UnityEngine;

public class Snail : MonoBehaviour
{
    public GameObject m_gameObject;
    public Rigidbody m_Rigidbody;
    private bool m_CloseToHelp = false;
    private int m_RepPoints = 10;
    private Reputation m_Reputation;
    private SoundEffects m_SoundEffects;
    private TriggerSystem m_triggerSystem = new TriggerSystem();
    private void Help()
    {
        StartCoroutine(HelpExecute());
    }

    private IEnumerator HelpExecute()
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
        Tasks.helpedSnail = true;
        //Destroy actor
        Destroy(m_gameObject);
    }

    // Start is called before the first frame update
    private void Start()
    {
        m_Reputation = FindObjectOfType<Reputation>();
        m_SoundEffects = FindObjectOfType<SoundEffects>();
    }

    #region Check if player Is close

    private void OnTriggerEnter(Collider collider)
    {
        m_triggerSystem.Interact(Help, collider);
    }

    #endregion Check if player Is close
}

/*
 * Because of the new Visual Studio Update of
 * predictive text, I look up what VS recommends
 * and look at the documentation from Unity. For
 * example, the Quaternion was a recommend, so I
 * checked the documentation to see what it needed.
 */