using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlotText : MonoBehaviour
{
    private Text textComponent;
    private bool showNextText;
    public int fromDialogPage;
    public int toDialogPage;
    private int currentDialogPage;
    private bool canSkipText;
    private IEnumerator coroutine;
    public string scriptToChangeScene;

    // Start is called before the first frame update
    void Start()
    {
        canSkipText = false;
        textComponent = GameObject.Find("Text").GetComponent<Text>();
        textComponent.text = "";
        showNextText = true;
        currentDialogPage = fromDialogPage;
        coroutine = AnimateText(GetPlayerName.plot[currentDialogPage]);
    }

    // Update is called once per frame
    void Update()
    {
        if(showNextText)
        {
            showNewPlot();
        }

        if (Input.GetKeyDown("space"))
        {
            if(currentDialogPage < toDialogPage)
            {
                canSkipText = true;
                StopCoroutine(coroutine);
                currentDialogPage++;
                coroutine = AnimateText(GetPlayerName.plot[currentDialogPage]);
                showNextText = true;
            } else
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
            if(canSkipText)
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
}
