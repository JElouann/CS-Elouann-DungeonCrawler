using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletDeath : MonoBehaviour
{
    [SerializeField]
    private bool _isStoppedByWall;
    private float lifeTime;
    [SerializeField]
    private SO_Bullet SObullet;
    private void Start()
    {
        lifeTime = SObullet.BulletLifeTime;
        StartCoroutine(DestroyBullet(lifeTime));
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall" && _isStoppedByWall)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyBullet(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
