using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    // Start is called before the first frame update
    private Button ExitButton;
    private Button NextItemButton;
    private TextMeshProUGUI item;
    private TextMeshProUGUI itemDetails;
    private int actualItemIndex;
    void Start()
    {
        actualItemIndex = 0;

        item = GameObject.Find("Canvas/ItemText").GetComponent<TextMeshProUGUI>();
        itemDetails = GameObject.Find("Canvas/ItemDetailsText").GetComponent<TextMeshProUGUI>();

        ExitButton = GameObject.Find("Canvas/ExitButton").GetComponent<Button>();
        NextItemButton = GameObject.Find("Canvas/NextItemButton").GetComponent<Button>();

        ExitButton.onClick.AddListener(delegate { onExitButtonClick(); });
        NextItemButton.onClick.AddListener(delegate { onNextItemButtonClick(); });

        if(GetPlayerName.allItemsGathered.Count > 0)
        {
            item.text = (string)GetPlayerName.allItemsGathered[0];
            itemDetails.text = (string)GetPlayerName.achievementItems[item.text];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void onExitButtonClick ()
    {
        Application.Quit();
    }

    private void onNextItemButtonClick ()
    {
        if (GetPlayerName.allItemsGathered.Count > 1)
        {
            if (actualItemIndex < GetPlayerName.allItemsGathered.Count - 1)
            {
                item.text = (string)GetPlayerName.allItemsGathered[++actualItemIndex];
                itemDetails.text = (string)GetPlayerName.achievementItems[item.text];
            }
            else
            {
                item.text = (string)GetPlayerName.allItemsGathered[0];
                itemDetails.text = (string)GetPlayerName.achievementItems[item.text];
                actualItemIndex = 0;
            }
            
        }
    }
}
