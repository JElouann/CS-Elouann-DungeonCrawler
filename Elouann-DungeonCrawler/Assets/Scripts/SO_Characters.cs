using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character", order = 1)]
public class SO_Characters : ScriptableObject
{
    [Header("Informations")]
    public string CharacterName;
    public string CharacterDescription;
    public Sprite CharacterSprite;
    [Header("Stats")]
    public float CharacterSpeed;
    public int CharacterHealth;
    public int CharacterDamage;
    public float CharacterShotRate;
    [Header("Caracteristics")]
    public SO_Bullet CharacterBullet;
}
