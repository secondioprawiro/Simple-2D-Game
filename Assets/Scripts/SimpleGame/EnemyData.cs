using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Game Data/Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Header("Identitas")]
    public string enemyName;

    [Header("Status")]
    public int maxHealth = 5;
    public int damage = 1;

    [Header("Pergerakan")]
    public float speed = 2f;
    public float patrolRange = 3f;
}