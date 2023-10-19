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

    public void ActivateSword()
    {
        swordActiveImage.enabled = true;
        arrowActiveImage.enabled = false;
        bombActiveImage.enabled = false;
        playerScript.weapon = Weapon.Sword;
        swordIcon.sizeDelta = new Vector2(90, 90);
        arrowIcon.sizeDelta = new Vector2(70, 70);
        bombIcon.sizeDelta = new Vector2(70, 70);
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
