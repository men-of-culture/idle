using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using Unity.VisualScripting;

public class UpgradeController : MonoBehaviour
{
    public Canvas menuCanvas, upgradeCanvas;
    public int priceMultiplier = 5;

    [SerializeField]
    private GameObject upgradeButton;
    
    [SerializeField]
    private EventSystem eventSystem;

    [SerializeField]
    private TextMeshProUGUI currencyText;
    
    [SerializeField]
    private List<TextMeshProUGUI> upgradeTextObjects;

    [SerializeField]
    private List<string> upgradeNames;
    
    private List<Tuple<TextMeshProUGUI, string>> upgradeList;

    void Start()
    {
        // Set initial currency text
        currencyText.text = PlayerPrefs.GetInt("currency").ToString();

        // Add all upgradeTextObjects and upgradeNames to list,
        // adding directly to tuple upgradeList in inspector didnt work,
        // so we need the text and name fields until we figure it out

        upgradeList = new List<Tuple<TextMeshProUGUI, string>>();

        for (int i = 0; i < upgradeTextObjects.Count; i++)
        {
            upgradeList.Add(new Tuple<TextMeshProUGUI, string>(upgradeTextObjects[i], upgradeNames[i]));
        }
        
        // Refresh all upgrade texts
        foreach (var upgrade in upgradeList)
        {
            upgrade.Item1.text = PlayerPrefs.GetInt(upgrade.Item2).ToString();
        }
    }

    public void Back()
    {
        upgradeCanvas.enabled = false;
        menuCanvas.enabled = true;
        eventSystem.firstSelectedGameObject = upgradeButton;
    }

    // Refresh upgrade if available
    public void RefreshUpgrades(int upgradeListIndex)
    {
        // Find upgrade from index in upgradeList
        var upgrade = upgradeList[upgradeListIndex-1];
        if (!BuyUpgrade(PlayerPrefs.GetInt(upgrade.Item2) * priceMultiplier)) return;
        PlayerPrefs.SetInt(upgrade.Item2, PlayerPrefs.GetInt(upgrade.Item2) + 1);
        upgrade.Item1.text = PlayerPrefs.GetInt(upgrade.Item2).ToString();
    }

    // Attempt to buy clicked upgrade
    private bool BuyUpgrade(int price)
    {
        if (PlayerPrefs.GetInt("currency") >= price)
        {
            PlayerPrefs.SetInt("currency", PlayerPrefs.GetInt("currency") - price);
            currencyText.text = PlayerPrefs.GetInt("currency").ToString();
            return true;
        }
        return false;
    }
}
