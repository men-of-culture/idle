using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvasScript : MonoBehaviour
{
    public Image swordActiveImage;
    public Image arrowActiveImage;
    public Image bombActiveImage;
    public RectTransform swordIcon;
    public RectTransform arrowIcon;
    public RectTransform bombIcon;

    public PlayerCanvasScript playerCanvasScript;
    public PlayerScript playerScript;

    public PlayerStatsManager playerStatsManager;
    public MonsterSpawnerManager monsterSpawnerManager;

    public Image swordBlessingImage, arrowBlessingImage, bombBlessingImage;

    public Image perk1ActiveImage, perk2ActiveImage, perk3ActiveImage;

    void Start()
    {
        if (playerStatsManager.blessing == "sword") ActivateSword();
        if (playerStatsManager.blessing == "arrow") ActivateArrow();
        if (playerStatsManager.blessing == "bomb") ActivateBomb();

        if(PlayerPrefs.GetInt("perk1") == 1)
        {
            playerStatsManager.perk1 = 1;
            perk1ActiveImage.enabled = true;
        }
        if(PlayerPrefs.GetInt("perk2") == 1)
        {
            playerStatsManager.perk2 = 1;
            perk2ActiveImage.enabled = true;
        }
        if(PlayerPrefs.GetInt("perk3") == 1)
        {
            playerStatsManager.perk3 = 1;
            perk3ActiveImage.enabled = true;
        }
    }

    public void TogglePerk1()
    {
        if(PlayerPrefs.GetInt("perk1") == 1)
        {
            PlayerPrefs.SetInt("perk1", 0);
            playerStatsManager.perk1 = 0;
            perk1ActiveImage.enabled = false;
        }
        else if(PlayerPrefs.GetInt("perk1") == 0)
        {
            PlayerPrefs.SetInt("perk1", 1);
            playerStatsManager.perk1 = 1;
            perk1ActiveImage.enabled = true;
        }
    }
    public void TogglePerk2()
    {
        if(PlayerPrefs.GetInt("perk2") == 1)
        {
            PlayerPrefs.SetInt("perk2", 0);
            playerStatsManager.perk2 = 0;
            perk2ActiveImage.enabled = false;
        }
        else if(PlayerPrefs.GetInt("perk2") == 0)
        {
            PlayerPrefs.SetInt("perk2", 1);
            playerStatsManager.perk2 = 1;
            perk2ActiveImage.enabled = true;
        }
    }
    public void TogglePerk3()
    {
        if(PlayerPrefs.GetInt("perk3") == 1)
        {
            PlayerPrefs.SetInt("perk3", 0);
            playerStatsManager.perk3 = 0;
            perk3ActiveImage.enabled = false;
        }
        else if(PlayerPrefs.GetInt("perk3") == 0)
        {
            PlayerPrefs.SetInt("perk3", 1);
            playerStatsManager.perk3 = 1;
            perk3ActiveImage.enabled = true;
        }
    }

    public void ActivateSword()
    {
        swordActiveImage.enabled = true;
        arrowActiveImage.enabled = false;
        bombActiveImage.enabled = false;
        playerScript.weapon = Weapon.Sword;
        swordIcon.sizeDelta = new Vector2(90, 90);
        arrowIcon.sizeDelta = new Vector2(70, 70);
        bombIcon.sizeDelta = new Vector2(70, 70);
        playerStatsManager.blessing = "sword";

        /*swordBlessingImage.enabled = true;
        arrowBlessingImage.enabled = false;
        bombBlessingImage.enabled = false;*/
    }
    public void ActivateArrow()
    {
        swordActiveImage.enabled = false;
        arrowActiveImage.enabled = true;
        bombActiveImage.enabled = false;
        playerScript.weapon = Weapon.Arrow;
        swordIcon.sizeDelta = new Vector2(70, 70);
        arrowIcon.sizeDelta = new Vector2(90, 90);
        bombIcon.sizeDelta = new Vector2(70, 70);
        playerStatsManager.blessing = "arrow";

        /*swordBlessingImage.enabled = false;
        arrowBlessingImage.enabled = true;
        bombBlessingImage.enabled = false;*/
    }
    public void ActivateBomb()
    {
        swordActiveImage.enabled = false;
        arrowActiveImage.enabled = false;
        bombActiveImage.enabled = true;
        playerScript.weapon = Weapon.Bomb;
        swordIcon.sizeDelta = new Vector2(70, 70);
        arrowIcon.sizeDelta = new Vector2(70, 70);
        bombIcon.sizeDelta = new Vector2(90, 90);
        playerStatsManager.blessing = "bomb";

        /*swordBlessingImage.enabled = false;
        arrowBlessingImage.enabled = false;
        bombBlessingImage.enabled = true;*/
    }

    public void MoreHealth()
    {
        playerStatsManager.health += 100;
        playerStatsManager.armor += 100;
    }
    public void LessHealth()
    {
        playerStatsManager.health = 1;
        playerStatsManager.armor = 0;
    }
    public void MoreTime()
    {
        monsterSpawnerManager.timer += 60;
    }
    public void SlowAttack()
    {
        playerStatsManager.attackSpeed = 5;
    }
    public void NormalAttack()
    {
        playerStatsManager.attackSpeed = 1f;
    }
    public void FastAttack()
    {
        playerStatsManager.attackSpeed = .33f;
    }
    public void ResetTime()
    {
        monsterSpawnerManager.timer = 1;
    }
}
