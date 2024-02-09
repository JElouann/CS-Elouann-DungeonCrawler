using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 3)]
public class SO_Enemies : ScriptableObject
{
    [Header("Informations")]
    public string EnemyName;
    public string EnemyDescription;
    [Header("Stats")]
    public float EnemySpeed;
    public int EnemyHealth;
    public int EnemyDamage;
    [Header("Others")]
    public GameObject EnemyPrefab;
}
