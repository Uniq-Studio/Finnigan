using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaveOnLaunch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (MainMenu.loadSave == true)
        {
            SaveSystem.LoadData();
        }
        else
        {
            Debug.LogError("Load save isnt true");
        }
    }

}
