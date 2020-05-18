using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithoutFade : MonoBehaviour
{
    // Start is called before the first frame update
    public int SceneNumber;
    void Start()
    {
        SceneManager.LoadScene(SceneNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
