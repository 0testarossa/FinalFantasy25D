﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Battle;

public class AIEnemy : MonoBehaviour
{
    private float timeToNextAttack;
    public float timeBetweenAttacks = 8f;
    // Start is called before the first frame update
    void Start()
    {
        timeToNextAttack = timeBetweenAttacks;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToNextAttack > 0)
        {
            timeToNextAttack -= Time.deltaTime;
        }
        else
        {
            int characterIndex = getCharacterIndex();
            string[] alliesTargets = GameObject.Find("Canvas/guiScripts").GetComponent<BattleGui>().alliesTargets;
            string actualTarget = alliesTargets[Random.Range(0, alliesTargets.Length)] + "RightStatic";
            CharacterAnimationSettings character = new CharacterAnimationSettings();
            character.name = this.name + "autoAttack";
            character.fromPositionX = this.transform.position.x;
            character.fromPositionY = this.transform.position.y;
            character.toPositionX = GameObject.Find(actualTarget).transform.position.x;
            character.toPositionY = GameObject.Find(actualTarget).transform.position.y;
            timeToNextAttack = timeBetweenAttacks;
            GameObject.Find("Canvas/guiScripts").GetComponent<CharactersAnimationFight>().animatespellFight(
               character.name, character.fromPositionX, character.fromPositionY, character.toPositionX, character.toPositionY, characterIndex, actualTarget);
        }
    }

    private int getCharacterIndex ()
    {
         if(this.name == "infridLeftInStatic")
        {
            return 16;
        }
         else if(this.name == "infridRightInStatic")
        {
            return 17;
        }
        return 19;
    }
}
