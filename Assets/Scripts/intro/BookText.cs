using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BookText : MonoBehaviour
{
    private Text textComponent;
    private Text textComponent2;
    private bool showNextText;
    private int fromDialogPage;
    private int toDialogPage;
    private int currentDialogPage;
    private bool canSkipText;
    private IEnumerator coroutine;
    private string[] plot = {"In this story there are heroes that we need, but didn't deserve. For a long time they've been protecting peace and free-market economy in the lands of infrids",
        "During their adventures, heroes in party developed bond so strong that together they were able to overcome every hardship. Arent you bored of this story yet? Doesn't matter if you are reviewer of this production or not, lets dig deeper.",
        "Remains of this old photo show friendly and dim-witted creatures: Infrids. They're able to use basic magic but due to their lack of intelligence they can't become great mages. In fact they are too stupid to be aggressive.",
        "Who are the heroes? Healer: Only female character in the game... so that no one would accuse us of chauvinism (that's not true). She mastered the art of offensive magic... not really, she can only use one spell. She can scratch those who oppose her with her long nails. She has also ability to heal people (suprise).",
        "Scythe: Many identify him as agile, psychopatic murderer. Well, they are right. His main role is to deal damage. He also knows one magic attack. His super-power is no less bound to the scythe than he is. ",
        "Mage: He was always bright but poor weak in the mage school. Sport scholarship was far out of his range. Due to the fact that math wasn't his strong side, he focused on training his magic. His favourite spell is white energy ball, that he throws at enemies. Although he knows many powerful spells, he's so obsessed over white energy ball that he only uses it and basic attack. When he gets angry he uses his cane to hit people heads.",
        "Tank- According to data he has load capacity of 4.5 tons, he himself weighs around 22 tons but he's not fat, he has thick plating. Caliber 120mm same as plating thickness. He likes to bring destruction over distant targets with his cannons while listening to classical music. He rams his opponents with brutal force. To not remain inferior he taught himself one magic ability. ",
        "Now that you know something about our party and world... time for you to shape your tale. Let the story begin!\n\n\n" + 
        "Yesterday is a history \n"+
        "Tomorrow is a mystery \n" +
        "But today is a gift \n" +
        "That is why it's called the present \n" +
        "                     -Master Oogway"
     };

    // Start is called before the first frame update
    void Start()
    {
        fromDialogPage = 0;
        toDialogPage = plot.Length - 1;
        canSkipText = false;
        textComponent = GameObject.Find("TextLeft").GetComponent<Text>();
        textComponent.text = "";
        textComponent2 = GameObject.Find("TextRight").GetComponent<Text>();
        textComponent2.text = "";
        showNextText = true;
        currentDialogPage = fromDialogPage;
        coroutine = AnimateText(plot[currentDialogPage]);
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
                coroutine = AnimateText(plot[currentDialogPage]);
                showNextText = true;
            }
            else
            {
                SceneManager.LoadScene("UsernameScene");
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
            if(currentDialogPage % 2 == 0)
            {
                textComponent.text = str;
            } else
            {
                textComponent2.text = str;
            }
            yield return new WaitForSeconds(0.04f);
        }
        yield return null;
    }
}
