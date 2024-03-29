using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "ScriptableObjects/Bullet", order = 2)]
public class SO_Bullet : ScriptableObject
{
    public float BulletLifeTime;
    public float BulletSpeed;
    public GameObject BulletPrefab;
}
