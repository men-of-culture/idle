using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WizardCanvasScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Color activatedColor;
    public Color deactivatedColor;
    public Image perk1Icon;
    public Image perk2Icon;
    public Image perk3Icon;
    public TextMeshProUGUI perk1Context;
    public TextMeshProUGUI perk2Context;
    public TextMeshProUGUI perk3Context;

    [SerializeField]
    private PlayerStatsManager playerStatsManager;

    public Canvas playeruiCanvas, wizardCanvas;

    public Button perk1BuyButton;
    public Button perk2BuyButton;
    public Button perk3BuyButton;
    public Image perk1BuyButtonImage;
    public Image perk2BuyButtonImage;
    public Image perk3BuyButtonImage;
    public Image perk1BuyButtonIcon;
    public Image perk2BuyButtonIcon;
    public Image perk3BuyButtonIcon;
    public TextMeshProUGUI perk1BuyButtonText;
    public TextMeshProUGUI perk2BuyButtonText;
    public TextMeshProUGUI perk3BuyButtonText;

    [SerializeField]
    private TextMeshProUGUI currencyText;

    // Start is called before the first frame update
    void Start()
    {
        // add to playerprefs and check, set playerStatsManger.perkx = 1 here
        if(PlayerPrefs.GetInt("perk1", 0) == 1) playerStatsManager.perk1 = 1;
        if(PlayerPrefs.GetInt("perk2", 0) == 1) playerStatsManager.perk2 = 1;
        if(PlayerPrefs.GetInt("perk3", 0) == 1) playerStatsManager.perk3 = 1;

        if (playerStatsManager.perk1 == 1) ActivatePerk1();
        if (playerStatsManager.perk2 == 1) ActivatePerk2();
        if (playerStatsManager.perk3 == 1) ActivatePerk3();

        SelectPerk1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyPerk1()
    {
        if(PlayerPrefs.GetInt("currency") < 500) return;

        PlayerPrefs.SetInt("currency", PlayerPrefs.GetInt("currency") - 500);
        PlayerPrefs.SetInt("perk1", 1);
        currencyText.text = PlayerPrefs.GetInt("currency").ToString();
        playerStatsManager.perk1 = 1;
        ActivatePerk1();
    }
    public void BuyPerk2()
    {
        if(PlayerPrefs.GetInt("currency") < 500) return;
        
        PlayerPrefs.SetInt("currency", PlayerPrefs.GetInt("currency") - 500);
        PlayerPrefs.SetInt("perk2", 1);
        currencyText.text = PlayerPrefs.GetInt("currency").ToString();
        playerStatsManager.perk2 = 1;
        ActivatePerk2();
    }
    public void BuyPerk3()
    {
        if(PlayerPrefs.GetInt("currency") < 5000) return;

        PlayerPrefs.SetInt("currency", PlayerPrefs.GetInt("currency") - 5000);
        PlayerPrefs.SetInt("perk3", 1);
        currencyText.text = PlayerPrefs.GetInt("currency").ToString();
        playerStatsManager.perk3 = 1;
        ActivatePerk3();
    }

    void ActivatePerk1()
    {
        perk1Icon.color = activatedColor;

        perk1BuyButton.enabled = false;
        perk1BuyButtonIcon.enabled = false;
        perk1BuyButtonText.enabled = false;
        perk1BuyButtonImage.enabled = false;
    }
    void ActivatePerk2()
    {
        perk2Icon.color = activatedColor;

        perk2BuyButton.enabled = false;
        perk2BuyButtonIcon.enabled = false;
        perk2BuyButtonText.enabled = false;
        perk2BuyButtonImage.enabled = false;
    }
    void ActivatePerk3()
    {
        perk3Icon.color = activatedColor;

        perk3BuyButton.enabled = false;
        perk3BuyButtonIcon.enabled = false;
        perk3BuyButtonText.enabled = false;
        perk3BuyButtonImage.enabled = false;
    }

    public void SelectPerk1()
    {
        perk1Context.enabled = true;
        perk2Context.enabled = false;
        perk3Context.enabled = false;

        perk2BuyButton.enabled = false;
        perk3BuyButton.enabled = false;

        perk2BuyButtonImage.enabled = false;
        perk3BuyButtonImage.enabled = false;

        perk2BuyButtonIcon.enabled = false;
        perk3BuyButtonIcon.enabled = false;

        perk2BuyButtonText.enabled = false;
        perk3BuyButtonText.enabled = false;

        if(playerStatsManager.perk1 != 1)
        {
            perk1BuyButton.enabled = true;
            perk1BuyButtonImage.enabled = true;
            perk1BuyButtonIcon.enabled = true;
            perk1BuyButtonText.enabled = true;
        }
    }
    public void SelectPerk2()
    {
        perk1Context.enabled = false;
        perk2Context.enabled = true;
        perk3Context.enabled = false;

        perk1BuyButton.enabled = false;
        perk3BuyButton.enabled = false;

        perk1BuyButtonImage.enabled = false;
        perk3BuyButtonImage.enabled = false;

        perk1BuyButtonIcon.enabled = false;
        perk3BuyButtonIcon.enabled = false;
        
        perk1BuyButtonText.enabled = false;
        perk3BuyButtonText.enabled = false;

        if(playerStatsManager.perk2 != 1)
        {
            perk2BuyButton.enabled = true;
            perk2BuyButtonImage.enabled = true;
            perk2BuyButtonIcon.enabled = true;
            perk2BuyButtonText.enabled = true;
        }
    }
    public void SelectPerk3()
    {
        perk1Context.enabled = false;
        perk2Context.enabled = false;
        perk3Context.enabled = true;

        perk1BuyButton.enabled = false;
        perk2BuyButton.enabled = false;

        perk1BuyButtonImage.enabled = false;
        perk2BuyButtonImage.enabled = false;

        perk1BuyButtonIcon.enabled = false;
        perk2BuyButtonIcon.enabled = false;
        
        perk1BuyButtonText.enabled = false;
        perk2BuyButtonText.enabled = false;

        if(playerStatsManager.perk3 != 1)
        {
            perk3BuyButton.enabled = true;
            perk3BuyButtonImage.enabled = true;
            perk3BuyButtonIcon.enabled = true;
            perk3BuyButtonText.enabled = true;
        }
    }
}
