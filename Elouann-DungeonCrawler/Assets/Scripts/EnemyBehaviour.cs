using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private SO_Enemies _sOEnemy;

    private Player _targetPlayer;

    private Vector2 _targetPos;
    private int _health;

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

    private void Awake()
    {
        _health = _sOEnemy.EnemyHealth;
        _targetPlayer = FindFirstObjectByType<Player>();
    }

    private void Update()
    {
        _targetPos = _targetPlayer.transform.position;
        gameObject.transform.position = Vector2.MoveTowards(transform.position, _targetPos, Time.deltaTime * _sOEnemy.EnemySpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _targetPlayer.AdjustHealth();
            Destroy(gameObject);
        }
    }
}
