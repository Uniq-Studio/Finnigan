using System.Collections;
using NGS.ExtendableSaveSystem;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    public static CharacterBase m_CharacterBase = new CharacterBase();
    private GameMaster m_GM;

    public static Transform m_Transform;
    public GameObject hitBox;
    private bool doOnce;
    public Text healthText;

    [SerializeField] private SO_DialogueData dialogueOne;
    [SerializeField] private SO_DialogueData dialogueTwo;
    private bool doneDialogue2;
    [SerializeField] private SO_DialogueData dialogueThree;
    private bool doneDialogue3;

    [SerializeField] private DialogueSystem m_Dialogue;

    void Start()
    {
        if (GameMaster.triggerLoad)
        {
            m_GM = FindObjectOfType<GameMaster>();
            m_GM.LoadGame();
        }
        else
        {
            m_Dialogue.StartDialogue(dialogueOne.dialogue);
        }
        m_CharacterBase.health = 10;
        m_CharacterBase.healthMax = 10;
    }
    

    void Update()
    {
        if (Tasks.checkedFood && !doneDialogue2)
        {
            m_Dialogue.StartDialogue(dialogueTwo.dialogue); 
            doneDialogue2 = true;
        }

        if (Tasks.allFoodStealersGone && !doneDialogue3)
        {
            m_Dialogue.StartDialogue(dialogueThree.dialogue);
            doneDialogue3 = true;
        }

        healthText.text = "Health: " + m_CharacterBase.health;
        if (!doOnce)
        {
            StartCoroutine(ReGenHealth());
            doOnce = true;
        }
        

        if (m_CharacterBase.health <= 0)
        {
            Dead();
        }

        m_Transform = transform;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            hitBox.gameObject.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            hitBox.gameObject.SetActive(false);
        }
    }

    void Dead()
    {
        //Restart Level from Last Save;
        Debug.LogError("YOU DIED!");
    }

    IEnumerator ReGenHealth()
    {
        yield return new WaitForSeconds(5);
        if (m_CharacterBase.health < m_CharacterBase.healthMax)
        {
            m_CharacterBase.health++;
        }
        else if (m_CharacterBase.health > m_CharacterBase.healthMax)
        {
            m_CharacterBase.health = m_CharacterBase.healthMax;
        }

        doOnce = false;
    }
}
