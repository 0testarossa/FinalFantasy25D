using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChoice : MonoBehaviour
{
    private SpriteRenderer choice1;
    private SpriteRenderer choice2;
    private SpriteRenderer choice3;
    // Start is called before the first frame update
    void Start()
    {
        choice3 = GameObject.Find("library").GetComponent<SpriteRenderer>();
        choice2 = GameObject.Find("City3").GetComponent<SpriteRenderer>();
        choice1 = GameObject.Find("Forest").GetComponent<SpriteRenderer>();
        if(GetPlayerName.choice2 == 0)
        {
            choice2.gameObject.SetActive(false);
            choice3.gameObject.SetActive(false);
        } else if(GetPlayerName.choice2 == 1)
        {
            choice1.gameObject.SetActive(false);
            choice3.gameObject.SetActive(false);
        } else if(GetPlayerName.choice2 == 2)
        {
            choice2.gameObject.SetActive(false);
            choice1.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
