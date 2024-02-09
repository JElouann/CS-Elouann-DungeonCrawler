using System.Collections;
using UnityEngine;

public class BulletDeath : MonoBehaviour
{
    [SerializeField]
    private bool _isStoppedByWall;
    private float _lifeTime;
    [SerializeField]
    private SO_Bullet _sObullet;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall" && _isStoppedByWall)
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.SendMessage("LowerHealth", SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _lifeTime = _sObullet.BulletLifeTime;
        StartCoroutine(DestroyBullet(_lifeTime));
    }

    private IEnumerator DestroyBullet(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
