using UnityEngine;

[CreateAssetMenu(fileName = "NewHeroData", menuName = "Game Data/Hero Data")]
public class HeroData : ScriptableObject
{
    [Header("Identitas")]
    public string heroName;
    public string description;

    [Header("Status Utama")]
    public float moveSpeed = 5f;
    public int maxHealth = 10;

    [Header("Pertarungan")]
    public int attackDamage = 3;
}