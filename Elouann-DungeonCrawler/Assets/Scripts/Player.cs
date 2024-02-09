using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private SO_Characters _characterClass;
    private Rigidbody2D _rb;
    private Camera MainCamera;
    [SerializeField]
    private GameObject _rotatePoint;
    private int _health;

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

    private void Awake()
    {
        _health = _characterClass.CharacterHealth;
    }

    private void Start()
    {
        MainCamera = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(x, y) * _characterClass.CharacterSpeed * Time.fixedDeltaTime);
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
        GameObject bullet = Instantiate(_characterClass.CharacterBullet.BulletPrefab, _rotatePoint.transform.position, _rotatePoint.transform.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(bullet.transform.right * _characterClass.CharacterBullet.BulletSpeed);
    }
}
