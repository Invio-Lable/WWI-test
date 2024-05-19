using UnityEngine;

[CreateAssetMenu]
public class GameData : ScriptableObject
{
    public int productionUpgradeLevel;
    public int healthUpgradeLevel;
    public int bonusUpgradeLevel;

    public float towerHealth;
    public float productionInterval;
    public float bonus;
}