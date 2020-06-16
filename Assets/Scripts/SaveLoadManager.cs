using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SaveLoadManager
{
    public static void saveGame()
    {
        //zapis sceny 
        PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex);

        //zapis zebranych itemów
        foreach (string item in GetPlayerName.allItemsGathered)
        {
            PlayerPrefs.SetInt(item, 1);
        }

        //zapis zebranych itemów
        foreach (string item in GetPlayerName.allItemsNotGathered)
        {
            PlayerPrefs.SetInt(item+"N", 1);
        }
    }

   
    public static void loadGame()
    {
        GetPlayerName.sceneIndexToRun = PlayerPrefs.GetInt("Scene", 1);

        foreach (string item in GetPlayerName.allItemsInGame)
        {
            if (PlayerPrefs.GetInt(item, 0) == 1)
            {
                GetPlayerName.allItemsGathered.Add(item);
            }
            
        }

        foreach (string item in GetPlayerName.allItemsInGame)
        {
            if (PlayerPrefs.GetInt(item+"N", 0) == 1)
            {
                GetPlayerName.allItemsGathered.Add(item);
            }

        }
    }
}
