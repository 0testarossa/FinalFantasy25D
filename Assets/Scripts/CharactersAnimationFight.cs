using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersAnimationFight : MonoBehaviour
{
    private string[] charactersName = { };
    private float[] fromPositionY = { };
    private float[] fromPositionX = { };
    private float[] toPositionY = { };
    private float[] toPositionX = { };
    private int i;
    private string[] previousCharacters = { };
    private SpriteRenderer previousCharacter;
    private SpriteRenderer actualCharacter;
    private SpriteRenderer activatedCharacter;
    private SpriteRenderer activatedSpell;
    private string[] allCharacters = {  "mageRightStatic",
         "scytheRightStatic",
        "healerRightStatic",
        "tankRightStatic", 
        "infridBackIn", "infridBack", "infridBackOut", "infridBackStatic", "infridFrontIn", "infridFront", "infridFrontOut", "infridFrontStatic", "infridLeftIn",
        "infridLeft", "infridLeftOut", "infridLeftStatic", "infridRightIn", "infridRight", "infridRightOut", "infridRightStatic", "infridBackInStatic",
        "infridBackOutStatic", "infridFrontInStatic", "infridFrontOutStatic", "infridLeftInStatic", "infridLeftOutStatic", "infridRightInStatic", "infridRightOutStatic"
    };
    private string[] allSpells = {  "healerautoAttack", "mageautoAttack", "scytheautoAttack", "tankautoAttack", "infridLeftInStaticautoAttack",
        "infridRightInStaticautoAttack", "healermagicAttack", "magemagicAttack", "scythemagicAttack", "tankmagicAttack",
        "healerspecial", "magespecial", "scythespecial", "tankspecial"
    };

    private bool[] isGuiActive;
    private bool[] isSpell;
    private string[] target;
    private bool[] isNotBot;
    // Start is called before the first frame update
    void Start()
    {//0 mage 1 healer 2 scythe 3 tank 4 leftInfrid 5 rightInfird 6 automage 7 autohealer 8 autoscythe 9 autotank 10 autoleftInfrid 11 autorightInfrid
        isGuiActive = new bool[100];
        charactersName = new string[20];
        fromPositionX = new float[20];
        fromPositionY = new float[20];
        toPositionX = new float[20];
        toPositionY = new float[20];
        isSpell = new bool[20];
        target = new string[20];
        isNotBot = new bool[20];

        foreach (string spell in allSpells)
        {
            if (GameObject.Find(spell))
            {
                activatedCharacter = GameObject.Find(spell).GetComponent<SpriteRenderer>();
                activatedCharacter.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0f);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        moveCharacters();
    }

    public void moveCharacters()
    {
        int index = 0;
        foreach (string character in charactersName)
        {
            if(character != null)
            {
                actualCharacter = GameObject.Find(character).GetComponent<SpriteRenderer>();
                if (actualCharacter.transform.position.x != toPositionX[index])
                {
                    if (actualCharacter.transform.position.x < toPositionX[index])
                    {
                        if ((actualCharacter.transform.position + transform.right * 4 * Time.deltaTime).x <= toPositionX[index])
                        {
                            actualCharacter.transform.position += transform.right * 4 * Time.deltaTime;
                        }
                        else
                        {
                            actualCharacter.transform.position = new Vector2(toPositionX[index], actualCharacter.transform.position.y);
                        }
                    }
                    else
                    {
                        if ((actualCharacter.transform.position + transform.right * -4 * Time.deltaTime).x >= toPositionX[index])
                        {
                            actualCharacter.transform.position += transform.right * -4 * Time.deltaTime;
                        }
                        else
                        {
                            actualCharacter.transform.position = new Vector2(toPositionX[index], actualCharacter.transform.position.y);
                        }
                    }
                }
                if (actualCharacter.transform.position.y != toPositionY[index])
                {
                    if (actualCharacter.transform.position.y < toPositionY[index])
                    {
                        if ((actualCharacter.transform.position + transform.up * 4 * Time.deltaTime).y <= toPositionY[index])
                        {
                            actualCharacter.transform.position += transform.up * 4 * Time.deltaTime;
                        }
                        else
                        {
                            actualCharacter.transform.position = new Vector2(actualCharacter.transform.position.x, toPositionY[index]);
                        }
                    }
                    else
                    {
                        if ((actualCharacter.transform.position + transform.up * -4 * Time.deltaTime).y >= toPositionY[index])
                        {
                            actualCharacter.transform.position += transform.up * -4 * Time.deltaTime;
                        }
                        else
                        {
                            actualCharacter.transform.position = new Vector2(actualCharacter.transform.position.x, toPositionY[index]);
                        }
                    }
                }
                if (actualCharacter.transform.position.x == toPositionX[index] && actualCharacter.transform.position.y == toPositionY[index] && isGuiActive[index] == false)
                {
                    actualCharacter.transform.position = new Vector2(fromPositionX[index], fromPositionY[index]);
                    toPositionX[index] = fromPositionX[index];
                    toPositionY[index] = fromPositionY[index];
                    if(isNotBot[index])
                    {
                        GameObject.Find("Canvas/guiScripts").GetComponent<BattleGui>().getMainBattleChoices();
                        isGuiActive[index] = true;
                    }
                }
                if(actualCharacter.transform.position.x == toPositionX[index] && actualCharacter.transform.position.y == toPositionY[index] && isSpell[index] &&
                     GameObject.Find(charactersName[index]).GetComponent<SpriteRenderer>().material.color.a == 1f)
                {
                    activatedSpell = GameObject.Find(charactersName[index]).GetComponent<SpriteRenderer>();
                    activatedSpell.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0f);
                    activatedSpell.transform.position = new Vector2(fromPositionX[index], fromPositionY[index]);
                    GameObject.Find("Canvas/guiScripts").GetComponent<BattleGui>().targetHit(target[index], charactersName[index]);
                }
            }
            index++;
        }
    }

    public void animateCharacterFight(string charactersName, float fromPositionX, float fromPositionY, float toPositionX, float toPositionY, int characterIndex,
        bool isNotBot = false)
    {
        this.charactersName[characterIndex] = charactersName;
        this.fromPositionX[characterIndex] = fromPositionX;
        this.fromPositionY[characterIndex] = fromPositionY;
        this.toPositionX[characterIndex] = toPositionX;
        this.toPositionY[characterIndex] = toPositionY;
        this.isGuiActive[characterIndex] = false;
        this.isSpell[characterIndex] = false;
        this.target[characterIndex] = "";
        this.isNotBot[characterIndex] = isNotBot;
    }

    public void animatespellFight(string charactersName, float fromPositionX, float fromPositionY, float toPositionX, float toPositionY, int characterIndex,
        string target, bool isNotBot = false)
    {
        this.charactersName[characterIndex] = charactersName;
        this.fromPositionX[characterIndex] = fromPositionX;
        this.fromPositionY[characterIndex] = fromPositionY;
        this.toPositionX[characterIndex] = toPositionX;
        this.toPositionY[characterIndex] = toPositionY;
        this.isGuiActive[characterIndex] = false;
        this.isSpell[characterIndex] = true;
        this.target[characterIndex] = target;
        this.isNotBot[characterIndex] = isNotBot;

        //show spell on screen and set it's position
        activatedSpell = GameObject.Find(charactersName).GetComponent<SpriteRenderer>();
        activatedSpell.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
        activatedSpell.transform.position = new Vector2(fromPositionX, fromPositionY);
    }
}
