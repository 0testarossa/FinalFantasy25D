using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    public class CharacterAnimationSettings
    {
        public string name;
        public float fromPositionX;
        public float fromPositionY;
        public float toPositionX;
        public float toPositionY;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void triggerAnimation(CharacterAnimationSettings[] characters)
    {
        string[] charactersName = new string[characters.Length];
        float[] fromPositionX = new float[characters.Length];
        float[] fromPositionY = new float[characters.Length];
        float[] toPositionX = new float[characters.Length];
        float[] toPositionY = new float[characters.Length];
        int iterator = 0;
        foreach (CharacterAnimationSettings character in characters)
        {
            charactersName[iterator] = character.name;
            fromPositionX[iterator] = character.fromPositionX;
            fromPositionY[iterator] = character.fromPositionY;
            toPositionX[iterator] = character.toPositionX;
            toPositionY[iterator] = character.toPositionY;
            iterator++;
        }
        //this.GetComponent<CharactersAnimationFight>().animateCharacterFight(charactersName, fromPositionX, fromPositionY, toPositionX, toPositionY, 1);
    }
}
