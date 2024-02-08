using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField]
    protected SO_Characters characterClass;
    
    private Rigidbody2D rb;

    private Camera MainCamera; //

    [SerializeField]
    private GameObject rotatePoint;

    private int _health;

    private void Awake()
    {
        _health = characterClass.CharacterHealth;
    }
    public void AdjustHealth()
    {
        if (_health > 0)
        {
            Debug.Log(_health);
            _health--;
        }
        else
        {
            EditorApplication.ExitPlaymode();
        }
    }

    private void Start()
    {
        MainCamera = Camera.main; //
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(x, y) * characterClass.CharacterSpeed * Time.fixedDeltaTime);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(characterClass.CharacterBullet.BulletPrefab, rotatePoint.transform.position, rotatePoint.transform.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(bullet.transform.right * characterClass.CharacterBullet.BulletSpeed);
    }
}
