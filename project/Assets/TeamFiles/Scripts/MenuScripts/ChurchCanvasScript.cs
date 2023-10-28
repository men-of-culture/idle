using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChurchCanvasScript : MonoBehaviour
{

    public Color selectedColor;
    public Color unselectedColor;
    public Image swordIcon;
    public Image arrowIcon;
    public Image bombIcon;

    public Button swordButton;
    public Button arrowButton;
    public Button bombButton;
    public Image swordButtonImg;
    public Image arrowButtonImg;
    public Image bombButtonImg;
    public TextMeshProUGUI swordButtonText;
    public TextMeshProUGUI arrowButtonText;
    public TextMeshProUGUI bombButtonText;

    public TextMeshProUGUI swordContext;
    public TextMeshProUGUI arrowContext;
    public TextMeshProUGUI bombContext;

    [SerializeField]
    private PlayerStatsManager playerStatsManager;

    public Canvas playeruiCanvas, churchCanvas;

    // Start is called before the first frame update
    void Start()
    {
        playerStatsManager.ascension = PlayerPrefs.GetInt("ascension");

        swordIcon.enabled = true;
        swordButton.enabled = true;
        swordButtonImg.enabled = true;
        swordButtonText.enabled = true;

        if (playerStatsManager.ascension <= 0)
        {
            arrowIcon.enabled = false;
            arrowButton.enabled = false;
            arrowButtonImg.enabled = false;
            arrowButtonText.enabled = false;

            bombIcon.enabled = false;
            bombButton.enabled = false;
            bombButtonImg.enabled = false;
            bombButtonText.enabled = false;
        }
        if (playerStatsManager.ascension == 1)
        {
            arrowIcon.enabled = true;
            arrowButton.enabled = true;
            arrowButtonImg.enabled = true;
            arrowButtonText.enabled = true;

            bombIcon.enabled = false;
            bombButton.enabled = false;
            bombButtonImg.enabled = false;
            bombButtonText.enabled = false;
        }
        if (playerStatsManager.ascension >= 2)
        {
            arrowIcon.enabled = true;
            arrowButton.enabled = true;
            arrowButtonImg.enabled = true;
            arrowButtonText.enabled = true;

            bombIcon.enabled = true;
            bombButton.enabled = true;
            bombButtonImg.enabled = true;
            bombButtonText.enabled = true;
        }

        if (playerStatsManager.blessing == "sword") SelectSword();
        if (playerStatsManager.blessing == "arrow") SelectArrow();
        if (playerStatsManager.blessing == "bomb") SelectBomb();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectSword()
    {
        swordIcon.color = selectedColor;
        arrowIcon.color = unselectedColor;
        bombIcon.color = unselectedColor;

        swordContext.enabled = true;
        arrowContext.enabled = false;
        bombContext.enabled = false;

        playerStatsManager.blessing = "sword";
    }
    public void SelectArrow()
    {
        swordIcon.color = unselectedColor;
        arrowIcon.color = selectedColor;
        bombIcon.color = unselectedColor;

        swordContext.enabled = false;
        arrowContext.enabled = true;
        bombContext.enabled = false;

        playerStatsManager.blessing = "arrow";
    }
    public void SelectBomb()
    {
        swordIcon.color = unselectedColor;
        arrowIcon.color = unselectedColor;
        bombIcon.color = selectedColor;

        swordContext.enabled = false;
        arrowContext.enabled = false;
        bombContext.enabled = true;

        playerStatsManager.blessing = "bomb";
    }
}
