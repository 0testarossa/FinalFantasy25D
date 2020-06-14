using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceGui : MonoBehaviour
{
    private Button choice1Button;
    private Button choice2Button;
    private Button choice3Button;
    private Button choice4Button;
    private TextMeshProUGUI choice1ButtonText;
    private TextMeshProUGUI choice2ButtonText;
    private TextMeshProUGUI choice3ButtonText;
    private TextMeshProUGUI choice4ButtonText;


    private Text choiceText;
    public string[] choices;
    public int choiceGlobalNumber;
    private bool hasShowed;
    // Start is called before the first frame update
    void Start()
    {
        hasShowed = false;
        choice1Button = GameObject.Find("Canvas/ChoiceObject/choice1Button").GetComponent<Button>();
        choice2Button = GameObject.Find("Canvas/ChoiceObject/choice2Button").GetComponent<Button>();
        choice3Button = GameObject.Find("Canvas/ChoiceObject/choice3Button").GetComponent<Button>();
        choice4Button = GameObject.Find("Canvas/ChoiceObject/choice4Button").GetComponent<Button>();
        choice1ButtonText = GameObject.Find("Canvas/ChoiceObject/choice1Button/choice1ButtonText").GetComponent<TextMeshProUGUI>();
        choice2ButtonText = GameObject.Find("Canvas/ChoiceObject/choice2Button/choice2ButtonText").GetComponent<TextMeshProUGUI>();
        choice3ButtonText = GameObject.Find("Canvas/ChoiceObject/choice3Button/choice3ButtonText").GetComponent<TextMeshProUGUI>();
        choice4ButtonText = GameObject.Find("Canvas/ChoiceObject/choice4Button/choice4ButtonText").GetComponent<TextMeshProUGUI>();
        if (choices.Length > 0)
        {
            choice1ButtonText.text = choices[0];
        }
        if(choices.Length > 1)
        {
            choice2ButtonText.text = choices[1];
        }
        if (choices.Length > 2)
        {
            choice3ButtonText.text = choices[2];
        }
        if (choices.Length > 3)
        {
            choice4ButtonText.text = choices[3];
        }

        choiceText = GameObject.Find("Canvas/ChoiceObject/Text").GetComponent<Text>();
        choice1Button.onClick.AddListener(delegate { onChoice1ButtonClick(); });
        choice2Button.onClick.AddListener(delegate { onChoice2ButtonClick(); });
        choice3Button.onClick.AddListener(delegate { onChoice3ButtonClick(); });
        choice4Button.onClick.AddListener(delegate { onChoice4ButtonClick(); });
        choice1Button.gameObject.SetActive(false);
        choice2Button.gameObject.SetActive(false);
        choice3Button.gameObject.SetActive(false);
        choice4Button.gameObject.SetActive(false);
        choiceText.gameObject.SetActive(false);
    }

    private void setGlobalChoice(int choiceIndex)
    {
        if(choiceGlobalNumber == 1)
        {
            GetPlayerName.choice1 = choiceIndex;
        } else if(choiceGlobalNumber == 2)
        {
            GetPlayerName.choice2 = choiceIndex;
        } else if(choiceGlobalNumber == 3)
        {
            GetPlayerName.choice3 = choiceIndex;
        }
    }

    private void onChoice1ButtonClick()
    {
        choice1Button.Select();
        setGlobalChoice(0);
        
    }
    private void onChoice2ButtonClick()
    {
        choice2Button.Select();
        setGlobalChoice(1);

    }
    private void onChoice3ButtonClick()
    {
        choice3Button.Select();
        setGlobalChoice(2);
    }
    private void onChoice4ButtonClick()
    {
        choice4Button.Select();
        setGlobalChoice(3);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Canvas/Text").GetComponent<ShwPlotTextAdvanced>().currentDialogPage == GameObject.Find("Canvas/Text").GetComponent<ShwPlotTextAdvanced>().toDialogPage && !hasShowed)
        {
            hasShowed = true;
            if(choices.Length == 1)
            {
                choice1Button.gameObject.SetActive(true);
                choiceText.gameObject.SetActive(true);
                choice1Button.Select();
            } else if(choices.Length == 2)
            {
                choice1Button.gameObject.SetActive(true);
                choice2Button.gameObject.SetActive(true);
                choiceText.gameObject.SetActive(true);
                choice1Button.Select();
            }
            else if (choices.Length == 3)
            {
                choice1Button.gameObject.SetActive(true);
                choice2Button.gameObject.SetActive(true);
                choice3Button.gameObject.SetActive(true);
                choiceText.gameObject.SetActive(true);
                choice1Button.Select();
            }
            else if (choices.Length == 4)
            {
                choice1Button.gameObject.SetActive(true);
                choice2Button.gameObject.SetActive(true);
                choice3Button.gameObject.SetActive(true);
                choice4Button.gameObject.SetActive(true);
                choiceText.gameObject.SetActive(true);
                choice1Button.Select();
            }
        }
    }
}
