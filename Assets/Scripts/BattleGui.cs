using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Battle;

public class BattleGui : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer boss;
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
    private EnergyBar energyBar;
    private int state; //0 -> mainMenu, 1 -> attacks 2-> targets auto attack 3-> targets magic attack 4-> targets special 5> lock
    public string[] targets;
    public string[] alliesTargets = { "healer", "scythe", "mage", "tank" };
    private string activatedSpell;
    private string actualTarget;
    private CharacterAnimationSettings[] characters;
    private Dictionary<string, float> beginningpositionCharactersX = new Dictionary<string, float>()
        {
            { "mage", -4.13f},
            { "healer", -6f },
            { "tank", -5.69f },
            { "scythe", -3.93f },
            { "firstTarget", 6.98f },
            { "secondTarget", 6.98f }
        };
    private Dictionary<string, float> beginningpositionCharactersY = new Dictionary<string, float>()
        {
            { "mage", -3.86f},
            { "healer", -3.09f },
            { "tank", -1.01f },
            { "scythe", -2.2f },
            { "firstTarget", -1.48f },
            { "secondTarget", -3.61f }
        };
    private bool shouldChangeScene;
    private float timeToChangeScene;
    private int nextSceneBuildIndex;
    private Image star1;
    private Image star2;
    private Image star3;
    private bool showNewItemText;
    private string newItemAcquired;
    private TextMeshProUGUI newItemAcquiredText;


    void Start()
    {
        showNewItemText = false;
        timeToChangeScene = 5f;
        shouldChangeScene = false;
        if (SceneManager.GetActiveScene().name == "Battlefield26")
        {
            if (GetPlayerName.choice1 != 0 || GetPlayerName.choice2 != 0 || GetPlayerName.choice3 != 0)
            {
                SpriteRenderer bossHp = GameObject.Find("infridRightInStatic/hpBar").GetComponent<SpriteRenderer>();
                bossHp.transform.localScale = new Vector2(2000f, bossHp.transform.localScale.y);
            }
        }
        activatedSpell = "";
        actualTarget = "";
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
        energyBar = GameObject.Find("Canvas/energyComponent/energyBarBackground/lackEnergyBar").GetComponent<EnergyBar>();

        star1 = GameObject.Find("Canvas/star1").GetComponent<Image>();
        star2 = GameObject.Find("Canvas/star2").GetComponent<Image>();
        star3 = GameObject.Find("Canvas/star3").GetComponent<Image>();

        setAllStars(false);

        newItemAcquiredText = GameObject.Find("Canvas/newItemText").GetComponent<TextMeshProUGUI>();
        newItemAcquiredText.text = "";
        newItemAcquiredText.gameObject.SetActive(false);

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

    private void setAllStars(bool isActive)
    {
        star1.gameObject.SetActive(isActive);
        star2.gameObject.SetActive(isActive);
        star3.gameObject.SetActive(isActive);
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
        checkIfShiftButtonClicked();
        if(shouldChangeScene)
        {
            clearAllButtons();
            if (timeToChangeScene > 0)
            {
                timeToChangeScene -= Time.deltaTime;
                fillStarsWithColor();
            } else
            {
                SceneManager.LoadScene(nextSceneBuildIndex);
            }
        }
        if(GameObject.Find(GetPlayerName.actualPlayer + "RightStatic/hpBar").GetComponent<SpriteRenderer>().transform.localScale.x == 0f) //hide gui when died
        {
            clearAllButtons();
        }
        if (showNewItemText)
        {
            if (newItemAcquiredText.color.a >2f)
            {
                var tempColor = newItemAcquiredText.color;
                tempColor.a = 0f;
                newItemAcquiredText.color = tempColor;
                showNewItemText = false;
            }
            else
            {
                newItemAcquiredText.gameObject.SetActive(true);
                newItemAcquiredText.text = "You have acquired new Item - " + newItemAcquired;
                var tempColor = newItemAcquiredText.color;
                tempColor.a += 0.35f * Time.deltaTime;
                newItemAcquiredText.color = tempColor;
            }
        }
        
    }

    private void fillStarsWithColor()
    {
        setAllStars(true);
        if (timeToChangeScene > 3.33f && alliesTargets.Length >= 2)
        {
            star1.color = new Color(1f, star1.color.g - 0.1f * Time.deltaTime, star1.color.b - 0.6f * Time.deltaTime); //green0.82
        }
        else if (timeToChangeScene > 1.67f && alliesTargets.Length >= 3)
        {
            star2.color = new Color(1f, star2.color.g - 0.1f * Time.deltaTime, star2.color.b - 0.6f * Time.deltaTime); //green0.82
        }
        else if (alliesTargets.Length >= 4)
        {
            star3.color = new Color(1f, star3.color.g - 0.1f * Time.deltaTime, star3.color.b - 0.6f * Time.deltaTime); //green0.82
        }
    }

    private void checkIfShiftButtonClicked()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (state == 1)
            {
                getMainBattleChoices();

            }
            else if (state == 2 || state == 3)
            {
                getAttackChoices();
            }
            else if (state == 4)
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

    public void getTargetMenu(bool wasClickedAutoAttacked = true) //default auto attack state
    {
        clearAllButtons();
        if(activatedSpell == "special" && GetPlayerName.actualPlayer == "healer")
        {
            if (alliesTargets.Length == 1)
            {
                changeTarget1Button(true);
                target1Button.Select();
            }
            else if (alliesTargets.Length == 2)
            {
                changeTarget1Button(true);
                changeTarget2Button(true);
                target1Button.Select();
            }
            else if (alliesTargets.Length == 3)
            {
                changeTarget1Button(true);
                changeTarget2Button(true);
                changeTarget3Button(true);
                target1Button.Select();
            }
            else if (alliesTargets.Length == 4)
            {
                changeTarget1Button(true);
                changeTarget2Button(true);
                changeTarget3Button(true);
                changeTarget4Button(true);
                target1Button.Select();
            }
        } else
        {
            if (targets.Length == 1)
            {
                changeTarget1Button(true);
                target1Button.Select();
            }
            else if (targets.Length == 2)
            {
                changeTarget1Button(true);
                changeTarget2Button(true);
                target1Button.Select();
            }
            else if (targets.Length == 3)
            {
                changeTarget1Button(true);
                changeTarget2Button(true);
                changeTarget3Button(true);
                target1Button.Select();
            }
            else if (targets.Length == 4)
            {
                changeTarget1Button(true);
                changeTarget2Button(true);
                changeTarget3Button(true);
                changeTarget4Button(true);
                target1Button.Select();
            }
        }
        
        if(state == 0)
        {
            state = 4;
        } else if(state == 1)
        {
            if(wasClickedAutoAttacked)
            {
                state = 2;
            }
            else
            {
                state = 3;
            }
        }
    }

    public void onAttackButtonClick()
    {
        getAttackChoices();
    }
    public void onSpecialButtonClick()
    {
        activatedSpell = "special";
        getTargetMenu();
    }

    public void onAutoAttackButtonClick()
    {
        activatedSpell = "autoAttack";
        getTargetMenu();
    }

    public void onMagicAttackButtonClick()
    {
        activatedSpell = "magicAttack";
        getTargetMenu(false);
    }

    public void onTarget1ButtonClick()
    {
        energyBar.useSpell();
        if (activatedSpell == "special" && GetPlayerName.actualPlayer == "healer")
        {
            actualTarget = alliesTargets[0];
        } else
        {
            actualTarget = targets[0];
        }
        state = 5;
        clearAllButtons();
    }

    public void onTarget2ButtonClick()
    {
        energyBar.useSpell();
        if (activatedSpell == "special" && GetPlayerName.actualPlayer == "healer")
        {
            actualTarget = alliesTargets[1];
        }
        else
        {
            actualTarget = targets[1];
        }
        state = 5;
        clearAllButtons();
    }

    public void onTarget3ButtonClick()
    {
        energyBar.useSpell();
        if (activatedSpell == "special" && GetPlayerName.actualPlayer == "healer")
        {
            actualTarget = alliesTargets[2];
        }
        else
        {
            actualTarget = targets[2];
        }
        state = 5;
        clearAllButtons();
    }

    public void onTarget4ButtonClick()
    {
        energyBar.useSpell();
        if (activatedSpell == "special" && GetPlayerName.actualPlayer == "healer")
        {
            actualTarget = alliesTargets[3];
        }
        else
        {
            actualTarget = targets[3];
        }
        state = 5;
        clearAllButtons();
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
        if(activatedSpell == "special" && GetPlayerName.actualPlayer == "healer")
        {
            if(alliesTargets.Length > 0)
            {
                target1ButtonText.text = alliesTargets[0];
            }
        }
        else
        {
            if (targets.Length > 0)
            {
                target1ButtonText.text = targets[0];
            }
        }
    }

    public void changeTarget2Button(bool enable)
    {
        target2Button.gameObject.SetActive(enable);
        if (activatedSpell == "special" && GetPlayerName.actualPlayer == "healer")
        {
            if (alliesTargets.Length > 1)
            {
                target2ButtonText.text = alliesTargets[1];
            }
        }
        else
        {
            if (targets.Length > 1)
            {
                target2ButtonText.text = targets[1];
            }
        }
    }

    public void changeTarget3Button(bool enable)
    {
        target3Button.gameObject.SetActive(enable);
        if (activatedSpell == "special" && GetPlayerName.actualPlayer == "healer")
        {
            if (alliesTargets.Length > 2)
            {
                target3ButtonText.text = alliesTargets[2];
            }
        }
        else
        {
            if (targets.Length > 2)
            {
                target3ButtonText.text = targets[2];
            }
        }
    }

    public void changeTarget4Button(bool enable)
    {
        target4Button.gameObject.SetActive(enable);
        if (activatedSpell == "special" && GetPlayerName.actualPlayer == "healer")
        {
            if (alliesTargets.Length > 3)
            {
                target4ButtonText.text = alliesTargets[3];
            }
        }
        else
        {
            if (targets.Length > 3)
            {
                target4ButtonText.text = targets[3];
            }
        }
    }

    private bool isTargetAlly (string target)
    {
        return target == "healer" || target == "mage" || target == "scythe" || target == "tank";
    }

    private int getCharacterIndex ()
    {
        if(activatedSpell == "autoAttack")
        {
            if(GetPlayerName.actualPlayer == "mage")
            {
                return 0;
            } else if(GetPlayerName.actualPlayer == "healer")
            {
                return 1;
            } else if(GetPlayerName.actualPlayer == "scythe")
            {
                return 2;
            } else if(GetPlayerName.actualPlayer == "tank")
            {
                return 3;
            }
        } else if(activatedSpell == "magicAttack")
        {
            if (GetPlayerName.actualPlayer == "mage")
            {
                return 4;
            }
            else if (GetPlayerName.actualPlayer == "healer")
            {
                return 5;
            }
            else if (GetPlayerName.actualPlayer == "scythe")
            {
                return 6;
            }
            else if (GetPlayerName.actualPlayer == "tank")
            {
                return 7;
            }
        } else if(activatedSpell == "special")
        {
            if (GetPlayerName.actualPlayer == "mage")
            {
                return 8;
            }
            else if (GetPlayerName.actualPlayer == "healer")
            {
                return 9;
            }
            else if (GetPlayerName.actualPlayer == "scythe")
            {
                return 10;
            }
            else if (GetPlayerName.actualPlayer == "tank")
            {
                return 11;
            }
        }
        return 19;
    }

    private int getCharacterAnimationIndex()
    {
        if (GetPlayerName.actualPlayer == "mage")
        {
            return 12;
        }
        else if (GetPlayerName.actualPlayer == "healer")
        {
            return 13;
        }
        else if (GetPlayerName.actualPlayer == "scythe")
        {
            return 14;
        }
        else if (GetPlayerName.actualPlayer == "tank")
        {
            return 15;
        }
        return 19;
    }

    public void selectAnimtion()
    {
        int characterIndex = getCharacterIndex();
        CharacterAnimationSettings character = new CharacterAnimationSettings();
        if(activatedSpell == "special" && isTargetAlly(actualTarget))
        {
            character.fromPositionX = GameObject.Find(actualTarget + "RightStatic").transform.position.x;
            character.fromPositionY = GameObject.Find(actualTarget + "RightStatic").transform.position.y + 8.2f;
            character.toPositionX = GameObject.Find(actualTarget + "RightStatic").transform.position.x;
            character.toPositionY = GameObject.Find(actualTarget + "RightStatic").transform.position.y;
        }else if(activatedSpell == "special")
        {
            character.fromPositionX = GameObject.Find(actualTarget).transform.position.x;
            character.fromPositionY = GameObject.Find(actualTarget).transform.position.y + 8.2f;
            character.toPositionX = GameObject.Find(actualTarget).transform.position.x;
            character.toPositionY = GameObject.Find(actualTarget).transform.position.y;
        }
        else
        {
            character.fromPositionX = beginningpositionCharactersX[GetPlayerName.actualPlayer];
            character.fromPositionY = beginningpositionCharactersY[GetPlayerName.actualPlayer];
            character.toPositionX = GameObject.Find(actualTarget).transform.position.x;
            character.toPositionY = GameObject.Find(actualTarget).transform.position.y;
        }


        if (activatedSpell == "autoAttack")
        {
            character.name = GetPlayerName.actualPlayer + activatedSpell;
            GameObject.Find("Canvas/guiScripts").GetComponent<CharactersAnimationFight>().animatespellFight(
               character.name, character.fromPositionX, character.fromPositionY, character.toPositionX, character.toPositionY, characterIndex, actualTarget, true);
        } else if (activatedSpell == "special")
        {
            character.name = GetPlayerName.actualPlayer + activatedSpell;
            GameObject.Find("Canvas/guiScripts").GetComponent<CharactersAnimationFight>().animatespellFight(
               character.name, character.fromPositionX, character.fromPositionY, character.toPositionX, character.toPositionY, characterIndex, actualTarget, true);
        }
        else //magicAttack
        {
            characterIndex = getCharacterAnimationIndex();
            character.name = GetPlayerName.actualPlayer + "RightStatic";
            GameObject.Find("Canvas/guiScripts").GetComponent<CharactersAnimationFight>().animateCharacterFight(
                character.name, character.fromPositionX, character.fromPositionY, character.toPositionX, character.toPositionY, characterIndex);

            characterIndex = getCharacterIndex();
            character.name = GetPlayerName.actualPlayer + activatedSpell;
            character.fromPositionX = GameObject.Find(actualTarget).transform.position.x;
            character.fromPositionY = GameObject.Find(actualTarget).transform.position.y + 12.2f;
            character.toPositionX = GameObject.Find(actualTarget).transform.position.x;
            character.toPositionY = GameObject.Find(actualTarget).transform.position.y;
            GameObject.Find("Canvas/guiScripts").GetComponent<CharactersAnimationFight>().animatespellFight(
               character.name, character.fromPositionX, character.fromPositionY, character.toPositionX, character.toPositionY, characterIndex, actualTarget, true);
        }
    }

    public void targetHit(string target, string spell)
    {
        if (spell.Contains("autoAttack"))
        {
            SpriteRenderer spellObject = GameObject.Find(target + "/hpBar").GetComponent<SpriteRenderer>();
            if(spellObject.transform.localScale.x <= 0.05f)
            {
                spellObject.transform.localScale = new Vector2(0f, spellObject.transform.localScale.y);
                targetDie(target);
            } else
            {
                spellObject.transform.localScale = new Vector2(spellObject.transform.localScale.x - 0.05f, spellObject.transform.localScale.y);
            }
        } else if(spell.Contains("magicAttack"))
        {
            SpriteRenderer spellObject = GameObject.Find(target + "/hpBar").GetComponent<SpriteRenderer>();
            if (spellObject.transform.localScale.x <= 0.05f)
            {
                spellObject.transform.localScale = new Vector2(0f, spellObject.transform.localScale.y);
                targetDie(target);
            }
            else
            {
                spellObject.transform.localScale = new Vector2(spellObject.transform.localScale.x - 0.05f, spellObject.transform.localScale.y);
            }
        } else if(spell.Contains("special"))
        {
            if(target == "healer" || target == "scythe" || target == "tank" || target == "mage")
            {
                SpriteRenderer spellObject = GameObject.Find(target + "RightStatic/hpBar").GetComponent<SpriteRenderer>();
                if (spellObject.transform.localScale.x >= 0.75f)
                {
                    spellObject.transform.localScale = new Vector2(0.85f, spellObject.transform.localScale.y);
                }
                else
                {
                    spellObject.transform.localScale = new Vector2(spellObject.transform.localScale.x + 0.1f, spellObject.transform.localScale.y);
                }
            } else
            {
                SpriteRenderer spellObject = GameObject.Find(target + "/hpBar").GetComponent<SpriteRenderer>();
                if (spellObject.transform.localScale.x <= 0.05f)
                {
                    spellObject.transform.localScale = new Vector2(0f, spellObject.transform.localScale.y);
                    targetDie(target);
                }
                else
                {
                    spellObject.transform.localScale = new Vector2(spellObject.transform.localScale.x - 0.05f, spellObject.transform.localScale.y);
                }
            }
        }
    }

    private void getDropFromMob()
    {
        int chance = Random.Range(0, 25);
        if(chance < 25)
        {
            if (GetPlayerName.allItemsNotGathered.Count > 0)
            {
                int randomIndex = Random.Range(0, GetPlayerName.allItemsNotGathered.Count);
                newItemAcquired = (string)GetPlayerName.allItemsNotGathered[randomIndex];
                GetPlayerName.allItemsNotGathered.Remove(newItemAcquired);
                GetPlayerName.allItemsGathered.Add(newItemAcquired);
                showNewItemText = true;
                var tempColor = newItemAcquiredText.color;
                tempColor.a = 0f;
                newItemAcquiredText.color = tempColor;
            }
        }
    }

    private void targetDie(string target)
    {
        targets = targets.Where(val => val != target).ToArray();
        alliesTargets = alliesTargets.Where(val => !target.Contains(val)).ToArray();
        getDropFromMob();
        if(targets.Length == 0) //win
        {
            shouldChangeScene = true;
            if (SceneManager.GetActiveScene().name == "Battlefield26")
            {
                if(GetPlayerName.choice1 == 0 && GetPlayerName.choice2 == 0 && GetPlayerName.choice3 == 0)
                {
                    nextSceneBuildIndex = SceneManager.GetActiveScene().buildIndex + 1; //27
                } else if(GetPlayerName.choice1 != 0)
                {
                    nextSceneBuildIndex = SceneManager.GetActiveScene().buildIndex + 3;//29
                }
                else if (GetPlayerName.choice2 != 0)
                {
                    nextSceneBuildIndex = SceneManager.GetActiveScene().buildIndex + 7;//33
                }
                else if (GetPlayerName.choice3 != 0)
                {
                    nextSceneBuildIndex = SceneManager.GetActiveScene().buildIndex + 5;//31
                }
            } else
            {
                nextSceneBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
            }
        }
        else if(alliesTargets.Length == 0) //lose
        {
            if (SceneManager.GetActiveScene().name == "Battlefield26")
            {
                if (GetPlayerName.choice1 == 0 && GetPlayerName.choice2 == 0 && GetPlayerName.choice3 == 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //27
                }
                else if (GetPlayerName.choice1 != 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3); //29
                }
                else if (GetPlayerName.choice2 != 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7); //33
                }
                else if (GetPlayerName.choice3 != 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5); //31
                }
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }


}
