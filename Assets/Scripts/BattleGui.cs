using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleGui : MonoBehaviour
{
    // Start is called before the first frame update
    private Button attackButton;
    private Button specialButton;
    private Button autoAttackButton;
    private Button magicAttackButton;
    private Button target1Button;
    private Button target2Button;
    private Button target3Button;
    private Button target4Button;
    private TextMeshProUGUI attackButtonText;
    private TextMeshProUGUI specialButtonText;
    private TextMeshProUGUI autoAttackButtonText;
    private TextMeshProUGUI magicAttackButtonText;
    private TextMeshProUGUI target1ButtonText;
    private TextMeshProUGUI target2ButtonText;
    private TextMeshProUGUI target3ButtonText;
    private TextMeshProUGUI target4ButtonText;
    private int state; //0 -> mainMenu, 1 -> attacks 2-> targets attack 3-> targets special 4-> locked
    public string[] targets;
    
    void Start()
    {
        state = 0;
        attackButton = GameObject.Find("Canvas/AttackButton").GetComponent<Button>();
        specialButton = GameObject.Find("Canvas/SpecialButton").GetComponent<Button>();
        autoAttackButton = GameObject.Find("Canvas/AutoAttackButton").GetComponent<Button>();
        magicAttackButton = GameObject.Find("Canvas/MagicAttackButton").GetComponent<Button>();
        target1Button = GameObject.Find("Canvas/target1Button").GetComponent<Button>();
        target2Button = GameObject.Find("Canvas/target2Button").GetComponent<Button>();
        target3Button = GameObject.Find("Canvas/target3Button").GetComponent<Button>();
        target4Button = GameObject.Find("Canvas/target4Button").GetComponent<Button>();

        attackButtonText = GameObject.Find("Canvas/AttackButton/AttackButtonText").GetComponent<TextMeshProUGUI>();
        specialButtonText = GameObject.Find("Canvas/SpecialButton/SpecialButtonText").GetComponent<TextMeshProUGUI>();
        autoAttackButtonText = GameObject.Find("Canvas/AutoAttackButton/AutoAttackButtonText").GetComponent<TextMeshProUGUI>();
        magicAttackButtonText = GameObject.Find("Canvas/MagicAttackButton/MagicAttackButtonText").GetComponent<TextMeshProUGUI>();
        target1ButtonText = GameObject.Find("Canvas/target1Button/target1ButtonText").GetComponent<TextMeshProUGUI>();
        target2ButtonText = GameObject.Find("Canvas/target2Button/target2ButtonText").GetComponent<TextMeshProUGUI>();
        target3ButtonText = GameObject.Find("Canvas/target3Button/target3ButtonText").GetComponent<TextMeshProUGUI>();
        target4ButtonText = GameObject.Find("Canvas/target4Button/target4ButtonText").GetComponent<TextMeshProUGUI>();

        attackButton.onClick.AddListener(delegate { onAttackButtonClick(); });
        specialButton.onClick.AddListener(delegate { onSpecialButtonClick(); });
        autoAttackButton.onClick.AddListener(delegate { onAutoAttackButtonClick(); });
        magicAttackButton.onClick.AddListener(delegate { onMagicAttackButtonClick(); });
        target1Button.onClick.AddListener(delegate { onTarget1ButtonClick(); });
        target2Button.onClick.AddListener(delegate { onTarget2ButtonClick(); });
        target3Button.onClick.AddListener(delegate { onTarget3ButtonClick(); });
        target4Button.onClick.AddListener(delegate { onTarget4ButtonClick(); });

        clearAllButtons();
        getMainBattleChoices();
    }

    public void clearAllButtons()
    {
        changeAutoAttackButton(false);
        changeMagicAttackButton(false);
        changeTarget1Button(false);
        changeTarget2Button(false);
        changeTarget3Button(false);
        changeTarget4Button(false);
        changeAttackButton(false);
        changeSpecialButton(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (state == 1)
            {
                getMainBattleChoices();

            } else if(state == 2)
            {
                getAttackChoices();
            } else if(state == 3)
            {
                getMainBattleChoices();
            }
        }
    }

    public void getMainBattleChoices()
    {
        clearAllButtons();
        changeAttackButton(true);
        changeSpecialButton(true);
        attackButton.Select();
        state = 0;
    }

    public void getAttackChoices()
    {
        clearAllButtons();
        changeAutoAttackButton(true);
        changeMagicAttackButton(true);
        autoAttackButton.Select();
        state = 1;
    }

    public void getTargetMenu()
    {
        clearAllButtons();
        if (targets.Length == 1)
        {
            changeTarget1Button(true);
        } else if(targets.Length == 2)
        {
            changeTarget1Button(true);
            changeTarget2Button(true);
        } else if(targets.Length == 3)
        {
            changeTarget1Button(true);
            changeTarget2Button(true);
            changeTarget3Button(true);
            changeTarget4Button(true);
        } else if(targets.Length == 4)
        {
            changeTarget1Button(true);
            changeTarget2Button(true);
            changeTarget3Button(true);
            changeTarget4Button(true);
        }
        if(state == 0)
        {
            state = 3;
        } else if(state == 1)
        {
            state = 2;
        }
    }

    public void specialChoices()
    {
        getTargetMenu();
        state = 2;
    }

    public void onAttackButtonClick()
    {
        getAttackChoices();
    }
    public void onSpecialButtonClick()
    {
        getTargetMenu();
    }

    public void onAutoAttackButtonClick()
    {
        getTargetMenu();
    }

    public void onMagicAttackButtonClick()
    {
        getTargetMenu();
    }

    public void onTarget1ButtonClick()
    {

    }

    public void onTarget2ButtonClick()
    {

    }

    public void onTarget3ButtonClick()
    {

    }

    public void onTarget4ButtonClick()
    {

    }

    public void changeAttackButton(bool enable)
    {
        attackButton.gameObject.SetActive(enable);
    }

    public void changeSpecialButton(bool enable)
    {
        specialButton.gameObject.SetActive(enable);
    }

    public void changeAutoAttackButton(bool enable)
    {
        autoAttackButton.gameObject.SetActive(enable);
        
    }

    public void changeMagicAttackButton(bool enable)
    {
        magicAttackButton.gameObject.SetActive(enable);
    }

    public void changeTarget1Button(bool enable)
    {
        target1Button.gameObject.SetActive(enable);
        if (targets.Length > 0)
        {
            target1ButtonText.text = targets[0];
        }
        
    }

    public void changeTarget2Button(bool enable)
    {
        target2Button.gameObject.SetActive(enable);
        if (targets.Length > 1)
        {
            target2ButtonText.text = targets[1];

        }
    }

    public void changeTarget3Button(bool enable)
    {
        target3Button.gameObject.SetActive(enable);
        if (targets.Length > 2)
        {
            target3ButtonText.text = targets[2];

        }
    }

    public void changeTarget4Button(bool enable)
    {
        target4Button.gameObject.SetActive(enable);
        if (targets.Length > 3)
        {
            target4ButtonText.text = targets[3];
        }
    }





    //var autoAttackButtonTextColor = autoAttackButtonText.color;
    //autoAttackButtonTextColor.a = alpha;
    //autoAttackButtonText.color = autoAttackButtonTextColor;
    //var autoAttackButtonColor = autoAttackButton.targetGraphic.color;
    //autoAttackButtonColor.a = alpha;
    //autoAttackButton.targetGraphic.color = autoAttackButtonColor;
}
