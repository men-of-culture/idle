using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatsManager", menuName = "ScriptableObjects/PlayerStatsManager", order = 2)]

public class PlayerStatsManager : ScriptableObject
{
    public int damage = 1;
    public int health = 10;
    public int armor = 0;
    public float attackSpeed = 5.0f;
    public int kills = 0;
    public float volume = 1;
    public int loot = 0;
    public string blessing = "sword";
    public int perk1 = 0;
    public int perk2 = 0;
    public int perk3 = 0;
    public int ascension = 0;

    public void reset()
    {
        damage = 1;
        armor = 0;
        health = 10;
        attackSpeed = 5.0f;
        kills = 0;
        loot = 0;
    }
}
