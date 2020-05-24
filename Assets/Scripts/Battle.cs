using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    [Serializable]
    public class CharacterAnimationSettings
    {
        public string name;
        public float fromPositionX;
        public float fromPositionY;
        public float toPositionX;
        public float toPositionY;
    }

    public int fromDialogPage;
    public int toDialogPage;
    public string scriptToChangeScene;
    private int currentImportantStepIndex;
    [SerializeField] public CharacterAnimationSettings[] characters;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
          //(this.GetComponent(scriptToChangeScene) as MonoBehaviour).enabled = true;
    }

    public void triggerAnimation()
    {
        string[] charactersName = new string[characters.Length];
        float[] fromPositionX = new float[characters.Length];
        float[] fromPositionY = new float[characters.Length];
        float[] toPositionX = new float[characters.Length];
        float[] toPositionY = new float[characters.Length];
        int iterator = 0;
        //foreach (CharacterAnimationSettings character in imortantSteps[currentImportantStepIndex].characters)
        //{
        //    charactersName[iterator] = character.name;
        //    fromPositionX[iterator] = character.fromPositionX;
        //    fromPositionY[iterator] = character.fromPositionY;
        //    toPositionX[iterator] = character.toPositionX;
        //    toPositionY[iterator] = character.toPositionY;
        //    iterator++;
        //}
        //this.GetComponent<CharacterAnimationBattle>().animateCharacter(charactersName, 10f, fromPositionX, fromPositionY, toPositionX, toPositionY);
        currentImportantStepIndex++;
    }
}
