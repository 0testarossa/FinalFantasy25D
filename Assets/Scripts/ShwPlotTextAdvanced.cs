using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;



public class ShwPlotTextAdvanced : MonoBehaviour
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

    [Serializable]
    public class DialogStepSettings
    {
        [SerializeField]public CharacterAnimationSettings[] characters;
        public int stepNumber;
    }

    private Text textComponent;
    private bool showNextText;
    public int fromDialogPage;
    public int toDialogPage;
    private int currentDialogPage;
    private bool canSkipText;
    private IEnumerator coroutine;
    public string scriptToChangeScene;
    private int currentImportantStepIndex;
    [SerializeField]public DialogStepSettings[] imortantSteps;

    // Start is called before the first frame update
    void Start()
    {
        canSkipText = false;
        currentImportantStepIndex = 0;
        textComponent = GameObject.Find("Text").GetComponent<Text>();
        textComponent.text = "";
        showNextText = true;
        currentDialogPage = fromDialogPage;
        coroutine = AnimateText(GetPlayerName.plot[currentDialogPage]);
        if(imortantSteps[currentImportantStepIndex].stepNumber == currentDialogPage)
        {
            triggerAnimation();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (showNextText)
        {
            showNewPlot();
        }

        if (Input.GetKeyDown("space"))
        {
            if (currentDialogPage < toDialogPage)
            {
                canSkipText = true;
                StopCoroutine(coroutine);
                currentDialogPage++;
                if(currentImportantStepIndex < imortantSteps.Length)
                {
                    if (imortantSteps[currentImportantStepIndex].stepNumber == currentDialogPage)
                    {
                        triggerAnimation();
                    }
                }
                coroutine = AnimateText(GetPlayerName.plot[currentDialogPage]);
                showNextText = true;
            }
            else
            {
                (this.GetComponent(scriptToChangeScene) as MonoBehaviour).enabled = true;
            }
        }
    }

    void showNewPlot()
    {
        StartCoroutine(coroutine);
        showNextText = false;
    }

    public IEnumerator AnimateText(string strComplete)
    {
        int i = 0;
        string str = "";
        while (i < strComplete.Length)
        {
            if (canSkipText)
            {
                canSkipText = false;
                //break;
            }
            str += strComplete[i++];
            textComponent.text = str;
            yield return new WaitForSeconds(0.04f);
        }
        yield return null;
    }

    public void triggerAnimation()
    {
        string[] charactersName = new string[imortantSteps[currentImportantStepIndex].characters.Length];
        float[] fromPositionX = new float[imortantSteps[currentImportantStepIndex].characters.Length];
        float[] fromPositionY = new float[imortantSteps[currentImportantStepIndex].characters.Length];
        float[] toPositionX = new float[imortantSteps[currentImportantStepIndex].characters.Length];
        float[] toPositionY = new float[imortantSteps[currentImportantStepIndex].characters.Length];
        int iterator = 0;
        foreach (CharacterAnimationSettings character in imortantSteps[currentImportantStepIndex].characters)
        {
            charactersName[iterator] = character.name;
            fromPositionX[iterator] = character.fromPositionX;
            fromPositionY[iterator] = character.fromPositionY;
            toPositionX[iterator] = character.toPositionX;
            toPositionY[iterator] = character.toPositionY;
            iterator++;
        }
        this.GetComponent<CharacterAnimationCutscenes>().animateCharacter(charactersName, 10f, fromPositionX, fromPositionY, toPositionX, toPositionY);
        currentImportantStepIndex++;
    }
}
