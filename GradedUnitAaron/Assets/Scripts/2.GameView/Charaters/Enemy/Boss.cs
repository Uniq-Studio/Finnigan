using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public static bool HasStick = false;
    private CharacterBase m_CharacterBase = new CharacterBase();
    private TriggerSystem m_TriggerSystem = new TriggerSystem();

    private bool unlocked;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Tasks.allComplete)
        {
            unlocked = true;
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        m_TriggerSystem.Interact(EndGame, collider);
    }

    //Ends Game when has Item
    //For now it goes to the Main Menu
    void EndGame()
    {
        if (HasStick && unlocked)
        {
            Debug.Log("Game Over");
            MainMenu.gameOver = true;
            SceneManager.LoadScene(0);
        }
    }


}
