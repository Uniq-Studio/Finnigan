using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    public static CharacterBase m_CharacterBase = new CharacterBase();

    public static Transform m_Transform;
    public GameObject hitBox;
    private bool doOnce;
    public Text healthText;
    [SerializeField] private SO_DialogueData dialogueOne;
    [SerializeField] private SO_DialogueData dialogueTwo;
    [SerializeField] private SO_DialogueData dialogueThree;

    void Start()
    {
        m_CharacterBase.health = 100;
        m_CharacterBase.healthMax = 100;
    }
    

    void Update()
    {
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
