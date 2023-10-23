using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour
{
    [SerializeField]
    private StringManager stringManager;
    
    public Canvas playeruiCanvas, upgradeCanvas;
    public int priceMultiplier = 5;

    [SerializeField]
    private GameObject upgradeButton;
    
    [SerializeField]
    private EventSystem eventSystem;

    [SerializeField]
    private TextMeshProUGUI mageCurrencyText;

    [SerializeField]
    private TextMeshProUGUI currencyText;
    
    [SerializeField]
    private TextMeshProUGUI mainCurrencyText;

    [SerializeField]
    private TextMeshProUGUI lifetimeKillsText;

    [SerializeField]
    private TextMeshProUGUI longestRunText;

    [SerializeField]
    private TextMeshProUGUI ascensionText;
    
    [SerializeField]
    private List<TextMeshProUGUI> upgradeTextObjects;

    [SerializeField]
    private List<string> upgradeNames;
    
    private List<Tuple<TextMeshProUGUI, string>> upgradeList;

    public Color selectedColor;
    public Color unselectedColor;
    public Image swordIcon;
    public Image helmIcon;
    public Image shieldIcon;
    public TextMeshProUGUI swordContext;
    public TextMeshProUGUI helmContext;
    public TextMeshProUGUI shieldContext;
    public Image swordBuyButtonIcon;
    public Image helmBuyButtonIcon;
    public Image shieldBuyButtonIcon;
    public TextMeshProUGUI swordBuytext;
    public TextMeshProUGUI helmBuytext;
    public TextMeshProUGUI shieldBuytext;
    public Button swordButton;
    public Button helmButton;
    public Button shieldButton;
    public Image swordButtonbg;
    public Image helmButtonbg;
    public Image shieldButtonbg;
    public TextMeshProUGUI npcDmgText;
    public TextMeshProUGUI npcAttspdText;
    public TextMeshProUGUI npcHealthText;
    public TextMeshProUGUI npcArmorText;
    
    void Start()
    {
        // Set initial currency text
        currencyText.text = PlayerPrefs.GetInt(stringManager.currency).ToString();
        mageCurrencyText.text = PlayerPrefs.GetInt(stringManager.currency).ToString();

        // Set initial mainCurrency text
        mainCurrencyText.text = PlayerPrefs.GetInt(stringManager.currency).ToString();

        // Set lifetime kills text
        lifetimeKillsText.text = PlayerPrefs.GetInt(stringManager.lifetimeKills).ToString();

        // set Longest run text
        longestRunText.text = PlayerPrefs.GetInt(stringManager.longestRun).ToString("F0");

        // set ascension
        ascensionText.text = PlayerPrefs.GetInt("ascension").ToString("F0");

        // Add all upgradeTextObjects and upgradeNames to upgradeList
        upgradeList = new List<Tuple<TextMeshProUGUI, string>>();
        for (int i = 0; i < upgradeTextObjects.Count; i++)
        {
            upgradeList.Add(new Tuple<TextMeshProUGUI, string>(upgradeTextObjects[i], upgradeNames[i]));
        }
        
        // Refresh all upgrade texts in upgradeList
        foreach (var upgrade in upgradeList)
        {
            upgrade.Item1.text = PlayerPrefs.GetInt(upgrade.Item2).ToString();
            // temp "show upgrade lvl" fix
            if(upgrade.Item2 == "upgradeOne")
            {
                upgrade.Item1.text = PlayerPrefs.GetInt(upgrade.Item2).ToString();
            }
            if(upgrade.Item2 == "upgradeThree")
            {
                var x = PlayerPrefs.GetInt(upgrade.Item2);
                var y = x-1;
                var z = y/5;
                upgrade.Item1.text = z.ToString();
            }
            if(upgrade.Item2 == "upgradeFour")
            {
                var x = PlayerPrefs.GetInt(upgrade.Item2);
                var y = x-1;
                var z = y/2;
                upgrade.Item1.text = z.ToString();
            }
        }

        var upgradex = upgradeList[0];
        swordBuytext.text = ((PlayerPrefs.GetInt(upgradex.Item2) * priceMultiplier)+5).ToString();
        upgradex.Item1.text = PlayerPrefs.GetInt(upgradex.Item2).ToString();
        upgradex = upgradeList[2];
        helmBuytext.text = ((PlayerPrefs.GetInt(upgradex.Item2) * priceMultiplier)+5).ToString();
        upgradex.Item1.text = (PlayerPrefs.GetInt(upgradex.Item2) / 5).ToString();
        upgradex = upgradeList[3];
        shieldBuytext.text = ((PlayerPrefs.GetInt(upgradex.Item2) * priceMultiplier)+5).ToString();
        upgradex.Item1.text = (PlayerPrefs.GetInt(upgradex.Item2) / 2).ToString();

        // refresh npc icons text
        npcDmgText.text = PlayerPrefs.GetInt(upgradeList[0].Item2).ToString();
        npcAttspdText.text = PlayerPrefs.GetInt(upgradeList[0].Item2).ToString();
        npcHealthText.text = (PlayerPrefs.GetInt(upgradeList[2].Item2)+10).ToString();
        npcArmorText.text = PlayerPrefs.GetInt(upgradeList[3].Item2).ToString();
    }

    public void Back()
    {
        upgradeCanvas.enabled = false;
        playeruiCanvas.enabled = true;
        eventSystem.firstSelectedGameObject = upgradeButton;
    }

    // Refresh upgrade if bought
    public void BuyUpgrade(int upgradeListIndex)
    {
        // Find upgrade from index in upgradeList
        var upgrade = upgradeList[upgradeListIndex];
        var upgradeMultiplier = upgradeListIndex > 1 ? upgradeListIndex == 2 ? 5 : 2 : 1;

        var x = PlayerPrefs.GetInt(upgrade.Item2);
        var y = x/*-1*/;
        var z = y/upgradeMultiplier;

        // temp upgrade text fix
        //if (upgrade.Item2 == "upgradeThree") z = y/5;
        //if (upgrade.Item2 == "upgradeFour") z = y/2;
        
        // Price check
        if (!(PlayerPrefs.GetInt(stringManager.currency) >= (z * priceMultiplier) + 5)) return;
        
        // Pay
        PlayerPrefs.SetInt(stringManager.currency, PlayerPrefs.GetInt(stringManager.currency) - ((z * priceMultiplier)+5));
        currencyText.text = PlayerPrefs.GetInt(stringManager.currency).ToString();
        mainCurrencyText.text = PlayerPrefs.GetInt(stringManager.currency).ToString();
        mageCurrencyText.text = PlayerPrefs.GetInt(stringManager.currency).ToString();
        
        // Upgrade
        PlayerPrefs.SetInt(upgrade.Item2, PlayerPrefs.GetInt(upgrade.Item2) + upgradeMultiplier);
        upgrade.Item1.text = PlayerPrefs.GetInt(upgrade.Item2).ToString();
            
        // temp fix
        upgrade.Item1.text = (z+1).ToString();
        //

        var currencyTextObj = upgradeListIndex > 1 ? upgradeListIndex == 2 ? helmBuytext : shieldBuytext : swordBuytext; 
        currencyTextObj.text = (z * priceMultiplier).ToString();

        // refresh npc icons text
        npcDmgText.text = PlayerPrefs.GetInt(upgradeList[0].Item2).ToString();
        npcAttspdText.text = PlayerPrefs.GetInt(upgradeList[0].Item2).ToString();
        npcHealthText.text = (PlayerPrefs.GetInt(upgradeList[2].Item2)+10).ToString();
        npcArmorText.text = PlayerPrefs.GetInt(upgradeList[3].Item2).ToString();

        var xupgrade = upgradeList[0];
        swordBuytext.text = ((PlayerPrefs.GetInt(xupgrade.Item2) * priceMultiplier)+5).ToString();
        xupgrade = upgradeList[2];
        helmBuytext.text = (((PlayerPrefs.GetInt(xupgrade.Item2) / 5) * priceMultiplier)+5).ToString();
        xupgrade = upgradeList[3];
        shieldBuytext.text = (((PlayerPrefs.GetInt(xupgrade.Item2) / 2) * priceMultiplier)+5).ToString();
    }

    public void SelectSwordUpgrade()
    {
        swordIcon.color = selectedColor;
        helmIcon.color = unselectedColor;
        shieldIcon.color = unselectedColor;

        swordContext.enabled = true;
        helmContext.enabled = false;
        shieldContext.enabled = false;

        swordButton.enabled = true;
        helmButton.enabled = false;
        shieldButton.enabled = false;
        
        swordButtonbg.enabled = true;
        helmButtonbg.enabled = false;
        shieldButtonbg.enabled = false;

        swordBuyButtonIcon.enabled = true;
        helmBuyButtonIcon.enabled = false;
        shieldBuyButtonIcon.enabled = false;
        swordBuytext.enabled = true;
        helmBuytext.enabled = false;
        shieldBuytext.enabled = false;

        var upgrade = upgradeList[0];
        swordBuytext.text = ((PlayerPrefs.GetInt(upgrade.Item2) * priceMultiplier)+5).ToString();
    }
    public void SelectHelmUpgrade()
    {
        swordIcon.color = unselectedColor;
        helmIcon.color = selectedColor;
        shieldIcon.color = unselectedColor;

        swordContext.enabled = false;
        helmContext.enabled = true;
        shieldContext.enabled = false;

        swordButton.enabled = false;
        helmButton.enabled = true;
        shieldButton.enabled = false;

        swordButtonbg.enabled = false;
        helmButtonbg.enabled = true;
        shieldButtonbg.enabled = false;

        swordBuyButtonIcon.enabled = false;
        helmBuyButtonIcon.enabled = true;
        shieldBuyButtonIcon.enabled = false;
        swordBuytext.enabled = false;
        helmBuytext.enabled = true;
        shieldBuytext.enabled = false;

        var upgrade = upgradeList[2];
        helmBuytext.text = ((PlayerPrefs.GetInt(upgrade.Item2) / 5 * priceMultiplier)+5).ToString();
    }
    public void SelectShieldUpgrade()
    {
        swordIcon.color = unselectedColor;
        helmIcon.color = unselectedColor;
        shieldIcon.color = selectedColor;

        swordContext.enabled = false;
        helmContext.enabled = false;
        shieldContext.enabled = true;

        swordButton.enabled = false;
        helmButton.enabled = false;
        shieldButton.enabled = true;

        swordButtonbg.enabled = false;
        helmButtonbg.enabled = false;
        shieldButtonbg.enabled = true;

        swordBuyButtonIcon.enabled = false;
        helmBuyButtonIcon.enabled = false;
        shieldBuyButtonIcon.enabled = true;
        swordBuytext.enabled = false;
        helmBuytext.enabled = false;
        shieldBuytext.enabled = true;

        var upgrade = upgradeList[3];
        shieldBuytext.text = ((PlayerPrefs.GetInt(upgrade.Item2) / 2 * priceMultiplier)+5).ToString();
    }
}
