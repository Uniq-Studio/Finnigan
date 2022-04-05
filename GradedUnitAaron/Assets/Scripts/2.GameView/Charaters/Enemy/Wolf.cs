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
        healthCurrent = 100;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (HasStick && collider.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            MainMenu.gameOver = true;
            SceneManager.LoadScene(0);
        }
    }

    public void GotStick()
    {
        HasStick = true;
    }
}
