using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UpgradeController : MonoBehaviour
{
    public Canvas menuCanvas, upgradeCanvas;

    [SerializeField]
    private GameObject upgradeButton;
    
    [SerializeField]
    private EventSystem eventSystem;

    [SerializeField]
    private TextMeshProUGUI upgradeOneText, upgradeTwoText, upgradeThreeText, upgradeFourText, upgradeFiveText, upgradeSixText, upgradeSevenText, upgradeEightText,
     upgradeNineText, upgradeTenText, upgradeElevenText, upgradeTwelveText, upgradeThirteenText, upgradeFourteenText, upgradeFifteenText, upgradeSixteenText, currencyText;

    void Start()
    {
        upgradeOneText.text = PlayerPrefs.GetInt("upgradeOne").ToString();
        upgradeTwoText.text = PlayerPrefs.GetInt("upgradeTwo").ToString();
        upgradeThreeText.text = PlayerPrefs.GetInt("upgradeThree").ToString();
        upgradeFourText.text = PlayerPrefs.GetInt("upgradeFour").ToString();
        upgradeFiveText.text = PlayerPrefs.GetInt("upgradeFive").ToString();
        upgradeSixText.text = PlayerPrefs.GetInt("upgradeSix").ToString();
        upgradeSevenText.text = PlayerPrefs.GetInt("upgradeSeven").ToString();
        upgradeEightText.text = PlayerPrefs.GetInt("upgradeEight").ToString();
        upgradeNineText.text = PlayerPrefs.GetInt("upgradeNine").ToString();
        upgradeTenText.text = PlayerPrefs.GetInt("upgradeTen").ToString();
        upgradeElevenText.text = PlayerPrefs.GetInt("upgradeEleven").ToString();
        upgradeTwelveText.text = PlayerPrefs.GetInt("upgradeTwelve").ToString();
        upgradeThirteenText.text = PlayerPrefs.GetInt("upgradeThirteen").ToString();
        upgradeFourteenText.text = PlayerPrefs.GetInt("upgradeFourteen").ToString();
        upgradeFifteenText.text = PlayerPrefs.GetInt("upgradeFifteen").ToString();
        upgradeSixteenText.text = PlayerPrefs.GetInt("upgradeSixteen").ToString();
        currencyText.text = PlayerPrefs.GetInt("currency").ToString();
    }

    public void Back()
    {
        upgradeCanvas.enabled = false;
        menuCanvas.enabled = true;

        eventSystem.firstSelectedGameObject = upgradeButton;
    }

    // see if upgrade is available

    public void UpgradeOne()
    {
        if (!buyUpgrade(PlayerPrefs.GetInt("upgradeOne") * 5)) return;
        PlayerPrefs.SetInt("upgradeOne", PlayerPrefs.GetInt("upgradeOne") + 1);
        upgradeOneText.text = PlayerPrefs.GetInt("upgradeOne").ToString();
    }

    public void UpgradeTwo()
    {
        if (!buyUpgrade(PlayerPrefs.GetInt("upgradeTwo") * 5)) return;
        PlayerPrefs.SetInt("upgradeTwo", PlayerPrefs.GetInt("upgradeTwo") + 1);
        upgradeTwoText.text = PlayerPrefs.GetInt("upgradeTwo").ToString();
    }

    public void UpgradeThree()
    {
        if (!buyUpgrade(PlayerPrefs.GetInt("upgradeThree") * 5)) return;
        PlayerPrefs.SetInt("upgradeThree", PlayerPrefs.GetInt("upgradeThree") + 1);
        upgradeThreeText.text = PlayerPrefs.GetInt("upgradeThree").ToString();
    }

    public void UpgradeFour()
    {
        if (!buyUpgrade(PlayerPrefs.GetInt("upgradeFour") * 5)) return;
        PlayerPrefs.SetInt("upgradeFour", PlayerPrefs.GetInt("upgradeFour") + 1);
        upgradeFourText.text = PlayerPrefs.GetInt("upgradeFour").ToString();
    }

    public void UpgradeFive()
    {
        if (!buyUpgrade(PlayerPrefs.GetInt("upgradeFive") * 5)) return;
        PlayerPrefs.SetInt("upgradeFive", PlayerPrefs.GetInt("upgradeFive") + 1);
        upgradeFiveText.text = PlayerPrefs.GetInt("upgradeFive").ToString();
    }

    public void UpgradeSix()
    {
        if (!buyUpgrade(PlayerPrefs.GetInt("upgradeSix") * 5)) return;
        PlayerPrefs.SetInt("upgradeSix", PlayerPrefs.GetInt("upgradeSix") + 1);
        upgradeSixText.text = PlayerPrefs.GetInt("upgradeSix").ToString();
    }

    public void UpgradeSeven()
    {
        if (!buyUpgrade(PlayerPrefs.GetInt("upgradeSeven") * 5)) return;
        PlayerPrefs.SetInt("upgradeSeven", PlayerPrefs.GetInt("upgradeSeven") + 1);
        upgradeSevenText.text = PlayerPrefs.GetInt("upgradeSeven").ToString();
    }

    public void UpgradeEight()
    {
        if (!buyUpgrade(PlayerPrefs.GetInt("upgradeEight") * 5)) return;
        PlayerPrefs.SetInt("upgradeEight", PlayerPrefs.GetInt("upgradeEight") + 1);
        upgradeEightText.text = PlayerPrefs.GetInt("upgradeEight").ToString();
    }

    public void UpgradeNine()
    {
        if (!buyUpgrade(PlayerPrefs.GetInt("upgradeNine") * 5)) return;
        PlayerPrefs.SetInt("upgradeNine", PlayerPrefs.GetInt("upgradeNine") + 1);
        upgradeNineText.text = PlayerPrefs.GetInt("upgradeNine").ToString();
    }

    public void UpgradeTen()
    {
        if (!buyUpgrade(PlayerPrefs.GetInt("upgradeTen") * 5)) return;
        PlayerPrefs.SetInt("upgradeTen", PlayerPrefs.GetInt("upgradeTen") + 1);
        upgradeTenText.text = PlayerPrefs.GetInt("upgradeTen").ToString();
    }

    public void UpgradeEleven()
    {
        if (!buyUpgrade(PlayerPrefs.GetInt("upgradeEleven") * 5)) return;
        PlayerPrefs.SetInt("upgradeEleven", PlayerPrefs.GetInt("upgradeEleven") + 1);
        upgradeElevenText.text = PlayerPrefs.GetInt("upgradeEleven").ToString();
    }

    public void UpgradeTwelve()
    {
        if (!buyUpgrade(PlayerPrefs.GetInt("upgradeTwelve") * 5)) return;
        PlayerPrefs.SetInt("upgradeTwelve", PlayerPrefs.GetInt("upgradeTwelve") + 1);
        upgradeTwelveText.text = PlayerPrefs.GetInt("upgradeTwelve").ToString();
    }

    public void UpgradeThirteen()
    {
        if (!buyUpgrade(PlayerPrefs.GetInt("upgradeThirteen") * 5)) return;
        PlayerPrefs.SetInt("upgradeThirteen", PlayerPrefs.GetInt("upgradeThirteen") + 1);
        upgradeThirteenText.text = PlayerPrefs.GetInt("upgradeThirteen").ToString();
    }

    public void UpgradeFourteen()
    {
        if (!buyUpgrade(PlayerPrefs.GetInt("upgradeFourteen") * 5)) return;
        PlayerPrefs.SetInt("upgradeFourteen", PlayerPrefs.GetInt("upgradeFourteen") + 1);
        upgradeFourteenText.text = PlayerPrefs.GetInt("upgradeFourteen").ToString();
    }

    public void UpgradeFifteen()
    {
        if (!buyUpgrade(PlayerPrefs.GetInt("upgradeFifteen") * 5)) return;
        PlayerPrefs.SetInt("upgradeFifteen", PlayerPrefs.GetInt("upgradeFifteen") + 1);
        upgradeFifteenText.text = PlayerPrefs.GetInt("upgradeFifteen").ToString();
    }

    public void UpgradeSixteen()
    {
        if (!buyUpgrade(PlayerPrefs.GetInt("upgradeSixteen") * 5)) return;
        PlayerPrefs.SetInt("upgradeSixteen", PlayerPrefs.GetInt("upgradeSixteen") + 1);
        upgradeSixteenText.text = PlayerPrefs.GetInt("upgradeSixteen").ToString();
    }

    public bool buyUpgrade(int price)
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
