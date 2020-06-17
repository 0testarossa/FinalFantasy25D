using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectClassBeforeGame : MonoBehaviour
{
    // Start is called before the first frame update
    private Button healerButton;
    private Button scytheButton;
    private Button mageButton;
    private Button tankButton;
    private SpriteRenderer healer;
    private SpriteRenderer scythe;
    private SpriteRenderer mage;
    private SpriteRenderer tank;

    void Start()
    {
        healerButton = GameObject.Find("Canvas/HealerButton").GetComponent<Button>();
        scytheButton = GameObject.Find("Canvas/ScytheButton").GetComponent<Button>();
        mageButton = GameObject.Find("Canvas/MageButton").GetComponent<Button>();
        tankButton = GameObject.Find("Canvas/TankButton").GetComponent<Button>();

        healer = GameObject.Find("healerFront").GetComponent<SpriteRenderer>();
        scythe = GameObject.Find("scytheFront").GetComponent<SpriteRenderer>();
        mage = GameObject.Find("mageFront").GetComponent<SpriteRenderer>();
        tank = GameObject.Find("tankFront").GetComponent<SpriteRenderer>();

        healerButton.onClick.AddListener(delegate { onHealerButtonClick(); });
        scytheButton.onClick.AddListener(delegate { onScytheButtonClick(); });
        mageButton.onClick.AddListener(delegate { onMageButtonClick(); });
        tankButton.onClick.AddListener(delegate { onTankButtonClick(); });

        clearAllCharacters();
        healer.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onHealerButtonClick()
    {
        clearAllCharacters();
        healer.gameObject.SetActive(true);
        GetPlayerName.actualPlayer = "healer";
    }

    private void onScytheButtonClick()
    {
        clearAllCharacters();
        scythe.gameObject.SetActive(true);
        GetPlayerName.actualPlayer = "scythe";
    }

    private void onMageButtonClick()
    {
        clearAllCharacters();
        mage.gameObject.SetActive(true);
        GetPlayerName.actualPlayer = "mage";
    }

    private void onTankButtonClick()
    {
        clearAllCharacters();
        tank.gameObject.SetActive(true);
        GetPlayerName.actualPlayer = "tank";
    }

    private void clearAllCharacters()
    {
        healer.gameObject.SetActive(false);
        scythe.gameObject.SetActive(false);
        mage.gameObject.SetActive(false);
        tank.gameObject.SetActive(false);
    }
}
