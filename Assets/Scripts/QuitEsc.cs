using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuitEsc : MonoBehaviour
{
    private Button quitYesButton;
    private Button quitNoButton;
    private TextMeshProUGUI QuitQuestion;

    // Start is called before the first frame update
    void Start()
    {
        quitYesButton = GameObject.Find("Canvas/QuitComponent/QuitYesButton").GetComponent<Button>();
        quitNoButton = GameObject.Find("Canvas/QuitComponent/QuitNoButton").GetComponent<Button>();
        QuitQuestion = GameObject.Find("Canvas/QuitComponent/QuitQuestionText").GetComponent<TextMeshProUGUI>();

        quitYesButton.onClick.AddListener(delegate { onQuitYesButtonClick(); });
        quitNoButton.onClick.AddListener(delegate { onQuitNoButtonClick(); });

        quitYesButton.gameObject.SetActive(false);
        quitNoButton.gameObject.SetActive(false);
        QuitQuestion.gameObject.SetActive(false);
    }

    private void onQuitYesButtonClick()
    {
        Application.Quit();
    }

    private void onQuitNoButtonClick()
    {
        quitYesButton.gameObject.SetActive(false);
        quitNoButton.gameObject.SetActive(false);
        QuitQuestion.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitYesButton.gameObject.SetActive(true);
            quitNoButton.gameObject.SetActive(true);
            QuitQuestion.gameObject.SetActive(true);
        }
    }
}
