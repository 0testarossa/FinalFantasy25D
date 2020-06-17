using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Battle;

public class AIDps : MonoBehaviour
{
    private float timeToNextAttack;
    public float timeBetweenAttacks = 6f;
    private string[] allSpells;
    private bool notDead;
    private SpriteRenderer hpBar;
    private bool notBot;
    // Start is called before the first frame update
    void Start()
    {
        hpBar = GameObject.Find(this.name + "/hpBar").GetComponent<SpriteRenderer>();
        notDead = true;
        allSpells = new string[3] { "autoAttack", "magicAttack", "special" };
        timeToNextAttack = timeBetweenAttacks;
        if (this.name.Contains(GetPlayerName.actualPlayer))
        {
            notBot = true;
        }
        else
        {
            notBot = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!notBot && notDead)
        {
            prepareForAttack();
            if (hpBar.transform.localScale.x == 0f)
            {
                notDead = false;
            }
        }

    }

    private void prepareForAttack()
    {
        if (timeToNextAttack > 0)
        {
            timeToNextAttack -= Time.deltaTime;
        }
        else if (GameObject.Find("Canvas/guiScripts").GetComponent<BattleGui>().targets.Length > 0)
        {
            string activatedSpell = allSpells[Random.Range(0, 3)];
            int characterIndex = getCharacterIndex(activatedSpell);
            string[] alliesTargets = GameObject.Find("Canvas/guiScripts").GetComponent<BattleGui>().alliesTargets;
            string[] targets = GameObject.Find("Canvas/guiScripts").GetComponent<BattleGui>().targets;
            string actualTarget = "";

            if (this.name.Contains("healer") && activatedSpell == "special")
            {
                actualTarget = alliesTargets[Random.Range(0, alliesTargets.Length)] + "RightStatic";
            }
            else
            {
                actualTarget = targets[Random.Range(0, targets.Length)];
            }


            CharacterAnimationSettings character = new CharacterAnimationSettings();
            character.name = getCharacterClassName(this.name) + activatedSpell;

            if (activatedSpell == "special")
            {
                character.fromPositionX = GameObject.Find(actualTarget).transform.position.x;
                character.fromPositionY = GameObject.Find(actualTarget).transform.position.y + 8.2f;
                character.toPositionX = GameObject.Find(actualTarget).transform.position.x;
                character.toPositionY = GameObject.Find(actualTarget).transform.position.y;
            }
            else
            {
                character.fromPositionX = this.transform.position.x;
                character.fromPositionY = this.transform.position.y;
                character.toPositionX = GameObject.Find(actualTarget).transform.position.x;
                character.toPositionY = GameObject.Find(actualTarget).transform.position.y;
            }

            if (activatedSpell == "special" || activatedSpell == "autoAttack")
            {
                GameObject.Find("Canvas/guiScripts").GetComponent<CharactersAnimationFight>().animatespellFight(
              character.name, character.fromPositionX, character.fromPositionY, character.toPositionX, character.toPositionY, characterIndex, actualTarget);
            }
            else if (activatedSpell == "magicAttack")
            {
                characterIndex = getCharacterAnimationIndex();
                character.name = this.name;
                GameObject.Find("Canvas/guiScripts").GetComponent<CharactersAnimationFight>().animateCharacterFight(
                    character.name, character.fromPositionX, character.fromPositionY, character.toPositionX, character.toPositionY, characterIndex);

                characterIndex = getCharacterIndex(activatedSpell);
                character.name = getCharacterClassName(this.name) + activatedSpell;
                character.fromPositionX = GameObject.Find(actualTarget).transform.position.x;
                character.fromPositionY = GameObject.Find(actualTarget).transform.position.y + 12.2f;
                character.toPositionX = GameObject.Find(actualTarget).transform.position.x;
                character.toPositionY = GameObject.Find(actualTarget).transform.position.y;
                GameObject.Find("Canvas/guiScripts").GetComponent<CharactersAnimationFight>().animatespellFight(
                   character.name, character.fromPositionX, character.fromPositionY, character.toPositionX, character.toPositionY, characterIndex, actualTarget);
            }






            timeToNextAttack = timeBetweenAttacks;
        }
    }

    private string getCharacterClassName (string name)
    {
        if (this.name.Contains("mage"))
        {
            return "mage";
        }
        else if (this.name.Contains("healer"))
        {
            return "healer";
        }
        else if (this.name.Contains("scythe"))
        {
            return "scythe";
        }
        else if (this.name.Contains("tank"))
        {
            return "tank";
        }
        return "";
    }

    private int getCharacterIndex(string activatedSpell)
    {
        if (activatedSpell == "autoAttack")
        {
            if (this.name.Contains("mage"))
            {
                return 0;
            }
            else if (this.name.Contains("healer"))
            {
                return 1;
            }
            else if (this.name.Contains("scythe"))
            {
                return 2;
            }
            else if (this.name.Contains("tank"))
            {
                return 3;
            }
        }
        else if (activatedSpell == "magicAttack")
        {
            if (this.name.Contains("mage"))
            {
                return 4;
            }
            else if (this.name.Contains("healer"))
            {
                return 5;
            }
            else if (this.name.Contains("scythe"))
            {
                return 6;
            }
            else if (this.name.Contains("tank"))
            {
                return 7;
            }
        }
        else if (activatedSpell == "special")
        {
            if (this.name.Contains("mage"))
            {
                return 8;
            }
            else if (this.name.Contains("healer"))
            {
                return 9;
            }
            else if (this.name.Contains("scythe"))
            {
                return 10;
            }
            else if (this.name.Contains("tank"))
            {
                return 11;
            }
        }
        return 19;
    }

    private int getCharacterAnimationIndex()
    {
        if (this.name.Contains("mage"))
        {
            return 12;
        }
        else if (this.name.Contains("healer"))
        {
            return 13;
        }
        else if (this.name.Contains("scythe"))
        {
            return 14;
        }
        else if (this.name.Contains("tank"))
        {
            return 15;
        }
        return 19;
    }

    private bool isTargetAlly(string target)
    {
        return target.Contains("healer") || target.Contains("mage") || target.Contains("scythe") || target.Contains("tank");
    }
}
