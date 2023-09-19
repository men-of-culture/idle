using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

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
    private TextMeshProUGUI lifetimeKillsText;
    
    [SerializeField]
    private List<TextMeshProUGUI> upgradeTextObjects;

    [SerializeField]
    private List<string> upgradeNames;
    
    private List<Tuple<TextMeshProUGUI, string>> upgradeList;

    void Start()
    {
        // Set initial currency text
        currencyText.text = PlayerPrefs.GetInt("currency").ToString();

        // Set lifetime kills text
        lifetimeKillsText.text = PlayerPrefs.GetInt("lifetimeKills").ToString();

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
        }
    }

    public void Back()
    {
        upgradeCanvas.enabled = false;
        menuCanvas.enabled = true;
        eventSystem.firstSelectedGameObject = upgradeButton;
    }

    // Refresh upgrade if bought
    public void BuyUpgrade(int upgradeListIndex)
    {
        // Find upgrade from index in upgradeList
        var upgrade = upgradeList[upgradeListIndex];
        
        // Price check
        if (!(PlayerPrefs.GetInt("currency") >= PlayerPrefs.GetInt(upgrade.Item2) * priceMultiplier)) return;
        
        // Pay
        PlayerPrefs.SetInt("currency", PlayerPrefs.GetInt("currency") - (PlayerPrefs.GetInt(upgrade.Item2) * priceMultiplier));
        currencyText.text = PlayerPrefs.GetInt("currency").ToString();
        
        // Upgrade
        PlayerPrefs.SetInt(upgrade.Item2, PlayerPrefs.GetInt(upgrade.Item2) + 1);
        upgrade.Item1.text = PlayerPrefs.GetInt(upgrade.Item2).ToString();
    }
}
