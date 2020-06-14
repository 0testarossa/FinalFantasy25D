using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetPlayerName : MonoBehaviour
{
    public static string actualPlayer = "healer";
    public static int choice1 = 0;
    public static int choice2 = 0;
    public static int choice3 = 0;
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
"P1: Wha... Whaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaat?!",
"P1: I can't believe it. Not yet.",
"P3: It was...", //100
"P4: Unexpected?",
"P4: I told you all before. They're after P2. Can you at least trust me after that? Is it that difficult to understand what's going on?",
"P2: It doesn't mean anything P4. Of course, I don't deny that the Infrids are crazy. But you should not come to such far-reaching conclusions.",
"P2: You should be by my side P4...",
"P4: I am P2. But I care a lot about you. And that's why you should leave that town.", //105
"P2: No! Stay away from me!",
"P2: I don't even know why I said that from before. Forget about that. Just leave me alone now.",
"P2: All of you. Just LEAVE me now!",
"P1: I'm scared that I can't do what you want. Not after what I saw.",
"P1: Not after that fight. We shouldn't kill Infrids. And the same goes for them. ", //110
"P2: I smell a big hero here... Just do what you want far away from me. Phew!",
"P1: But it's...",
"P4: Calm down. We can just all talk about it and find a solution.",
"P2: Solution?",
"P2: Ah, I know one.", //115
"P2: The one where a big hero and his annoying army is dead since they didn't care what I say!",
"P3: Calm down my sweet princess. No one here wants bad for you.",
"P2: ...",
"P2: No comment.",
"P1: My father knows Infrids very well. When I was a child he was telling me a lot about them. Why not give it a try and ask him if he knows anything about their strange behavior?", //120
"P2: That sounds...",
"P4: Cool. Let's do it.",
"P3: Not a bad idea.",
"P2: If you think that I'll go with you, then you are completely wrong. I'll stay here and nothing will change my mind.",
"P4: No one is asking you about that.", //125
"P2: Cool.",
"P2: Then go and resolve the mystery meanwhile I will stay here with my favorite book.",
"P2: Good luck my big heroes.",
"P2: (waving)",
"P1: P4 what are you...", //130
"P4: Everything is fine. We can begin our little adventure.",
"P3: But our lady...",
"P2: I Will miss you. Don't worry P3. ",
"P2: I believe in you.",
"P4: No need. I take you with me.", //135
"P2: Yes. You take me with...",
"P2: WHAT?!",
"P2: You clearly said before that I don't need to go with you.",
"P2: Don't even try to deny that.",
"P4: I won't, don't worry.", //140
"P4: Indeed, you don't need to go with us.",
"P4: (smiling)",
"P4: But I have never said that I won't take you with me.",
"P2: How dare you!",
"P2: No! Don't even come closer!", //145
"P2: No!",
"P2: Please!",
"P2: Someone help meeeeeeeeeeeeeee!",
"P2: Remind me please again why I even stay here with you.",
"P3: Because we all care about you and don't want anything bad to happen to you again.", //150
"P4: Because I don't care about your opinion anymore.",
"P4: I have to fulfill my mission as the grand master of the Knights Templar. ",
"P2: You all see?",
"P2: He changes his mind more often than any girl that I know.",
"P1: Watch out!", //155
"P3: Not again them! ",
"Infrids: Give us the woman and we will not hurt you.",
"P1: Can we just talk? I don't want bloodshed.",
"Infrids: We're not stupid! We will not let you be possessed!",
"P1: Possessed? But wh...", //160
"Infrids: Die!",
"P1: Aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa!",
"P4: You will thank me later.",
"P1: If there will be any later...",
"P1: (Gulp)", //165
"P1: I don't get it.",
"P1: What do they mean by being possessed?",
"P2: I wouldn't even try to understand those disgusting reptile.",
"P2: Just look at me.",
"P2: I'm looking like a real disaster after that fight.", //170
"P2: I need to wash.",
"P2: And eat something.",
"P2: I'm hungry!",
"P4: And here we are. Your father's house P1.",
"P1: Yeah. I hope he's here.", //175
"P3: Is he a nicer person than Inffrids? I hope so...",
"P2: Hello? Are you listening to me?",
"P1: Yes.",
"P1: He is nice. And I love to talk with him whenever I have free time to visit him.",
"P4: Perfect. Now, all we need is to talk with him about the Ingrids and solve the problem as fast as possible.", //180
"P2: Where is the bathroom?",
"P2: Okey, don't mind me. I'll look for it for myself.",
"P1: But it's really strange. If I remember right, they were always in good relation with people in this town. I don't...",
"P2: Aaaaaaaaaaaaaaaaaaaaaaaa!",
"P3: P2!", //185
"P1: P2!",
"P4: Does it really matter?",
"P3: ...",
"P1: ...",
"P4: All right. ", //190
"P4: Let's rescue this world's failure once more...",
"P2: Phew!",
"P2: Do they never heard about someone's privacy in the bathroom?",
"P3: They live in the forest...",
"P2: ...", //195
"P2: Good point.",
"P1: I'm afraid that the mystery of the mysterious behavior of them will stay as it is because my father isn't even here.",
"P4: No way...",
"P2: Can't be true...",
"P3: So we just need to take our time and wait. How about playing hide and seek?", //200
"P1: It is not as simple as you think it is. I found something important.",
"P4: Important?",
"P4: What is it?",
"P1: The letter that my father wrote to me...",
"P2: Is he greeting us as well?", //205
"P4: ...",
"P4: Just leave it to us.",
"P4: Go and wash, princess.",
"P2: Finally.",
"(drept P2)", //210
"P4: And returning to the right topic, does he mention anything about Infrids?",
"P1: I'm not sure. In the beginning, he is talking about his house and the mystery thing inside it.",
"P4: What is it?",
"P1: I don't know. He described it as something that I will know what is it.",
"P4: It doesn't help much.", //215
"P3: Agree",
"P1: Additionally there is something about saint staff. ",
"P4: Sounds again like the puzzle.",
"P3: And that puzzle is connected with our lady.",
"P1: What makes you say that?", //220
"P3: Oh, come on. Even child would connect those two facts.",
"P3: Our princess is a high priest and so she's using saint stuff like a staff. Does it sound familiar?",
"P1: I'm using staff as well. I don't get your point.",
"P3: But it's not a saint staff. You do not pray to god and not do some other stuff I don't understand at all.",
"P4: That's obvious.", //225
"P3: Told ya.",
"P4: Was talking about...",
"P3: Hm?",
"P4: Eh, nevermind.",
"P1: How about other priests?", //230
"P4: Wasn't she the only one in this town?",
"P3: I think so.",
"P2: Yeah, I am. Why?",
"P1: Do you mind if I try something with that?",
"P2: Don't even dare to touch it!", //235
"P2: It's blessed with good god's energy.",
"(priests house)",
"(After a long...)",
"(After a really long...)",
"(After a really tiring and long time...)", //240
"P2: Not only Infrids don't know what someone's privacy means!",
"P3: Calm down my lady.",
"P3: I didn't see anything terrifying there.",
"P4: Speak for yourself...",
"P1: I feel confused a little.", //245
"P2: How about me? What should I say then?",
"P4: Maybe something like I'm sorry you had to watch this?",
"P1: You were the one who decided to check my wardrobe.",
"P4: What a normal person hides there sha... ",
"P4: (feeling of freezing sight on yourself)", //250
"P4: Just nevermind.",
"P2: How about we go to P4 house, huh?",
"P1: Why would we?",
"P1: (feeling of freezing sight on yourself)",
"P1: Okey, feel free to do it after we resolve the mystery.", //255
"P2: Get your wardrobe ready P4.",
"P3: Maybe it's not important but I found something strange on the floor.",
"P2: Strange? It's just part of my uniform. I'm not sure why it was laying on the floor but... oh wait. ",
"P2: I have my part here so I didn't lose it. What's going on?",
"P3: If you don't need that then...", //260
"P1: She doesn't but I need it.",
"P3: Oh I didn't know you were into that type of stuff, sorry.",
"P1: ...",
"P4: Just ignore it.",
"P1: I'm trying...", //265
"P4: I know...",
"P2: I will not comment.",
"P2: Oh wait... however I will do that.",
"P2: You all...",
"P4: Don't want to hear that after seeing what you have in your wardrobe.", //270
"P2: Phew!",
"P2: Just wait until I see yours.",
"P1: Can you be serious? I'm talking to all of you now.",
"P2: I'm serious about that wardrobe.",
"P1: Just stop that.", //275
"P4: She started it.",
"P2: Like a little child. Go and cry.",
"P2: We don't need people like you here.",
"P4: And that's how she says thanks for rescuing her precious face.",
"P1: BOTH OF YOU GET OUT OF HERE!", //280
"P2: ...",
"P4: ...",
"(P2 i P4 wychodzą)",
"P1: Can you give me that?",
"P1: I want to take a closer look at this.", //285
"P3: Yeah, sure.",
"(drept P3)",
"P1: Just as I thought.",
"P1: This is a fake one...",
"P3: How did you know that?", //290
"P1: The material is different from the one she uses. ",
"P3: Don't say that you opened her wardrobe as well...",
"P1: Shhh.",
"P1: She doesn't need to know that.",
"P3: But why would someone fake a piece of her wardrobe?", //295
"P1: For the same reason as faking the original saint staff.",
"P3: Do you want to say that she has a fake one now?",
"P1: Not sure about that but there is a big chance that Infrids did that while she was taking a shower.",
"P3: But they wanted P2 and not her staff.",
"P1: Maybe they wanted us to think like that.", //300
"P1: I think that we must return to my dad’s library.",
"P1: If I am right then we'll find there something very interesting.",
"P1: (cough)",
"P2: I bet that we'll meet Infrids again guys. Does anyone want to bet?",
"P4: I didn't know you were a gambler P2.", //305
"P2: Phew.",
"P2: You know nothing about me.",
"P4: I wouldn't say the same thing after seeing what you hide inside the wardrobe...",
"P2: It's the proof that you know nothing about me P4.",
"P2: Does anyone want to bet?", //310
"P1: I would appreciate if you would take it serious P2.",
"P2: But I'm serious about that bet.",
"P1: ...",
"P4: ...",
"P2: No one understands my feelings!", //315
"P4: If you only had any...",
"P2: ...",
"P3: Calm down friends. You can't argue like that forever.",
"P2: No worries P3. I'm not arguing.",
"P2: I find facts.", //320
"P3: It's not what ...",
"P4: See? Try to talk with her and you'll understand who is the victim here.",
"P2: Victim?! ",
"P2: Let me show you the situation where you'll be the one then!",
"P4: Go ahead. I'm not scared of you and your divine powers. ", //325
"P4: You're even weaker than Infrids.",
"P2: Say what?!",
"P3: Em...",
"P3: Friends?",
"P1: I'm afraid that it must wait. We have a bigger problem here.", //330
"P2: Nothing is more important than showing this big head where is his place.",
"P3: How about bloodthirsty Infrids in front of us?",
"P2: How many times I need to repeat that Infrids aren't bloodthirsty creatures.",
"P2: They are adorable, cute and...",
"P2: WHAT IS THAT?!", //335
"P3: Your cute little Infrids my lady.",
"P3: Look. They had something with them.",
"P1: Interesting...",
"P4: Why did they have divine crystals with them?",
"P1: Divine crystals? You mean the ones that...", //340
"P2: Yeah. You can destroy the world...",
"P2: and do some other stuff with them if you are know-how.",
"P4: And who will explain to me why I am not surprised that she knows such things.",
"P2: ...",
"P2: Can I...", //345
"P3: No.",
"P1: No.",
"P2: ...",
"P2: Okey.",
"P2: We should take them and look at them closer inside the library. I need to check something if possible.", //350
"P1: And I have to find the thing that my dad mentioned in the letter.",
"P4: Let me read the whole letter then.",
"P3: And I?",
"P3: (sigh)",
"P2: I was right! They're all the same as mine inside the staff. But... how?", //355
"P2: I thought that there are only one green, one blue, and one red crystal. What's going on?",
"P2: They don't look fake and that's the problem.",
"P2: I have already tried to put them inside my staff and it worked as well. It can't be fake.",
"P3: Hello my lady. Is there anything that I can help you with?",
"P2: Oh, hi P3. I was wondering if there is a possibility to connect the crystals. I know that you were studying this subject with me not that long ago and you had a few ideas back then.", //360
"P3: But you called me a stupid idiot and that there is no way it would work...",
"P2: Ah...",
"P2: Mmmm...",
"P2: Forget about that.",
"P3: It's okay. I can try to help you to figure it out.", //365
"P4: My dear...",
"P4: I love you...",
"P4: I miss you...",
"P4: I want to see you...",
"P4: Hope to meet you tomorrow...", //370
"P4: Tomorrow? ",
"P4: ...",
"P4: I only wonder when he wrote this letter.",
"P4: I can't stop thinking about you...",
"P4: ...", //375
"P4: Sounds more like a love letter but I'm not an expert.",
"P3: Hi there.",
"P4: Hi.",
"P3: Is it only my imagination or you look confused?",
"P4: Hm...", //380
"P4: Who knows.",
"P3: Maybe you?",
"P4: ...",
"P4: I wasn't the one who wrote this, okay?",
"P3: I didn't even say that.", //385
"P4: Is it normal to miss your child so much?",
"P3: Depends on parent I think.",
"P3: Why asking?",
"P4: There is no special reason.",
"P4: Anyway there is something strange in this letter.", //390
"P3: What do you mean?",
"P4: According to what I read we should go to the most suspicious place.",
"P3: Is there anything more?",
"P4: Hm...",
"P4: (My love is eternal...)", //395
"P4: Not really.",
"P3: I see.",
"P4: What do you think about this?",
"P3: We don't know details and we can only guess. It doesn't sound good.",
"P4: You're right but three places came to my mind and I'm pretty sure it must be one of them.", //400
"P3: I like your confidence, my friend.",
"P4: This library belongs to a suspicious man. Doesn't that mean that the library is also suspicious?",
"P3: If you think about it like this, it makes logical sense. What's next?",
"P4: When Infrids came crazy they set the house on fire. It makes that place suspicious as well.",
"P3: I wouldn't think about it. Good point.", //405
"P4: The last place we can go to is the forest. I don't need to say that it's suspicious because suspicious Infrids live there, right?",
"P3: Doesn't that make it the most suspicious place of all?",
"P1: It doesn't make sense at all.",
"P1: He said that I will recognize it but it is like a wild-goose chase. ",
"P1: (sigh)", //410
"P1: I will just go and eat my late breakfast. I'm really hungry.",
"P3: Make two sandwiches at once, please.",
"P1: ???",
"P3: You were going to make breakfast so I decided to come.",
"P1: I just have no idea where I can find THAT thing.", //415
"P3: Did you look everywhere?",
"P1: Not yet. This building is really big...",
"P3: Probably not as big as P4 head.",
"P1: What?",
"P3: Nothing. I just remembered the princess's words.", //420
"P1: You don't help...",
"P3: I would help but I'm not you.",
"P1: ...",
"P3: Okay, sorry.",
"P1: Eh, just wonderful ... I spilled it.", //425
"P1: Can you hand me a broom, please?",
"P3: Yeah, sure. ",
"(drept P3 po miotłe)",
"P3: Here you are.",
"P1: Tha... ", //430
"P1: Impossible!",
"P3: Oh come on I also happen to be nice and helpful ...",
"P1: I'm not talking about you.",
"P3: Have you never seen a broom then?",
"P1: It's not a broom. Look closer.", //435
"P3: Hmmm...",
"P3: Impossible!",
"P1: We found it P3!",
"P3: I am glad that I was useful for something.",
"P3: But I have a question. Is it fake or our lady's staff is fake?", //440
"P1: And that is a good question...",
"P3: If I remember right then Ingrids attacked our princess in the bathroom. Is there a chance that they took away the real one?",
"P1: My father wrote in the letter that a fake princess will hold the real staff. ",
"P3: It doesn't make any sense P1.",
"P1: ...", //445
"P1: I know.",
"P3: Is our princess fake? I hope not.",
"P1: And the worst part is that this staff doesn't seem to be fake...",
"I am not sure if we are ready for this.",
"P1: No one is.", //450
"P4: ...",
"P1: But we must end it.",
"P2: I don't know if our decisions were too random ...",
"P3: What decisions?",
"P1: (sigh)", //455
"P2: (sigh)",
"P4: (sigh)",
"P3: Aaa. These decisions...",
"P1: We have to believe in ourselves.",
"P4: I am confident about my decision but I am not so sure about others.", //460
"P2: (icy stare).",
"P4: We don't even know if we've forgotten something.",
"P1: Don't panic. This is the worst thing we could do now.",
"P2: Oh, then I can bet with you about meeting Infrids here?",
"P4: (icy stare).", //465
"P2: It was only a joke P4...",
"P4: I wouldn't be so sure about that...",
"P1: Am I the only one who has a bad feeling about this?",
"P3: Probably not.",
"P3: Last time after P2 attempt to make a bet, Infrids appeared.", //470
"P4: Sounds like trouble.",
"P1: I can even see that trouble.",
"P1: Hey. Can we talk about...",
"Infrids: Attack!",
"P1: Not even a chance to talk, huh?", //475
"P1: I just want to talk to them.",
"P4: We all want...",
"P2: Not really.",
"P1: ???",
"P3: ???", //480
"P4: ???",
"P2: Why should I talk with them?",
"P2: They're trying to kill us...",
"P1: Don't blame them. I am sure someone else is pulling the strings.",
"P2: This is not an explanation ...", //485
"P4: Watch out!",
"P1: Deja Vu?",
"P2: I'm feeling tired...",
"P3: Hold on my precious princess.",
"P2: But I don't want you to die...", //490
"P2: I need to keep my best or...",
"P4: Don't worry. We're all strong and tough enough to protect ourselves.",
"P2: No. I don't want to lose anyone else...",
"P3: My princess...",
"P2: I'm a high priest. I can't watch someone's else death.", //495
"P4: And you were the one who said that don't want to talk with Infrids...",
"P2: That's because I know that... they're cursed and will not listen to us...",
"P4: Cursed? What do you mean?",
"P2: I see it... ",
"P2: I can't explain it...", //500
"P1: Well, we don't have time for it as well. They're coming!",
"P2: I'm feeling...",
"P3: My princess!",
"P2: Don't come! Something strange is... ",
"P4: Stop acting P2.", //505
"P2: Something strange is...",
"P4: It's not funny anymore.",
"P2: Aaaaaaa!",
"Dark P2: Finally!", 
"P1: What happened?!", //510
"P3: My lady!",
"P4: Wait a moment.",
"P4: ...",
"P4: Ahm...", 
"P4: ...", //515
"P4: Wait, what?!",
"Dark P2: I'm free. Feeling so good.",
"P1: Who are you?!",
"Dark P2: I am the real P2.", 
"P2: She's lying!", //520
"P3: Our princess is a good person. You can't fool us!",
"P4: I would think about it...",
"P2: (icy stare).",
"P4: Yeah. P2 is the real one, sorry.", 
"Dark P2: I like you P4. I can give you a chance to stay by my side.", //525
"P4: Sorry Dark P2 but I'm fed up with only one P2. ",
"P4: I could not bear another ...",
"Dark P2: we'll see what you say when all your friends die before your eyes.",
"P4: Not on my shift!", 
"P4: Let's do it, my friends!", //530
"P3: And now you talk with sense.",
"Dark P2: I can't believe that...",
"Dark P2: You're so strong.",
"P2: Of course we are!",
"Dark P2: You could have made so many mistakes and yet you managed to do it.", //535
"P3: Of course we could.",
"P3: But I helped them all to not do any stupid mistake.",
"P2: Who said you helped me out?",
"P1: Well, he helped me a lot. That's true.",
"P2: Talk for yourself. He messed almost everything!", //540
"P3: Who knows what would happen if I wouldn't help you P2.",
"P2: I know.",
"P2: You wouldn't mess everything.",
"Dark P2: You're funny.",
"P2: Who is funny?", //545
"P3: Who is funny?",
"P4: I wouldn't want to disturb you, but it's probably not the time for such talks.",
"Dark P2: It's okay. I surrender, P4.",
"P4: Surrender?",
"P4: You must be joking. You wanted to kill us.", //550
"P4: I won't let you go, witch!",
"P1: Calm down P4.",
"P1: She said that...",
"P4: I know what she said!",
"P4: I won't let her get away with it.", //555
"P2: Wait!",
"(P2 podchodzi do P4)",
"P4: You too?",
"P2: No. It's not like that. I just...",
"P4: Then get out of my way.", //560
"P2: But you can't kill her! She's part of me...",
"P4: What?!",
"P1: What?!",
"P3: I knew it!",
"P2: Really?!", //565
"P3: No. But I wanted to see that face P2.",
"P2: ...",
"P2: Go away.",
"P3: Calm down my lady.",
"P3: I love you just the way you are.", //570
"P4: Can you tell her your feelings at other times?",
"P2: He's not... Eh...",
"P4: What's more important.",
"P4: What did you mean about being one with her?",
"P2: It's a long story...", //575
"P2: Dark P2! You said that you surrender, right?",
"Dark P2: I did. But we can cooperate if you want...",
"P4: Whoa. Two P2 sounds like twice as much trouble.",
"P2: P4!",
"P4: What? I can't even express my opinion anymore?", //580
"P2: It's not that! ",
"P4: Then what?",
"P2: I...",
"P4: Hm?",
"P2: I...", //585
"P2: I won't tell you!",
"P4: And what I expected from her...",
"P2: Dark P2. Prepare yourself!",
"Dark P2: So sad. I really wanted to join you.",
"Dark P2: Just side by side with these handsome men.", //590
"P2: Can you stop whining?",
"P4: Handsome? Who?",
"P2: ...",
"P2: Illusion!",
"(spell cast)", //595
"P1: (cough)",
"P1: What happened?",
"P3: Ouch! My head!",
"P4: Ops, sorry!",
"P3: Oh I can see everything.", //600
"P4: Yeah, me too.",
"P2: Are you all right?",
"P1: What did you do?",
"P2: I connected us.",
"P1: Ah, that's right. You said you wanted to do that.", //605
"P1: Did it succeed?",
"P2: Yes. Now we don't need to worry about anything. ",
"P2: Everything should be back to normal.",
"P1: Look! Infrids are going back to the forest!",
"(tup tup Infrids)", //610
"P2: Yeah. That's how it should be.",
"P3: Does it mean that we saved this town?",
"P4: I think so.",
"P4: Hm...",
"P4: I know that we managed to do that and P2 connected with her dark side but...", //615
"P4: Why did she say something about liking me?",
"P2: (shy)",
"P4: I don't get it. She should be the dark one who wants to kill us all and...",
"P2: Does it really matter? She probably wanted to seduce you and encourage you to go to her side or something like that ...",
"P4: Does it mean...", //620
"P4: I'm the strongest of us?",
"P4: Yeah. That's right. It was that. You're so cool P4. There is no doubt that this is what it is about.",
"P1: Everything is back to normal.",
"P1: But where is my father? I need to find him!",
"P4: Maybe he came back to the library?", //625
"P1: Let's check it!",
"P3: Let's go!",
"(tup tup P1 i P3)",
"P4: P2?",
"P4: Aren't you going with us?", //630
"P2: Me? Ah... I'll join you in a moment. Just need to check something with my staff.",
"P4: All right. Just don't do something stupid!",
"P2: Of course!",
"(tup tup)",
"P2: I'm pretty sure that something went wrong.", //635
"P2: I have bad feelings about this.",
"(feeling dizzy)",
"Dark P2: Ha ha ha! Stupid girl!",
"Dark P2: That feels so good now!",
"Dark P2: I can finally do what I want!", //640
"(tup tup)",
"Dark P2: But first I should use hypnosis so everyone will see just P2.",
"(casting spell)",
"P2: All right. Let the fun begin!",
"(tup tup)", //645
"P4: Oh, P2! What took you so long?",
"P2: Ah... I don't know. Was it really that long?",
"P4: Maybe a little. ",
"P2: P4... I'm so sorry that I was mad at you before. I promise that it won't happen again.",
"P4: What? I'm tired of listening to these stupid jokes.", //650
"P2: I'm not joking! I'm serious P4!",
"P4: Yeah... Like always. P3 can you...",
"P2: (kiss)",
"P4: Wh.. Wh... What?!",
"P2: Do you believe me now?", //655
"P4: It's not like you P2...",
"P2: I just realized that I really like you P4.",
"P1: Oh no! Look at this!",
"P3: It can't be!",
"P4: Do you want to say that...", //660
"P1: Infrids kidnapped my father!",
"P4: It's impossible! We saw that they were going back to the forest and we won against the dark P2 and ...",
"P1: I think that we missed something. And we need to find out what happened.",
"P2: How about splitting in pairs? I can go with P4 and P1 will go with P3.",
"P3: If I could suggest that I would go with you P2.", //665
"P2: Don't worry P3. I think that It'll be better if you go with P1. Last time you helped him, right?",
"P3: I helped you too, my lady...",
"P4: I think that I need to talk to P2. We can split as P2 said.",
"P3: Okay...",
"P1: Then we'll go to the house where we beat Dark P2. P2 and P4 will go to the forest. ", //670
"P1: Any objections?",
"P2: That's fine.",
"P1: Let's find my father!",
"P4: I promise you P1 that I would gladly give my life to find your father.",
"P1: Don't say such scary thing P4.", //675
"P3: We'll find him for sure P1.",
"P1: Yeah... I hope so.",
"P4: Let's go!",
"P3: Good luck!",
"P1: Good... luck.", //680
"(tup tup)",
"P4: All right. So what did you mean when...",
"P2: Shhh. There is no rush P4.",
"P4: But we need to find ...",
"P2: Oh, I don't think so.", //685
"P4: What?",
"P2: You see...",
"Dark P2: I'm not P2!",
"P4: You! What did you do to P2!",
"Dark P2: Just a little trick. You see... ", //690
"Dark P2: I can easily kill her anytime I want now.",
"P4: You won't do that.",
"Dark P2: Really?",
"Dark P2: I wouldn't be so sure.",
"P4: No! Don't kill her!", //695
"P4: What do you want?",
"Dark P2: Your loyalty.",
"P4: You can't...",
"Dark P2: I don't care if she dies.",
"P4: You...", //700
"Dark P2: What's your decision?",
"P4: I won't forgive you!",
"Dark P2: I didn't ask for that.",
"Dark P2: Could you do something for me?",
"P4: As you wish", //705
"The end",
"P2: I'm feeling dizzy.",
"P4: Not now! We need you!",
"P1: P4, protect priestess!",
"P3: Let me do this!", //710
"P1: No, I need you to...",
"Dark P2: You underestimate me.",
"P3: My lady! Come here!",
"P2: I can't. I can't even move!",
"Dark P2: Good. I knew it would end like this.", //715
"P4: There is always something that we can do Dark P2!",
"Dark P2: Show me then your strength, warrior.",
"P2: No! Don't do that P4! We can't win it! I can't...",
"P4: Do not give me orders!",
"P2: But I can't lose you!", //720
"Dark P2: Too late P2. Everyone is gonna die now because of you.",
"P2: No! Please!",
"P3: Protect P2!",
"P1: We can do this!",
"P2: Don't! I messed up! Don't die! We need to back and...", //725
"P4: We can't. Now or never! Let's go!",
"P2: Noooooooooooooooooooooooooooooooooo!",
"(bum!)",
"P2: I told you...",
"that i messed up", //730
"The end",
"P4: Go! We can do that!",
"P3: So close!",
"P2: Fight as you never fought before!",
"P1: This is your end!", //735
"Dark P2: I wouldn't be so sure.",
"P1: I'm feeling exhausted.",
"P2: So do I.",
"P3: The same here.",
"P4: She's like a monster. She doesn't even seem a little bit tired.", //740
"P2: No way... We did all that we needed to do.",
"P1: Her staff is so shiny...",
"P4: Stop raving. We don't have time for this.",
"P1: But it's bright and glowy.",
"P3: Get a grip!", //745
"P2: No! Look! He's right!",
"P4: And we lost her as well.",
"P4: We can do that as the two of us.",
"P4: Don't be afraid now P3!",
"P4: Go!", //750
"P3: ...",
"P4: P3?",
"P3: ...",
"P4: No no no! What's happening!",
"P4: Come on friends! Stop pretending! It's not a time for that!", //755
"Dark P2: I think they don't hear you anymore P4.",
"P4: You.",
"P4: What did you do to them!",
"Dark P2: Me? It wasn't me. How rude...",
"P4: Stop lying to me!", //760
"Dark P2: But it's the truth. I didn't even do a single thing.",
"P4: I won't believe you! ",
"P4: Die!",
"Dark P2: And that's how you treat your savior?",
"P4: As if I would believe you.", //765
"Dark P2: I protected you from this curse.",
"P4: Lier!",
"Dark P2: I care about you P4.",
"P4: Quiet!",
"Dark P2: I can give you a second chance.", //770
"P4: There would be no second chance, demon!",
"Dark P2: I don't feel like to kill you...",
"P4: You don't need to. I'll end it for you.",
"Dark P2: You can't win alone.",
"P4: You don't know it until you try!", //775
"(bum)",
"Dark P2: (sad look)",
"We will have a lot of time now. ",
"The end",
"P4: P1! Hold on!", //780
"P1: I'm trying but some kind of dark energy takes strength from me.",
"P2: I can't do anything about that.",
"P4: We should go back. I have a bad feeling about that place.",
"Dark P2: There is no way to escape P4. ",
"P2: I don't have energy.", //785
"P3: But we can't surrender.",
"P1: One more time! I know that we can do that!",
"P4: I'm trying!",
"P2: We all try!",
"P3: There is something wrong with that place. We should retreat!", //790
"Dark P2: I won't let you do that!",
"P2: I'm your enemy! You need first beat me!",
"P4: No! P2!",
"P3: My lady!",
"P2: Go away! I'll protect you guys!", //795
"P1: No! We lose or win together!",
"Dark P2: How cute. Sadly no one will survive except me.",
"P2: Don't be so sure about that!",
"P3: Together!",
"P4: Now!", //800
"P1: We got it! Or...",
"P2: Nooooooooooooooooo!",
"Dark P2: Yesssss!",
"(bum)",
"I couldn't choose a better place for your funeral.", //805
"The end",

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
