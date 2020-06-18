using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetworkEventHandler : MonoBehaviour, IOnEventCallback
{
    public static readonly byte AnimateCharacter = 1;
    public static readonly byte AnimateSpell = 2;
    
    public void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;
        object[] data = (object[])photonEvent.CustomData;
        
        if (eventCode == AnimateCharacter)
        {
            GameObject.Find("Canvas/guiScripts").GetComponent<CharactersAnimationFight>().animateCharacterFight(
                (string) data[0], (float) data[1], (float) data[2], (float) data[3], (float) data[4], (int) data[5]);
        }else if (eventCode == AnimateSpell)
        {
            bool last = false;
            if (data.Length == 8)
                last = (bool) data[7];
            GameObject.Find("Canvas/guiScripts").GetComponent<CharactersAnimationFight>().animatespellFight(
                (string) data[0], (float) data[1], (float) data[2], (float) data[3],
                (float) data[4], (int) data[5], (string) data[6], last);
        }
    }
}
