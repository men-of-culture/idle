using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatsManager", menuName = "ScriptableObjects/PlayerStatsManager", order = 2)]

public class PlayerStatsManager : ScriptableObject
{
    public int damage = 1;
    public int health = 10;
    public int armor = 5;
    public float attackSpeed = 10.0f;
    public int kills = 0;
    public float volume = 1;
    public int loot = 0;

    public void reset()
    {
        damage = 1;
        armor = 0;
        health = 10;
        attackSpeed = 10.0f;
        kills = 0;
        loot = 0;
    }
}
