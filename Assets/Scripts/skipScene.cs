using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skipScene : MonoBehaviour
{
    private List<DateTime> clickTimes = new List<DateTime>();

    // Start is called before the first frame update
    void Start()
    {
        // workaround to always has at least 2 values in collection that on start not triggers double click
        clickTimes.Add(DateTime.MinValue);
        clickTimes.Add(DateTime.MinValue.AddDays(1));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            clickTimes.Add(DateTime.Now);

        if (Input.GetKeyDown(KeyCode.S) || (clickTimes[clickTimes.Count - 1] - clickTimes[clickTimes.Count - 2]).TotalMilliseconds < 200) //S or double click
        {
            if (Photon.Pun.PhotonNetwork.IsMasterClient)
            {
                SaveLoadManager.saveGame();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
