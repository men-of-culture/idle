using UnityEngine;

[CreateAssetMenu(fileName = "StringManager", menuName = "ScriptableObjects/StringManager", order = 1)]
public class StringManager : ScriptableObject
{
    // This sections is used for upgrades
    public readonly string upgradeOne = "upgradeOne";
    public readonly string upgradeTwo = "upgradeTwo";
    public readonly string upgradeThree = "upgradeThree";


    // This sections is used for currency and kills/exp
    public readonly string currency = "currency";
    public readonly string lifetimeKills = "lifetimeKills";


    // This section is used for tags
    public readonly string playerTag = "Player";
    public readonly string projectileTag = "Projectile";
    public readonly string monsterTag = "Monster";


    // This section is used for animations
    public readonly string fadeOutTrigger = "FadeOut";

    // This sections is used for sounds
    public readonly string healthFadeInSound = "healthFadeIn";

    public readonly string volume = "volume";

    public readonly string monsterList = "MonsterList";
}
