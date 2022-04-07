using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : CharacterBase
{
    public static bool HasStick = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    //Ends Game when has Item
    //For now it goes to the Main Menu
    void OnTriggerEnter(Collider collider)
    {
        if (HasStick && collider.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            MainMenu.gameOver = true;
            SceneManager.LoadScene(0);
        }
    }
}
