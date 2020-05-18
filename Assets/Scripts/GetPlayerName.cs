using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetPlayerName : MonoBehaviour
{
    private static string player1 = "mage";
    private static string player2 = "healer";
    private static string player3 = "scythe";
    private static string player4 = "tank";
    public static string[] plot = {
        "It's already ten o'clock. I wanted to wake up at eight, eh... " + player2 + " will be mad at me again. I need to eat breakfast fast and then go and find her. ",
        "Hopefully, she forgot about our meeting.",
        "Wait",
        "No way. She always remembers.",//3
        "...", //4
        "It's better if I go there without even eating.",
        "Where is she? ",
        "Hop hop?",
        "" + player2 +"?",
        "...", //9
        "What is that?! The house is burning! Is someone there? ",//10
        "...",
        "P3: There is no one there.",
        "P1: Oh, P3! What happened?!",
        "P3: You didn't see that?",
        "P1: If I did, would I ask?",//15
        "P3: ...",
        "P3: ok",
        "P3: You're right.",
        "P1: What happened ...",
        "P3: Ifrids came.",//20
        "P1: Ifrids? Do you mean those adorable creatures from the forest?",
        "P3: Adorable?",
        "P3: ...",
        "P3: I wouldn't say.",
        "P1: ?", //25
        "P3: They came and burnt it. And not only that...",
"P1: Not only? What's more?",
"P3: They ...",
"P3: (drept)",
"P3: They ...", //30
"P3: (drept)",
"P3: They tried to burn even more, but luckily our army was here and they decided to escape. ",
"P1: It sounds unbelievable. Are you sure we're still talking about the same adorable Ifrids?",
"P3: If you throw away the word adorable and add something that sounds like cursed instead, then yes.",
"P1: ...", //35
"P3: ...",
"P3: Okey, it's not a time for a talk like that. I really need to talk to P2. I can't find her and I'm scared that something bad happened to her.",
"P1: Don't worry, she's a very strong cleric. No one can ever match her in heavenly magic. God is taking good care of her.",
"P3: If you say so...",
"P3: Still I need to find her. Would you help me?", //40
"P1: Yeah, sure. I was looking for her as well so we have the same plan for now. Let's go!",
"(drept drept oboje)",
"P2: Go away! ",
"P1: It's her!",
"P3: Quick!", //45
"(drept drept oboje szybko)",
"P2: I said GO AWAY! ",
"P2: What did you not understand?",
"P4: You can't be here now. They're after you.",
"P2:  Yes of course. And maybe they can fly as well? Stop joking around P4. I'm done talking with you.", //50
"P4: You need to understand your position. ",
"P2: I understand it better than you do. Can you stop following me?",
"P4: ...",
"P2: ...",
"P2: It's annoying.", //55
"P4: You need to...",
"P2: I don't need anything. Just stop that already.",
"P4: P1! P3! Good timing. Could you give me a hand and convince P2 that she's in danger?",
"P1: In danger?",
"P3: In danger?", //60
"P2: ...",
"P1: What do you mean?",
"P3: Infrids went crazy. I don't know details but it has something in common with P2 magic.",
"P2: Phew! It doesn't! What a stupid suspicion. ",
"P2: You don't believe him, right?", //65
"P1: I...",
"P3: Of course not! I believe in you, my princess.",
"P1: ...",
"P4: ...",
"P2: At least one of you is not that stupid. ", //70
"P1: Wait.",
"P1: What was that noise?",
"P4: Noise?",
"P1: Yeah, something like...",
"P3: Infrids!", //75
"P1: Yeah.",
"P1: How did you know?",
"P3: Just look behind and ...",
"(spogląda)",
"P1: Infrids! What are you doing here?", //80
"Infrids: We're here to get our revenge. Just give it her to us.",
"P1: Her?",
"P1: You mean P2?",
"Infrids: Exactly.",
"P1: About what revenge are you talking about?", //85
"Infrids: Stop acting like an idiot. We don't have much time.",
"P1: Idiot? It wasn't nice of you. ",
"Infrids: If you don't want to cooperate then die!",
"P1: Wait",
"P1: ...", //90
"P1: What?!",
"P4: You heard them. We need to fight.",
"P1: No. You must be joking right now.",
"P4:  Even so, it doesn't look like they either.",
"P3: Let's defend ourselves.", //95
"P4: Stay behind me!",
"P2: I'll support you guys.",
"P1: Wha... Whaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaat?!"

    };
    private InputField txt_Input;
    private Button button;
    private string ObjectsText;
    private float timeToChangeScene;
    private Boolean shouldBegin;
    public GameObject BlackScreen;
    // Start is called before the first frame update
    void Start()
    {
        txt_Input = GameObject.Find("UserName").GetComponent<InputField>();
        button = GameObject.Find("Button").GetComponent<Button>();
        shouldBegin = false;

        button.onClick.AddListener(delegate { onButtonClick(); });
        txt_Input.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        timeToChangeScene = 5.5f;
    }

    public void ValueChangeCheck()
    {
        //Debug.Log("name");
        //Debug.Log(txt_Input.text);
        //ObjectsText = txt_Input.text;

        //SceneManager.LoadScene(1);

    }

    public void onButtonClick()
    {
        PlayerPrefs.SetString("playerName", txt_Input.text);
        PlayerPrefs.SetString("playerName2", "healer");
        PlayerPrefs.SetString("playerName3", "scythe");
        PlayerPrefs.SetString("playerName4", "tank");
        shouldBegin = true;
        (this.GetComponent("FadeOut") as MonoBehaviour).enabled = true;
        BlackScreen.SetActive(true);

        //timerPref = PlayerPrefs.GetInt("playerName");
    }

    void Update()
    {
        if(shouldBegin)
        {
            timeToChangeScene -= Time.deltaTime;
            if (timeToChangeScene <= 0)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
