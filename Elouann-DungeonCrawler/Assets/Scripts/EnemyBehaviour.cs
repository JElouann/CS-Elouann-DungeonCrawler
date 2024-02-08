using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private SO_Enemies SOEnemy;

    [SerializeField]
    private Player Player;

    private Vector2 targetPos;
    private int _health;

    private void Awake()
    {
        _health = SOEnemy.EnemyHealth;
    }
    private void Update()
    {
        targetPos = Player.transform.position;
        gameObject.transform.position = Vector2.MoveTowards(transform.position, targetPos, Time.deltaTime * SOEnemy.EnemySpeed);
    }

    public void LowerHealth()
    {
        if (_health > 0)
        {
            _health--;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            Player.AdjustHealth();
        }
    }
}
