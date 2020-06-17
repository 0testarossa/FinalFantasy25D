using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithoutFade : MonoBehaviour
{
    // Start is called before the first frame update
    private int SceneNumber;
    void Start()
    {
        if (Photon.Pun.PhotonNetwork.IsMasterClient)
        {
            SaveLoadManager.saveGame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
