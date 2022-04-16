using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    public Text berries;
    public Text berriesInBox;
    public Text task;

    public GameObject banner;
    
    static bool showBanner;


    private void Update()
    {
        /* If player hits TAB it shows task again */
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            StartCoroutine(DisplayBanner());
        }
    }

    /* Call in berries when player gets them
     * this will help save on resources rather
     * than calling it every frame making the 
     * game a bit more efficient */
    public void UpdateBerries(int amount)
    {
        berries.text = "Berries: " + amount;
    }
    public void UpdateBerriesBox(int amount)
    {
        berriesInBox.text = "In Box: " + amount;
    }

    /* This method get called when a new task is given */
    public void UpdateTask(string includedText)
    {
        task.text = "Task: " + includedText;
        StartCoroutine(DisplayBanner());
    }

    /* Displays it for a few seconds then hides it again 
     * untill its been called again */
    IEnumerator DisplayBanner()
    {
        banner.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        banner.gameObject.SetActive(false);
    }
}
