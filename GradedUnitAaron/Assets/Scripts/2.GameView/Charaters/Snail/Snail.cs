using System.Collections;
using UnityEngine;

#region NOTE
/*
	Because of the new Visual Studio Update of
	predictive text, I look up what VS recommends
	and look at the documentation from Unity. For
	example, the Quaternion was a recommend, so I
	checked the documentation to see what it needed.
*/
#endregion

public class Snail : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
		We need to link the REPUTATION
		script, the SOUNDEFFECTS and the
		TRIGGERSYSTEM, making a new
		TRIGGERSYSTEM so it doesn’t affect
		other code.
		We also link the GameObject to self
		to make code easier to understand
		and Rigidbody to flip him over.
		We also created how many points of 
		reputation its worth.
     */
    #endregion

    private Reputation m_Reputation;
    private SoundEffects m_SoundEffects;
    private TriggerSystem m_triggerSystem = new TriggerSystem();

    public GameObject self;
    public Rigidbody m_Rigidbody;

    private int m_RepPoints = 10;
    #endregion

    #region Unity Triggers
    void Start()
    {
        #region Comment
        /*
			We link the object of the REPUTATION
			and SOUNDEFFECT.
         */
        #endregion
        m_Reputation = FindObjectOfType<Reputation>();
        m_SoundEffects = FindObjectOfType<SoundEffects>();
    }

    void OnTriggerEnter(Collider collider)
    {
        #region Comment
        /*
			We called the Interact code with what
			we want to run.
         */
        #endregion
        m_triggerSystem.Interact(Help, collider);
    }
    #endregion

    #region Methods

    #region Help
    #region Comment
    /*
		Interact does not support Coroutine
		so we need to make another method to
		do this for us which will, rotate the
		snail back to normal. Make a sound
		effect for gaining reputation, after
		a second after that we will make
		snail wiggle away. After half a
		second, we gain the points then remove
		the snail.
     */
    #endregion
    void Help()
    {
        StartCoroutine(HelpExecute());
    }

    IEnumerator HelpExecute()
    {
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        m_SoundEffects.GainReputation();

        yield return new WaitForSeconds(1);

        m_Rigidbody.velocity = new Vector3(0, 0, 25f);

        yield return new WaitForSeconds(.5f);

        m_Reputation.AddPoints(m_RepPoints);
        Destroy(self);
    }
    #endregion

    #endregion
}

#region Script Log

#region Creation
/*
 * This file was created on
 * DATE:	UNKNOWN
 * TIME:	UNKNOWN
 * BY:		Aaron Hamilton
 */
#endregion

#region Edit Logs
//Date: Wed, 18 Apr 2022 | Time: 13:32 | Edit by: Aaron Hamilton
#endregion

#region Sources
/* Title:	NONE
 * By:		NONE
 * URL: 	NONE
 */
#endregion
#endregion

//Uniq Studio