using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NGS.ExtendableSaveSystem
{
    [RequireComponent(typeof(SaveMaster))]
    public class GameMaster : MonoBehaviour
    {
        public static bool triggerLoad;
        public void SaveGame()
        {
            GetComponent<SaveMaster>().Save("Assets/Saves/", "save", ".data");
            Debug.Log("Game saved");
        }

        public void LoadGame()
        {
            GetComponent<SaveMaster>().Load("Assets/Saves/", "save", ".data");
            Debug.Log("Game loaded");
        }

        public void CheckSave()
        {
            GetComponent<SaveMaster>().FileCheck("Assets/Saves/", "save", ".data");
            Debug.Log("Searched for file");
        }

        public void TriggerLoad()
        {
            triggerLoad = true;
            SceneManager.LoadScene(1);
        }
    }
}
