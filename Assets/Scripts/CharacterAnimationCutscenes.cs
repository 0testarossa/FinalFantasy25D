using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationCutscenes : MonoBehaviour
{
    private string[] charactersName = { };
    private float time;
    private float[] fromPositionY = { };
    private float[] fromPositionX = { };
    private float[] toPositionY = { };
    private float[] toPositionX = { };
    private int i;
    private string[] previousCharacters = { };
    private SpriteRenderer previousCharacter;
    private SpriteRenderer actualCharacter;
    private SpriteRenderer activatedCharacter;
    private string[] allCharacters = { "mageBack", "mageFront", "mageLeft", "mageRight", "mageFrontStatic", "mageBackStatic", "mageLeftStatic", "mageRightStatic",
        "scytheLeft", "scytheRight", "scytheFront", "scytheBack", "scytheLeftStatic", "scytheRightStatic", "scytheFrontStatic", "scytheBackStatic",
        "healerLeft", "healerRight", "healerFront", "healerBack", "healerLeftStatic", "healerRightStatic", "healerFrontStatic", "healerBackStatic",
        "tankLeft", "tankRight", "tankFront", "tankBack", "tankLeftStatic", "tankRightStatic", "tankFrontStatic", "tankBackStatic",
        "infridBackIn", "infridBack", "infridBackOut", "infridBackStatic", "infridFrontIn", "infridFront", "infridFrontOut", "infridFrontStatic", "infridLeftIn",
        "infridLeft", "infridLeftOut", "infridLeftStatic", "infridRightIn", "infridRight", "infridRightOut", "infridRightStatic", "infridBackInStatic",
        "infridBackOutStatic", "infridFrontInStatic", "infridFrontOutStatic", "infridLeftInStatic", "infridLeftOutStatic", "infridRightInStatic", "infridRightOutStatic"
    };
    private bool isStartFinished = false;
    private bool activateAnimateCharacter = false;
    // Start is called before the first frame update
    void Start()
    {
        foreach (string character in allCharacters)
        {
            if(GameObject.Find(character))
            {
                activatedCharacter = GameObject.Find(character).GetComponent<SpriteRenderer>();
                activatedCharacter.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0f);
            }

            //activatedCharacter.transform.position = new Vector2(0f, -1.24f);
        }
        isStartFinished = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (activateAnimateCharacter)
        {
            activateAnimateCharacter = false;
            activateCharacters(fromPositionX, fromPositionY, charactersName);
        }
        moveCharacters();
    }

    public void moveCharacters()
    {
        int index = 0;
        foreach (string character in charactersName)
        {
            actualCharacter = GameObject.Find(character).GetComponent<SpriteRenderer>();
            if(actualCharacter.transform.position.x != toPositionX[index])
            {
                if(actualCharacter.transform.position.x < toPositionX[index])
                {
                    if ((actualCharacter.transform.position + transform.right * 4 * Time.deltaTime).x <= toPositionX[index])
                    {
                        actualCharacter.transform.position += transform.right * 4 * Time.deltaTime;
                    }
                    else
                    {
                        actualCharacter.transform.position = new Vector2(toPositionX[index], actualCharacter.transform.position.y);
                    }
                } else
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
                    if((actualCharacter.transform.position + transform.up * 4 * Time.deltaTime).y <= toPositionY[index])
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
            if(actualCharacter.transform.position.x == toPositionX[index] && actualCharacter.transform.position.y == toPositionY[index])
            {
                if (!actualCharacter.name.Contains("Static"))
                {
                    string staticCharacter = actualCharacter.name + "Static";
                    if (GameObject.Find(staticCharacter))
                    {
                        string oldCharacterName = actualCharacter.name;
                        actualCharacter.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0f);
                        actualCharacter = GameObject.Find(staticCharacter).GetComponent<SpriteRenderer>();
                        actualCharacter.transform.position = new Vector2(toPositionX[index], toPositionY[index]);
                        actualCharacter.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
                        int specificCharacterIndex = 0;
                        foreach (string specificCharacter in charactersName)
                        {
                            if (specificCharacter == oldCharacterName)
                            {
                                charactersName[specificCharacterIndex] = staticCharacter;
                                break;
                            }
                            specificCharacterIndex++;
                        }
                    }
                }
            }
            index++;
        }
    }

    public void clearCharacters()
    {
        foreach (string character in charactersName)
        {
            previousCharacter = GameObject.Find(character).GetComponent<SpriteRenderer>();
            previousCharacter.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0f);
        }
        this.time = 0;
    }

    public void activateCharacters(float[] fromPositionX, float[] fromPositionY, string[] charactersName)
    {
        int index = 0;
        foreach (string character in charactersName)
        {
            activatedCharacter = GameObject.Find(character).GetComponent<SpriteRenderer>();
            activatedCharacter.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
            activatedCharacter.transform.position = new Vector2(fromPositionX[index], fromPositionY[index]);

            index++;
        }
    }

    public void animateCharacter(string[] charactersName, float time, float[] fromPositionX, float[] fromPositionY, float[] toPositionX, float[] toPositionY)
    {
        clearCharacters();
        this.charactersName = charactersName;
        this.time = time;
        this.fromPositionX = fromPositionX;
        this.fromPositionY = fromPositionY;
        this.toPositionX = toPositionX;
        this.toPositionY = toPositionY;
        if (isStartFinished)
        {
            activateCharacters(fromPositionX, fromPositionY, charactersName);
        }
        else
        {
            activateAnimateCharacter = true;
        }
    }
}
