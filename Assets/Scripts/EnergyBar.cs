using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    private Image lackEnergyBar;
    private float time;
    private float fillAmout;
    private bool canUseSpell;
    private bool playerAcceptedSpell;

    // Start is called before the first frame update
    void Start()
    {
        playerAcceptedSpell = false;
        time = 2.5f;
        fillAmout = 1 / time;
        lackEnergyBar = GameObject.Find("Canvas/energyComponent/energyBarBackground/lackEnergyBar").GetComponent<Image>();
        lackEnergyBar.fillAmount = 1;
        canUseSpell = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            lackEnergyBar.fillAmount -= fillAmout * Time.deltaTime;
            time -= Time.deltaTime;
        }
        else if (!canUseSpell)
        {
            canUseSpell = true;
        }
        if(playerAcceptedSpell && canUseSpell)
        {
            usedSpell();
            GameObject.Find("Canvas/guiScripts").GetComponent<BattleGui>().selectAnimtion();
            playerAcceptedSpell = false;
            //can animate from battle gui    tzn. energybar -> battlegui -> animacja(character)??

        }
    }

    public void useSpell()
    {
        playerAcceptedSpell = true;
    }

    public void usedSpell()
    {
        lackEnergyBar.fillAmount = 1;
        canUseSpell = false;
        time = 2.5f;
    }
}
